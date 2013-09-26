using System;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Object;
using Landpy.ActiveDirectory.TestSuite.Common;
using Landpy.TestFramwork.Configuration;
using Moq;
using NUnit.Framework;
using Is = Landpy.ActiveDirectory.Core.Filter.Expression.Is;

namespace Landpy.ActiveDirectory.TestSuite.ADObjectModule
{
    class GroupObjectUnitTest : BaseUnitTest
    {
        private Guid GroupGuid { get; set; }
        private string GroupCn { get; set; }
        private string GroupSid { get; set; }
        private string GroupSAMAccountName { get; set; }
        private string GroupEmail { get; set; }
        private string GroupNotes { get; set; }
        private string GroupTokenGroupSid { get; set; }
        private string GroupMember { get; set; }
        private string GroupType { get; set; }
        private string GroupScope { get; set; }
        private IADOperator IPADOperator { get; set; }

        protected override void SetUp()
        {
            this.GroupGuid = new Guid(TF.GetConfig().Properties["GroupGuid"]);
            this.GroupCn = TF.GetConfig().Properties["GroupCn"];
            this.GroupSid = TF.GetConfig().Properties["GroupSid"];
            this.GroupSAMAccountName = TF.GetConfig().Properties["GroupSAMAccountName"];
            this.GroupEmail = TF.GetConfig().Properties["GroupEmail"];
            this.GroupNotes = TF.GetConfig().Properties["GroupNotes"];
            this.GroupTokenGroupSid = TF.GetConfig().Properties["GroupTokenGroupSid"];
            this.GroupMember = TF.GetConfig().Properties["GroupMember"];
            this.GroupType = TF.GetConfig().Properties["GroupType"];
            this.GroupScope = TF.GetConfig().Properties["GroupScope"];
            var mock = new Mock<IADOperator>();
            var adOperatorInfo = new ADOperatorInfo
            {
                UserLoginName = TF.GetConfig().Properties["IPDomainUserName"],
                Password = TF.GetConfig().Properties["IPDomainUserPassword"],
                OperateDomainName = TF.GetConfig().Properties["IPDomainName"],
            };
            mock.Setup(m => m.GetOperatorInfo()).Returns(adOperatorInfo);
            this.IPADOperator = mock.Object;
        }

        [TestCase]
        public void TestGroupObjectFindAll()
        {
            var groupObjects = GroupObject.FindAll(this.ADOperator);
            Assert.AreNotEqual(0, groupObjects.Count);
            foreach (GroupObject groupObject in groupObjects)
            {
                using (groupObject)
                {
                    Console.WriteLine(groupObject.Path);
                }
            }
        }

        [TestCase]
        public void TestGroupObjectFindAllWithFilter()
        {
            var groupObjects = GroupObject.FindAll(this.ADOperator, new Is(AttributeNames.CN, this.GroupCn));
            foreach (GroupObject groupObject in groupObjects)
            {
                using (groupObject)
                {
                    Assert.AreEqual(this.GroupCn, groupObject.CN);
                }
            }
        }

        [TestCase]
        public void TestGroupObjectFindOne()
        {
            using (var groupObject = GroupObject.FindOneBySid(this.ADOperator, this.GroupSid))
            {
                Assert.AreEqual(this.GroupSAMAccountName, groupObject.SAMAccountName);
                Assert.AreEqual(this.GroupEmail, groupObject.Email);
                Assert.AreEqual(this.GroupNotes, groupObject.Notes);
                Assert.NotNull(groupObject.GroupSids);
                Assert.GreaterOrEqual(groupObject.GroupSids.Count, 1);
                Assert.AreEqual(this.GroupTokenGroupSid, groupObject.GroupSids[0]);
                Assert.NotNull(groupObject.Members);
                Assert.GreaterOrEqual(groupObject.Members.Count, 1);
                Assert.AreEqual(this.GroupMember, groupObject.Members[0]);
                Assert.AreEqual(this.GroupType, groupObject.GroupType.ToString());
                Assert.AreEqual(this.GroupScope, groupObject.GroupScopeType.ToString());
            }
            using (var adObject = ADObject.FindOneByObjectGUID(this.ADOperator, this.GroupGuid))
            {
                var groupObject = adObject as GroupObject;
                Assert.NotNull(groupObject);
                Assert.AreEqual(this.GroupSid, groupObject.ObjectSid);
            }
        }

        [TestCase]
        public void TestGroupObjectFindOneWithIP()
        {
            using (var adObject = ADObject.FindOneByObjectGUID(this.IPADOperator, this.GroupGuid))
            {
                var groupObject = adObject as GroupObject;
                Assert.NotNull(groupObject);
                Assert.AreEqual(this.GroupSid, groupObject.ObjectSid);
            }
        }
    }
}

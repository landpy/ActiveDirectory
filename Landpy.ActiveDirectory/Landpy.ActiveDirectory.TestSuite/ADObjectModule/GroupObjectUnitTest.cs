using System;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Object;
using Landpy.ActiveDirectory.TestSuite.Common;
using Landpy.TestFramwork.Configuration;
using NUnit.Framework;
using Is = Landpy.ActiveDirectory.Core.Filter.Expression.Is;

namespace Landpy.ActiveDirectory.TestSuite.ADObjectModule
{
    class GroupObjectUnitTest : BaseUnitTest
    {
        private string GroupCn { get; set; }
        private string GroupSid { get; set; }
        private string GroupSAMAccountName { get; set; }
        private string GroupEmail { get; set; }
        private string GroupNotes { get; set; }
        private string GroupTokenGroupSid { get; set; }
        private string GroupMember { get; set; }
        private string GroupType { get; set; }
        private string GroupScope { get; set; }

        protected override void SetUp()
        {
            this.GroupCn = TF.GetConfig().Properties["GroupCn"];
            this.GroupSid = TF.GetConfig().Properties["GroupSid"];
            this.GroupSAMAccountName = TF.GetConfig().Properties["GroupSAMAccountName"];
            this.GroupEmail = TF.GetConfig().Properties["GroupEmail"];
            this.GroupNotes = TF.GetConfig().Properties["GroupNotes"];
            this.GroupTokenGroupSid = TF.GetConfig().Properties["GroupTokenGroupSid"];
            this.GroupMember = TF.GetConfig().Properties["GroupMember"];
            this.GroupType = TF.GetConfig().Properties["GroupType"];
            this.GroupScope = TF.GetConfig().Properties["GroupScope"];
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
                Assert.AreEqual(this.GroupScope, groupObject.GroupScope.ToString());
            }
        }
    }
}

using System;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Object;
using Landpy.ActiveDirectory.TestSuite.Common;
using Landpy.TestFramwork.Configuration;
using NUnit.Framework;
using Is = Landpy.ActiveDirectory.Core.Filter.Expression.Is;

namespace Landpy.ActiveDirectory.TestSuite.ADObjectModule
{
    class ComputerObjectUnitTest : BaseUnitTest
    {
        private string ComputerCn { get; set; }
        private string ComputerOperatingSystemName { get; set; }
        private string ComputerOperatingSystemVersion { get; set; }
        private string ComputerOperatingSystemServicePack { get; set; }
        private string ComputerDnsName { get; set; }
        private string ComputerSiteName { get; set; }
        private string UserManageComputerCn { get; set; }
        private string ComputerManagedByUserCn { get; set; }
        private string GroupManageComputerCn { get; set; }
        private string ComputerManagedByGroupCn { get; set; }
        private string ContactManageComputerCn { get; set; }
        private string ComputerManagedByContactCn { get; set; }

        protected override void SetUp()
        {
            this.ComputerCn = TF.GetConfig().Properties["ComputerCn"];
            this.ComputerOperatingSystemName = TF.GetConfig().Properties["ComputerOperatingSystemName"];
            this.ComputerOperatingSystemVersion = TF.GetConfig().Properties["ComputerOperatingSystemVersion"];
            this.ComputerOperatingSystemServicePack = TF.GetConfig().Properties["ComputerOperatingSystemServicePack"];
            this.ComputerDnsName = TF.GetConfig().Properties["ComputerDnsName"];
            this.ComputerSiteName = TF.GetConfig().Properties["ComputerSiteName"];
            this.UserManageComputerCn = TF.GetConfig().Properties["UserManageComputerCn"];
            this.ComputerManagedByUserCn = TF.GetConfig().Properties["ComputerManagedByUserCn"];
            this.GroupManageComputerCn = TF.GetConfig().Properties["GroupManageComputerCn"];
            this.ComputerManagedByGroupCn = TF.GetConfig().Properties["ComputerManagedByGroupCn"];
            this.ContactManageComputerCn = TF.GetConfig().Properties["ContactManageComputerCn"];
            this.ComputerManagedByContactCn = TF.GetConfig().Properties["ComputerManagedByContactCn"];
        }

        [TestCase]
        public void TestComputerObjectFindAll()
        {
            var computerObjects = ComputerObject.FindAll(this.ADOperator);
            Assert.AreNotEqual(0, computerObjects.Count);
            foreach (ComputerObject computerObject in computerObjects)
            {
                using (computerObject)
                {
                    Console.WriteLine(computerObject.Path);
                }
            }
        }

        [TestCase]
        public void TestComputerObjectFindAllWithFilter()
        {
            var computerObjects = ComputerObject.FindAll(this.ADOperator, new Is(AttributeNames.CN, this.ComputerCn));
            foreach (ComputerObject computerObject in computerObjects)
            {
                using (computerObject)
                {
                    Assert.AreEqual(this.ComputerCn, computerObject.CN);
                }
            }
        }

        [TestCase]
        public void TestComputerObjectFindOne()
        {
            using (var computerObject = ComputerObject.FindOneByCN(this.ADOperator, this.ComputerCn))
            {
                Assert.AreEqual(this.ComputerOperatingSystemName, computerObject.OperatingSystemName);
                Assert.AreEqual(this.ComputerOperatingSystemVersion, computerObject.OperatingSystemVersion);
                Assert.AreEqual(this.ComputerOperatingSystemServicePack, computerObject.OperatingSystemServicePack);
                Assert.AreEqual(this.ComputerDnsName, computerObject.DnsName);
                Assert.AreEqual(this.ComputerSiteName, computerObject.SiteName);
            }
        }

        [TestCase]
        public void TestComputerObjectManagedBy()
        {
            using (var computerObject = ComputerObject.FindOneByCN(this.ADOperator, this.UserManageComputerCn))
            {
                Assert.AreEqual(this.ComputerManagedByUserCn, computerObject.ManagedByObject.CN);
            }
            using (var computerObject = ComputerObject.FindOneByCN(this.ADOperator, this.GroupManageComputerCn))
            {
                Assert.AreEqual(this.ComputerManagedByGroupCn, computerObject.ManagedByObject.CN);
            }
            using (var computerObject = ComputerObject.FindOneByCN(this.ADOperator, this.ContactManageComputerCn))
            {
                Assert.AreEqual(this.ComputerManagedByContactCn, computerObject.ManagedByObject.CN);
            }
        }
    }
}

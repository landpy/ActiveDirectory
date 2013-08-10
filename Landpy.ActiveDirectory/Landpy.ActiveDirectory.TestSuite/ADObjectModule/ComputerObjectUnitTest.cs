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

        protected override void SetUp()
        {
            this.ComputerCn = TF.GetConfig().Properties["ComputerCn"];
            this.ComputerOperatingSystemName = TF.GetConfig().Properties["ComputerOperatingSystemName"];
            this.ComputerOperatingSystemVersion = TF.GetConfig().Properties["ComputerOperatingSystemVersion"];
            this.ComputerOperatingSystemServicePack = TF.GetConfig().Properties["ComputerOperatingSystemServicePack"];
            this.ComputerDnsName = TF.GetConfig().Properties["ComputerDnsName"];
            this.ComputerSiteName = TF.GetConfig().Properties["ComputerSiteName"];
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
    }
}

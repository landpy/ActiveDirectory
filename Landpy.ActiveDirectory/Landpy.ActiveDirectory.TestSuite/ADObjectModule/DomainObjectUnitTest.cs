using System;
using Landpy.ActiveDirectory.TestSuite.Common;
using Landpy.TestFramwork.Configuration;
using NUnit.Framework;
using Landpy.ActiveDirectory.Entity.Object;

namespace Landpy.ActiveDirectory.TestSuite.ADObjectModule
{
    class DomainObjectUnitTest : BaseUnitTest
    {
        private int DomainGroupPolicyMinimumPasswordLength { get; set; }
        private bool DomianIsMustMeetComplexityRequirments { get; set; }
        private string CurrentDomainName { get; set; }

        protected override void SetUp()
        {
            this.DomainGroupPolicyMinimumPasswordLength = Int32.Parse(TF.GetConfig().Properties["DomainGroupPolicyMinimumPasswordLength"]);
            this.DomianIsMustMeetComplexityRequirments = Boolean.Parse(TF.GetConfig().Properties["DomianIsMustMeetComplexityRequirments"]);
            this.CurrentDomainName = TF.GetConfig().Properties["CurrentDomainName"];
        }

        [TestCase]
        public void TestFindOne()
        {
            using (var domainObject = DomainObject.FindOne(this.ADOperator))
            {
                Assert.AreEqual(this.DomainGroupPolicyMinimumPasswordLength, domainObject.GroupPolicyMinimumPasswordLength);
                Assert.AreEqual(this.DomianIsMustMeetComplexityRequirments, domainObject.IsMustMeetComplexityRequirments);
            }
        }

        [TestCase]
        public void TestGetCurrent()
        {
            using (var domainObject = DomainObject.GetCurrent())
            {
                Assert.AreEqual(this.CurrentDomainName, domainObject.Name);
            }
        }
    }
}

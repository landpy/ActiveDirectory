using System;
using Landpy.ActiveDirectory.TestSuite.Common;
using Landpy.TestFramwork.Configuration;
using NUnit.Framework;
using Landpy.ActiveDirectory.Entity.Object;

namespace Landpy.ActiveDirectory.TestSuite.ADObjectModule
{
    class PasswordSettings : BaseUnitTest
    {
        private string PasswordSettingsUserCn { get; set; }

        protected override void SetUp()
        {
            this.PasswordSettingsUserCn = TF.GetConfig().Properties["PasswordSettingsUserCn"];
        }

        [TestCase]
        public void TestFindOne()
        {
            foreach (var passwordSettingsObject in PasswordSettingsObject.FindAll(this.ADOperator, this.PasswordSettingsUserCn))
            {
                using (passwordSettingsObject)
                {
                    Console.WriteLine(passwordSettingsObject.CustomPolicyMinimumPasswordLength);
                    Console.WriteLine(passwordSettingsObject.IsMustMeetComplexityRequirments);
                }
            }
        }
    }
}

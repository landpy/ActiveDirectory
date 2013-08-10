using Landpy.ActiveDirectory.Password;
using Landpy.ActiveDirectory.TestSuite.Common;
using NUnit.Framework;
using Landpy.TestFramwork.Configuration;
using System;

namespace Landpy.ActiveDirectory.TestSuite.PasswordModule
{
    class PasswordUnityUnitTest : BaseUnitTest
    {
        private PasswordUnity PasswordUnity { get; set; }
        private string PasswordUnityUserLoginName { get; set; }
        private string PasswordUnityUserPassword { get; set; }

        protected override void SetUp()
        {
            this.PasswordUnity = new PasswordUnity();
            this.PasswordUnityUserLoginName = TF.GetConfig().Properties["PasswordUnityUserLoginName"];
            this.PasswordUnityUserPassword = TF.GetConfig().Properties["PasswordUnityUserPassword"];
        }

        [TestCase]
        public void TestIsPasswordValid()
        {
            Assert.IsTrue(this.PasswordUnity.IsPasswordValid(this.PasswordUnityUserLoginName, this.PasswordUnityUserPassword));
        }
    }
}

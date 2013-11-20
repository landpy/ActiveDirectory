using Landpy.ActiveDirectory.ADException;
using Landpy.ActiveDirectory.Password;
using Landpy.ActiveDirectory.TestSuite.Common;
using NUnit.Framework;
using Landpy.TestFramwork.Configuration;

namespace Landpy.ActiveDirectory.TestSuite.PasswordModule
{
    class PasswordUnityUnitTest : BaseUnitTest
    {
        private PasswordUnity PasswordUnity { get; set; }
        private string PasswordUnityUserLoginName { get; set; }
        private string PasswordUnityUserPassword { get; set; }
        private string PasswordUnityUserInValidPassword { get; set; }

        protected override void SetUp()
        {
            this.PasswordUnity = new PasswordUnity();
            this.PasswordUnityUserLoginName = TF.GetConfig().Properties["PasswordUnityUserLoginName"];
            this.PasswordUnityUserPassword = TF.GetConfig().Properties["PasswordUnityUserPassword"];
            this.PasswordUnityUserInValidPassword = TF.GetConfig().Properties["PasswordUnityUserInValidPassword"];
        }

        [TestCase]
        public void TestIsPasswordValid()
        {
            Assert.IsTrue(this.PasswordUnity.IsPasswordValid(this.PasswordUnityUserLoginName, this.PasswordUnityUserPassword));
        }

        [TestCase]
        [ExpectedException(typeof(UserLoginNameBadFormatException))]
        public void TestUserLoginNameBadFormat()
        {
            this.PasswordUnity.IsPasswordValid("Landpy", "Landpy");
        }

        [TestCase]
        public void TestIsPasswordInValid()
        {
            Assert.IsFalse(this.PasswordUnity.IsPasswordValid(this.PasswordUnityUserLoginName, this.PasswordUnityUserInValidPassword));
        }
    }
}

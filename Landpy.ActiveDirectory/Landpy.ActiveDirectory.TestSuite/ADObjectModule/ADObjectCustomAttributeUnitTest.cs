using Landpy.ActiveDirectory.Entity.Object;
using Landpy.ActiveDirectory.TestSuite.Common;
using Landpy.TestFramwork.Configuration;
using NUnit.Framework;

namespace Landpy.ActiveDirectory.TestSuite.ADObjectModule
{
    class ADObjectCustomAttributeUnitTest : BaseUnitTest
    {
        private string CustomAttributeUserCn { get; set; }

        protected override void SetUp()
        {
            this.CustomAttributeUserCn = TF.GetConfig().Properties["CustomAttributeUserCn"];
        }

        [TestCase]
        public void TestSetGetAttributeValue()
        {
            using (var userObject = UserObject.FindOneByCN(this.ADOperator, this.CustomAttributeUserCn))
            {
                userObject.SetAttributeValue("mail", "mv@live.cn");
                userObject.Save();
            }
            using (var userObject = UserObject.FindOneByCN(this.ADOperator, this.CustomAttributeUserCn))
            {
                var mail = userObject.GetAttributeValue<string>("mail");
                Assert.AreEqual("mv@live.cn", mail);
                userObject.ClearAttributeValue("mail");
                userObject.Save();
            }
        }
    }
}

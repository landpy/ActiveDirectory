using System;
using System.Collections.Generic;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
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
                userObject.SetAttributeValue(PersonAttributeNames.Mail, "mv@live.cn");
                userObject.SetAttributeValue(PersonAttributeNames.OtherTelephone, new List<string> { "123", "234", "345" });
                userObject.Save();
            }
            using (var userObject = UserObject.FindOneByCN(this.ADOperator, this.CustomAttributeUserCn))
            {
                var mail = userObject.GetAttributeValue<string>(PersonAttributeNames.Mail);
                var objectGuid = userObject.GetAttributeValue<Guid>(AttributeNames.ObjectGuid);
                Assert.NotNull(objectGuid);
                var passwardLastSetDateTime = userObject.GetAttributeValue<DateTime>(UserAttributeNames.PwdLastSet);
                Assert.AreNotEqual(passwardLastSetDateTime, DateTime.MinValue);
                var modifyDateTime = userObject.GetAttributeValue<DateTime>(AttributeNames.ModifyTimeStamp);
                Assert.AreNotEqual(modifyDateTime, DateTime.MinValue);
                var otherTelephones = userObject.GetAttributeValue<List<string>>(PersonAttributeNames.OtherTelephone);
                Assert.NotNull(otherTelephones);
                Assert.Greater(otherTelephones.Count, 0);
                Assert.AreEqual("mv@live.cn", mail);
                userObject.ClearAttributeValue(PersonAttributeNames.Mail);
                userObject.Save();
            }
        }

        [TestCase]
        public void TestClearAttributeValue()
        {
            using (var userObject = UserObject.FindOneByCN(this.ADOperator, this.CustomAttributeUserCn))
            {
                userObject.ClearAttributeValue(PersonAttributeNames.Info);
                userObject.Save();
            }
            using (var userObject = UserObject.FindOneByCN(this.ADOperator, this.CustomAttributeUserCn))
            {
                Assert.IsNullOrEmpty(userObject.Notes);
            }
        }

        [TestCase]
        public void TestVerifyADObjectExists()
        {
            Assert.IsFalse(ADObject.DoesADObjectExists(this.ADOperator, Guid.Empty));
        }

        [TestCase]
        public void TestGetDateTime()
        {
            using (var userObject = UserObject.FindOneByCN(this.ADOperator, this.CustomAttributeUserCn))
            {
                Console.WriteLine(userObject.GetAttributeValue<DateTime>("accountExpires"));
            }
        }
    }
}

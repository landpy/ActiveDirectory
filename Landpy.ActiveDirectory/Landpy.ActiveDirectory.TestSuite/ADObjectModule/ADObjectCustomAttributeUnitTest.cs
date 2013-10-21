﻿using System;
using System.Collections.Generic;
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
                userObject.SetAttributeValue("otherTelephone", new List<string> { "123", "234", "345" });
                userObject.Save();
            }
            using (var userObject = UserObject.FindOneByCN(this.ADOperator, this.CustomAttributeUserCn))
            {
                var mail = userObject.GetAttributeValue<string>("mail");
                var objectGuid = userObject.GetAttributeValue<Guid>("objectGuid");
                Assert.NotNull(objectGuid);
                var otherTelephones = userObject.GetAttributeValue<List<string>>("otherTelephone");
                Assert.NotNull(otherTelephones);
                Assert.Greater(otherTelephones.Count, 0);
                Assert.AreEqual("mv@live.cn", mail);
                userObject.ClearAttributeValue("mail");
                userObject.Save();
            }
        }

        [TestCase]
        public void TestVerifyADObjectExists()
        {
            Assert.IsFalse(ADObject.DoesADObjectExists(this.ADOperator, Guid.Empty));
        }
    }
}

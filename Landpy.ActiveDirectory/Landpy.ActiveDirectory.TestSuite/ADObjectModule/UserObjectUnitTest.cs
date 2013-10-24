using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Landpy.ActiveDirectory.Attributes;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Attribute.Value;
using Landpy.ActiveDirectory.TestSuite.Common;
using Landpy.TestFramwork.Configuration;
using NUnit.Framework;
using Landpy.ActiveDirectory.Entity.Object;
using Is = Landpy.ActiveDirectory.Core.Filter.Expression.Is;
using Landpy.ActiveDirectory.Password;

namespace Landpy.ActiveDirectory.TestSuite.ADObjectModule
{
    class UserObjectUnitTest : BaseUnitTest
    {
        private string UserCn { get; set; }
        private string UserSid { get; set; }
        private string UserCO { get; set; }
        private string UserC { get; set; }
        private string UserCompany { get; set; }
        private int UserCountryCode { get; set; }
        private string UserCanonicalName { get; set; }
        private DateTime UserCreateTime { get; set; }
        private string UserDepartment { get; set; }
        private string UserDescription { get; set; }
        private string UserDirectReport { get; set; }
        private string UserDisplayName { get; set; }
        private string UserFax { get; set; }
        private string UserOtherFax { get; set; }
        private string UserGivenName { get; set; }
        private string UserHomePhone { get; set; }
        private string UserOtherHomePhone { get; set; }
        private string UserNotes { get; set; }
        private string UserInitials { get; set; }
        private string UserIpPhone { get; set; }
        private string UserOtherIpPhone { get; set; }
        private string UserCity { get; set; }
        private string UserManager { get; set; }
        private string UserMemberOf { get; set; }
        private string UserMobile { get; set; }
        private string UserOtherMobile { get; set; }
        private string UserMsDS_PrincipalName { get; set; }
        private string UserPager { get; set; }
        private string UserOtherPager { get; set; }
        private string UserTelephone { get; set; }
        private string UserOtherTelephone { get; set; }
        private string UserOffice { get; set; }
        private string UserZipOrPostalCode { get; set; }
        private string UserPostOfficeBox { get; set; }
        private string UserSAMAccountName { get; set; }
        private string UserLastName { get; set; }
        private string UserStateOrProvince { get; set; }
        private string UserStreetAddress { get; set; }
        private string UserJobTitle { get; set; }
        private string UserWebPage { get; set; }
        private string UserOtherWebPage { get; set; }
        private string UserPrincipalName { get; set; }
        private string UserTokenGroupSid { get; set; }
        private string UserAccountControlType { get; set; }
        private bool UserIsMustChangePwdNextLogon { get; set; }
        private bool UserIsLocked { get; set; }
        private bool UserIsEnabled { get; set; }
        private string UserEmail { get; set; }
        private string UserResetPasswordUserCN { get; set; }
        private string UserResetPasswordUserPassword { get; set; }
        private bool UserIsDomainAdmin { get; set; }
        private bool UserIsAccountOperator { get; set; }
        private string UserManagerCn { get; set; }
        private string UserDirectReportUserCn { get; set; }
        private string UserDirectReportContactCn { get; set; }
        private string CustomAttributeUserCn { get; set; }
        private string UserSpecialCharCn { get; set; }

        protected override void SetUp()
        {
            this.UserCn = TF.GetConfig().Properties["UserCn"];
            this.UserSid = TF.GetConfig().Properties["UserSid"];
            this.UserCO = TF.GetConfig().Properties["UserCO"];
            this.UserC = TF.GetConfig().Properties["UserC"];
            this.UserCompany = TF.GetConfig().Properties["UserCompany"];
            this.UserCountryCode = Int32.Parse(TF.GetConfig().Properties["UserCountryCode"]);
            this.UserCanonicalName = TF.GetConfig().Properties["UserCanonicalName"];
            this.UserCreateTime = DateTime.Parse(TF.GetConfig().Properties["UserCreateTime"]);
            this.UserDepartment = TF.GetConfig().Properties["UserDepartment"];
            this.UserDescription = TF.GetConfig().Properties["UserDescription"];
            this.UserDirectReport = TF.GetConfig().Properties["UserDirectReport"];
            this.UserDisplayName = TF.GetConfig().Properties["UserDisplayName"];
            this.UserFax = TF.GetConfig().Properties["UserFax"];
            this.UserOtherFax = TF.GetConfig().Properties["UserOtherFax"];
            this.UserGivenName = TF.GetConfig().Properties["UserGivenName"];
            this.UserHomePhone = TF.GetConfig().Properties["UserHomePhone"];
            this.UserOtherHomePhone = TF.GetConfig().Properties["UserOtherHomePhone"];
            this.UserNotes = TF.GetConfig().Properties["UserNotes"];
            this.UserInitials = TF.GetConfig().Properties["UserInitials"];
            this.UserIpPhone = TF.GetConfig().Properties["UserIpPhone"];
            this.UserOtherIpPhone = TF.GetConfig().Properties["UserOtherIpPhone"];
            this.UserCity = TF.GetConfig().Properties["UserCity"];
            this.UserManager = TF.GetConfig().Properties["UserManager"];
            this.UserMemberOf = TF.GetConfig().Properties["UserMemberOf"];
            this.UserMobile = TF.GetConfig().Properties["UserMobile"];
            this.UserOtherMobile = TF.GetConfig().Properties["UserOtherMobile"];
            this.UserMsDS_PrincipalName = TF.GetConfig().Properties["UserMsDS_PrincipalName"];
            this.UserPager = TF.GetConfig().Properties["UserPager"];
            this.UserOtherPager = TF.GetConfig().Properties["UserOtherPager"];
            this.UserTelephone = TF.GetConfig().Properties["UserTelephone"];
            this.UserOtherTelephone = TF.GetConfig().Properties["UserOtherTelephone"];
            this.UserOffice = TF.GetConfig().Properties["UserOffice"];
            this.UserZipOrPostalCode = TF.GetConfig().Properties["UserZipOrPostalCode"];
            this.UserPostOfficeBox = TF.GetConfig().Properties["UserPostOfficeBox"];
            this.UserSAMAccountName = TF.GetConfig().Properties["UserSAMAccountName"];
            this.UserLastName = TF.GetConfig().Properties["UserLastName"];
            this.UserStateOrProvince = TF.GetConfig().Properties["UserStateOrProvince"];
            this.UserStreetAddress = TF.GetConfig().Properties["UserStreetAddress"];
            this.UserJobTitle = TF.GetConfig().Properties["UserJobTitle"];
            this.UserWebPage = TF.GetConfig().Properties["UserWebPage"];
            this.UserOtherWebPage = TF.GetConfig().Properties["UserOtherWebPage"];
            this.UserPrincipalName = TF.GetConfig().Properties["UserPrincipalName"];
            this.UserTokenGroupSid = TF.GetConfig().Properties["UserTokenGroupSid"];
            this.UserAccountControlType = TF.GetConfig().Properties["UserAccountControlType"];
            this.UserIsMustChangePwdNextLogon = Boolean.Parse(TF.GetConfig().Properties["UserIsMustChangePwdNextLogon"]);
            this.UserIsLocked = Boolean.Parse(TF.GetConfig().Properties["UserIsLocked"]);
            this.UserIsEnabled = Boolean.Parse(TF.GetConfig().Properties["UserIsEnabled"]);
            this.UserEmail = TF.GetConfig().Properties["UserEmail"];
            this.UserResetPasswordUserCN = TF.GetConfig().Properties["UserResetPasswordUserCN"];
            this.UserResetPasswordUserPassword = TF.GetConfig().Properties["UserResetPasswordUserPassword"];
            this.UserIsDomainAdmin = Boolean.Parse(TF.GetConfig().Properties["UserIsDomainAdmin"]);
            this.UserIsAccountOperator = Boolean.Parse(TF.GetConfig().Properties["UserIsAccountOperator"]);
            this.UserManagerCn = TF.GetConfig().Properties["UserManagerCn"];
            this.UserDirectReportUserCn = TF.GetConfig().Properties["UserDirectReportUserCn"];
            this.UserDirectReportContactCn = TF.GetConfig().Properties["UserDirectReportContactCn"];
            this.CustomAttributeUserCn = TF.GetConfig().Properties["CustomAttributeUserCn"];
            this.UserSpecialCharCn = TF.GetConfig().Properties["UserSpecialCharCn"];
        }

        [TestCase]
        public void TestUserObjectFindAll()
        {
            var userObjects = UserObject.FindAll(this.ADOperator);
            Assert.AreNotEqual(0, userObjects.Count);
            foreach (UserObject userObject in userObjects)
            {
                using (userObject)
                {
                    Console.WriteLine(userObject.Path);
                }
            }
        }

        [TestCase]
        public void TestUserObjectFindAllWithFilter()
        {
            var userObjects = UserObject.FindAll(this.ADOperator, new Is(AttributeNames.CN, this.UserCn));
            foreach (UserObject userObject in userObjects)
            {
                using (userObject)
                {
                    Assert.AreEqual(this.UserCn, userObject.CN);
                }
            }
        }

        [TestCase]
        public void TestUserObjectFindOne()
        {
            using (var userObject = UserObject.FindOneBySid(this.ADOperator, this.UserSid))
            {
                #region Verify User Object

                Assert.AreEqual(this.UserCn, userObject.CN);
                Assert.AreEqual(this.UserCO, userObject.CO);
                Assert.AreEqual(this.UserC, userObject.C);
                Assert.AreEqual(this.UserCompany, userObject.Company);
                Assert.AreEqual(this.UserCountryCode, userObject.CountryCode);
                Assert.AreEqual(this.UserCanonicalName, userObject.CanonicalName);
                Assert.AreEqual(this.UserCreateTime, userObject.CreateTime);
                Assert.AreNotEqual(DateTime.MinValue, userObject.ModifyTime);
                Assert.AreEqual(this.UserDepartment, userObject.Department);
                Assert.AreEqual(this.UserDescription, userObject.Description);
                Assert.IsNotNull(userObject.DirectReports);
                Assert.GreaterOrEqual(userObject.DirectReports.Count, 1);
                Assert.IsTrue(userObject.DirectReports.Contains(this.UserDirectReport));
                Assert.AreEqual(this.UserDisplayName, userObject.DisplayName);
                Assert.AreEqual(this.UserFax, userObject.Fax);
                Assert.IsNotNull(userObject.OtherFaxes);
                Assert.GreaterOrEqual(userObject.OtherFaxes.Count, 1);
                Assert.AreEqual(this.UserOtherFax, userObject.OtherFaxes[0]);
                Assert.AreEqual(this.UserGivenName, userObject.GivenName);
                Assert.AreEqual(this.UserHomePhone, userObject.HomePhone);
                Assert.NotNull(userObject.OtherHomePhones);
                Assert.GreaterOrEqual(userObject.OtherHomePhones.Count, 1);
                Assert.AreEqual(this.UserOtherHomePhone, userObject.OtherHomePhones[0]);
                Assert.AreEqual(this.UserNotes, userObject.Notes);
                Assert.AreEqual(this.UserInitials, userObject.Initials);
                Assert.AreEqual(this.UserIpPhone, userObject.IpPhone);
                Assert.NotNull(userObject.OtherIpPhones);
                Assert.GreaterOrEqual(userObject.OtherIpPhones.Count, 1);
                Assert.AreEqual(this.UserOtherIpPhone, userObject.OtherIpPhones[0]);
                Assert.AreEqual(this.UserCity, userObject.City);
                Assert.AreEqual(this.UserManager, userObject.Manager);
                Assert.IsNotNull(userObject.MemberOf);
                Assert.GreaterOrEqual(userObject.MemberOf.Count, 1);
                Assert.AreEqual(this.UserMemberOf, userObject.MemberOf[0]);
                Assert.AreEqual(this.UserMobile, userObject.Mobile);
                Assert.NotNull(userObject.OtherMobiles);
                Assert.GreaterOrEqual(userObject.OtherMobiles.Count, 1);
                Assert.AreEqual(this.UserOtherMobile, userObject.OtherMobiles[0]);
                Assert.AreEqual(this.UserMsDS_PrincipalName, userObject.MsDS_PrincipalName);
                Assert.AreEqual(this.UserPager, userObject.Pager);
                Assert.NotNull(userObject.OtherPagers);
                Assert.GreaterOrEqual(userObject.OtherPagers.Count, 1);
                Assert.AreEqual(this.UserOtherPager, userObject.OtherPagers[0]);
                Assert.AreEqual(this.UserTelephone, userObject.Telephone);
                Assert.NotNull(userObject.OtherTelephones);
                Assert.GreaterOrEqual(userObject.OtherTelephones.Count, 1);
                Assert.AreEqual(this.UserOtherTelephone, userObject.OtherTelephones[0]);
                Assert.AreEqual(this.UserOffice, userObject.Office);
                Assert.AreEqual(this.UserZipOrPostalCode, userObject.ZipOrPostalCode);
                Assert.NotNull(userObject.PostOfficeBoxs);
                Assert.GreaterOrEqual(userObject.PostOfficeBoxs.Count, 1);
                Assert.AreEqual(this.UserPostOfficeBox, userObject.PostOfficeBoxs[0]);
                Assert.AreEqual(this.UserSAMAccountName, userObject.SAMAccountName);
                Assert.AreEqual(this.UserLastName, userObject.LastName);
                Assert.AreEqual(this.UserStateOrProvince, userObject.StateOrProvince);
                Assert.AreEqual(this.UserStreetAddress, userObject.StreetAddress);
                Assert.AreEqual(this.UserJobTitle, userObject.JobTitle);
                Assert.AreEqual(this.UserWebPage, userObject.WebPage);
                Assert.NotNull(userObject.OtherWebPages);
                Assert.GreaterOrEqual(userObject.OtherWebPages.Count, 1);
                Assert.AreEqual(this.UserOtherWebPage, userObject.OtherWebPages[0]);
                Assert.AreEqual(this.UserPrincipalName, userObject.PrincipalName);
                Assert.NotNull(userObject.GroupSids);
                Assert.GreaterOrEqual(userObject.GroupSids.Count, 1);
                Assert.AreEqual(this.UserTokenGroupSid, userObject.GroupSids[0]);
                Assert.AreEqual(this.UserAccountControlType, userObject.AccountControlType.ToString());
                Assert.AreEqual(this.UserIsMustChangePwdNextLogon, userObject.IsMustChangePwdNextLogon);
                Assert.AreEqual(this.UserIsLocked, userObject.IsLocked);
                Assert.AreEqual(this.UserIsEnabled, userObject.IsEnabled);
                Assert.AreEqual(this.UserEmail, userObject.Email);
                Assert.AreEqual(this.UserIsDomainAdmin, userObject.IsDomainAdmin);
                Assert.AreEqual(this.UserIsAccountOperator, userObject.IsAccountOperator);

                #endregion
            }
            using (var userObject = UserObject.FindOneBySAMAccountName(this.ADOperator, this.UserSAMAccountName))
            {
                Assert.AreEqual(this.UserCn, userObject.CN);
                Assert.AreEqual(this.UserManagerCn, userObject.ManagerUser.CN);
                Assert.IsNotNull(userObject.DirectReports);
                Assert.IsTrue((from queryUserObject in userObject.DirectReportObjects
                               where queryUserObject.CN == this.UserDirectReportUserCn
                               select queryUserObject).Any());
                Assert.IsTrue((from queryContactObject in userObject.DirectReportObjects
                               where queryContactObject.CN == this.UserDirectReportContactCn
                               select queryContactObject).Any());
            }
        }

        [TestCase]
        public void TestUserObjectFindOneWithSuffix()
        {
            foreach (var user in UserObject.FindAll(this.ADOperator, new And(new HasAValue(PersonAttributeNames.TelephoneNumber), new IsNot(String.Format(@"{0}{1}", UserAttributeNames.UserAccountControl, UserAttributeNames.MatchingRuleBitAnd), UserAttributeValues.UserAccountControlDisabled))))
            {
                Console.WriteLine(user.CN);
            }
        }

        [TestCase]
        public void TestUserPasswordReset()
        {
            using (var userObject = UserObject.FindOneByCN(this.ADOperator, this.UserResetPasswordUserCN))
            {
                userObject.ResetPassword(this.UserResetPasswordUserPassword);
                var passwordUnity = new PasswordUnity();
                var operatorInfo = this.ADOperator.GetOperatorInfo();
                Assert.IsTrue(passwordUnity.IsPasswordValid(String.Format(@"{0}\{1}", operatorInfo.OperateDomainName, this.UserResetPasswordUserCN), this.UserResetPasswordUserPassword));
            }
        }

        [TestCase]
        public void TestUserObjectUpdate()
        {
            using (var userObject = UserObject.FindOneByCN(this.ADOperator, this.CustomAttributeUserCn))
            {
                userObject.OtherTelephones = new List<string> { "111", "222", "333" };
                userObject.Email = "hellokitty@live.cn";
                userObject.Save();
            }
            using (var userObject = UserObject.FindOneByCN(this.ADOperator, this.CustomAttributeUserCn))
            {
                Assert.IsTrue(userObject.OtherTelephones.Contains("111"));
                Assert.IsTrue(userObject.OtherTelephones.Contains("222"));
                Assert.IsTrue(userObject.OtherTelephones.Contains("333"));
                Assert.AreEqual("hellokitty@live.cn", userObject.Email);
            }
        }

        [TestCase]
        public void TestFilterSpecialChar()
        {
            using (var userObject = UserObject.FindOneByCN(this.ADOperator, this.UserSpecialCharCn))
            {
                Assert.NotNull(userObject);
            }
        }

        [TestCase]
        public void TestCustomAttribute()
        {
            Type type = typeof(UserObject);
            foreach (PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                foreach (ADOriginalAttributeNameAttribute adOriginalAttributeNameAttribute in propertyInfo.GetCustomAttributes(typeof(ADOriginalAttributeNameAttribute), true))
                {
                    Console.WriteLine(@"{0}-{1}", adOriginalAttributeNameAttribute.Name, propertyInfo.Name);
                }
            }
        }
    }
}

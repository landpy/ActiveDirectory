using System;
using System.Runtime.InteropServices;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Entity.Object;

namespace Landpy.ActiveDirectory.Password
{
    /// <summary>
    /// The password unity.
    /// </summary>
    public class PasswordUnity
    {
        /// <summary>
        /// Verify whether the password is valid.
        /// </summary>
        /// <param name="userLoginName">The user login name.</param>
        /// <param name="password">The user password.</param>
        /// <returns>Whether the password is valid.</returns>
        public bool IsPasswordValid(string userLoginName, string password)
        {
            bool isPasswordValid = false;
            var userNameAdpter = new UseNameAdapter(userLoginName);
            IADOperator adOperator = new ADOperator(userLoginName, password, userNameAdpter.UserDomainName);
            try
            {
                var userObject = UserObject.FindOneByCN(adOperator, userNameAdpter.UserName);
                if (userObject != null)
                {
                    isPasswordValid = true;
                }
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("Logon failure: unknown user name or bad password.") ||
                    exception.Message.Contains("The user name or password is incorrect."))
                {
                }
                else
                {
                    throw;
                }
            }
            return isPasswordValid;
        }
    }
}

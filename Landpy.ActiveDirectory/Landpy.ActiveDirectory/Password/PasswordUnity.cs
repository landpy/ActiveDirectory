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
            catch (COMException comException)
            {
                if (comException.Message.Equals("Logon failure: unknown user name or bad password.\r\n", StringComparison.CurrentCultureIgnoreCase))
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

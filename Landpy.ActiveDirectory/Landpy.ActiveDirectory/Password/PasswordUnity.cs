using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Entity.Object;

namespace Landpy.ActiveDirectory.Password
{
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
            var userObject = UserObject.FindOneByCN(adOperator, userNameAdpter.UserName);
            if (userObject != null)
            {
                isPasswordValid = true;
            }
            return isPasswordValid;
        }
    }
}

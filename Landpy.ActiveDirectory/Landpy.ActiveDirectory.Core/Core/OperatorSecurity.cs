using System;
using System.Collections.Generic;
using System.Text;

namespace Landpy.ActiveDirectory
{
    public struct OperatorSecurity
    {
        public OperatorSecurity(string ldapPath, string userName, string password)
        {
            this.LdapPath = ldapPath;
            this.UserName = userName;
            this.Password = password;
        }

        public string LdapPath;
        public string UserName;
        public string Password;
    }
}

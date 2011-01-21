using System;
using System.Collections.Generic;
using System.Text;

namespace Landpy.ActiveDirectory
{
    public class OperatorSecurity
    {
        public OperatorSecurity(string ldapPath, string userName, string password)
        {
            this.LdapPath = ldapPath;
            this.UserName = userName;
            this.Password = password;
        }

        public string LdapPath
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public string Password
        {
            internal get;
            set;
        }
    }
}

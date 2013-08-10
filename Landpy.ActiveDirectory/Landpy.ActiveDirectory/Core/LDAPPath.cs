using System;

namespace Landpy.ActiveDirectory.Core
{
    static class LDAPPath
    {
        public static readonly string LDAPPrefix = "LDAP://";
        public static readonly string CurrentDomainRootPath = String.Format(@"{0}{1}", LDAPPrefix, System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName);
    }
}

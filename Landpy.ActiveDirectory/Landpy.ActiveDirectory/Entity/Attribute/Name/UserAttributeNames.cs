namespace Landpy.ActiveDirectory.Entity.Attribute.Name
{
    /// <summary>
    /// The names of User AD object common attribute.
    /// </summary>
    public class UserAttributeNames : PersonAttributeNames
    {
        /// <summary>
        /// The sid.
        /// </summary>
        public static readonly string ObjectSid = "objectSid";

        /// <summary>
        /// The pre Win2000 inditity name.
        /// </summary>
        public static readonly string SAMAccountName = "sAMAccountName";

        /// <summary>
        /// The user logon name(eg: [UserName]@[DomainName]).
        /// </summary>
        public static readonly string UserPrincipalName = "userPrincipalName";

        /// <summary>
        /// The groups tokens.
        /// </summary>
        public static readonly string TokenGroups = "tokenGroups";

        /// <summary>
        /// The user account control (eg: enabled.).
        /// </summary>
        public static readonly string UserAccountControl = "userAccountControl";

        /// <summary>
        /// The user account control disbled suffix;
        /// </summary>
        public static readonly string UserAccountControlDisabledSuffix = ":1.2.840.113556.1.4.803:";

        /// <summary>
        /// The user account control computed.
        /// </summary>
        public static readonly string MsDS_User_Account_Control_Computed = "msDS-User-Account-Control-Computed";

        /// <summary>
        /// The password last set (eg: when 0 the user must reset the password next logon.).
        /// </summary>
        public static readonly string PwdLastSet = "pwdLastSet";

        /// <summary>
        /// The use object is locked.
        /// </summary>
        public static readonly string LockoutTime = "lockoutTime";
    }
}
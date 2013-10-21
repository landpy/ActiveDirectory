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
        public const string ObjectSid = "objectSid";

        /// <summary>
        /// The pre Win2000 inditity name.
        /// </summary>
        public const string SAMAccountName = "sAMAccountName";

        /// <summary>
        /// The groups tokens.
        /// </summary>
        public const string TokenGroups = "tokenGroups";

        /// <summary>
        /// The user logon name(eg: [UserName]@[DomainName]).
        /// </summary>
        public const string UserPrincipalName = "userPrincipalName";

        /// <summary>
        /// The user account control (eg: enabled.).
        /// </summary>
        public const string UserAccountControl = "userAccountControl";

        /// <summary>
        /// The user account control disbled suffix;
        /// </summary>
        public const string UserAccountControlDisabledSuffix = ":1.2.840.113556.1.4.803:";

        /// <summary>
        /// The user account control computed.
        /// </summary>
        public const string MsDS_User_Account_Control_Computed = "msDS-User-Account-Control-Computed";

        /// <summary>
        /// The password last set (eg: when 0 the user must reset the password next logon.).
        /// </summary>
        public const string PwdLastSet = "pwdLastSet";

        /// <summary>
        /// The use object is locked.
        /// </summary>
        public const string LockoutTime = "lockoutTime";
    }
}
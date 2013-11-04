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
        /// LDAP_MATCHING_RULE_BIT_AND: A match is found only if all bits from the attribute match the value. This rule is equivalent to a bitwise AND operator.
        /// </summary>
        public const string MatchingRuleBitAnd = ":1.2.840.113556.1.4.803:";

        /// <summary>
        /// LDAP_MATCHING_RULE_BIT_OR: A match is found if any bits from the attribute match the value. This rule is equivalent to a bitwise OR operator.
        /// </summary>
        public const string MatchingRuleBitOr = "1.2.840.113556.1.4.804:";

        /// <summary>
        /// LDAP_MATCHING_RULE_IN_CHAIN: This rule is limited to filters that apply to the DN. This is a special "extended match operator that walks the chain of ancestry in objects all the way to the root until it finds a match.
        /// </summary>
        public const string MatchingRuleBitChain = "1.2.840.113556.1.4.1941:";

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

        /// <summary>
        /// The user account expires time.
        /// </summary>
        public const string AccountExpires = "accountExpires";
    }
}
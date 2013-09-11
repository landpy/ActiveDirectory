namespace Landpy.ActiveDirectory.Entity.Attribute.Name
{
    /// <summary>
    /// The names of Domain AD object common attribute.
    /// </summary>
    public class DomainAttributeNames : PSOAttributeNames
    {
        /// <summary>
        /// The custom password policy precedence.
        /// </summary>
        public static readonly string MsDS_PasswordSettingsPrecedence = "msDS-PasswordSettingsPrecedence";

        /// <summary>
        /// The min length of the password.
        /// </summary>
        public static readonly string MinPwdLength = "minPwdLength";

        /// <summary>
        /// The properties of the password.
        /// </summary>
        public static readonly string PwdProperties = "pwdProperties";
    }
}

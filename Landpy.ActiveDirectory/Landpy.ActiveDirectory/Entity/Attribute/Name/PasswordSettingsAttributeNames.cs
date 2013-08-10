namespace Landpy.ActiveDirectory.Entity.Attribute.Name
{
    public class PasswordSettingsAttributeNames : PSOAttributeNames
    {
        /// <summary>
        /// The custom password policy min password length.
        /// </summary>
        public static readonly string MsDS_MinimumPasswordLength = "msDS-MinimumPasswordLength";

        /// <summary>
        /// The custom password policy complexity enabled.
        /// </summary>
        public static readonly string MsDS_PasswordComplexityEnabled = "msDS-PasswordComplexityEnabled";
    }
}

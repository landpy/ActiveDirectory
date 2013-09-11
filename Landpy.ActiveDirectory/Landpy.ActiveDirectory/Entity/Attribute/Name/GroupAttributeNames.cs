namespace Landpy.ActiveDirectory.Entity.Attribute.Name
{
    /// <summary>
    /// The names of Group AD object common attribute.
    /// </summary>
    public class GroupAttributeNames : AttributeNames
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
        /// The managed by.
        /// </summary>
        public static readonly string ManagedBy = "managedBy";

        /// <summary>
        /// The groups tokens.
        /// </summary>
        public static readonly string TokenGroups = "tokenGroups";

        /// <summary>
        /// The Email.
        /// </summary>
        public static readonly string Mail = "mail";

        /// <summary>
        /// The member.
        /// </summary>
        public static readonly string Member = "member";

        /// <summary>
        /// The group type.
        /// </summary>
        public static readonly string GroupType = "groupType";
    }
}

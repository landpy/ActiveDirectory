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
        public const string ObjectSid = "objectSid";

        /// <summary>
        /// The manged by user.
        /// </summary>
        public const string ManagedBy = "managedBy";

        /// <summary>
        /// The pre Win2000 inditity name.
        /// </summary>
        public const string SAMAccountName = "sAMAccountName";

        /// <summary>
        /// The groups tokens.
        /// </summary>
        public const string TokenGroups = "tokenGroups";

        /// <summary>
        /// The Email.
        /// </summary>
        public const string Mail = "mail";

        /// <summary>
        /// The member.
        /// </summary>
        public const string Member = "member";

        /// <summary>
        /// The group type.
        /// </summary>
        public const string GroupType = "groupType";
    }
}

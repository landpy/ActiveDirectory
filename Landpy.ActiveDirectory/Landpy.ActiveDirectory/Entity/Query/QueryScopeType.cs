namespace Landpy.ActiveDirectory.Entity.Query
{
    /// <summary>
    /// The query scope type.
    /// </summary>
    public enum QueryScopeType
    {
        /// <summary>
        /// Contains the current AD object and the child AD objects of the current AD object.
        /// </summary>
        OneLevel = 1,
        /// <summary>
        /// Contains the current AD object and child AD objects of the whole subtree.
        /// </summary>
        Subtree = 2
    }
}

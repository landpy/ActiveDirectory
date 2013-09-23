namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// Is group filter (Eg: (objectClass=group)).
    /// </summary>
    public class IsGroup : IFilter
    {
        /// <summary>
        /// Build the AD filter string (Eg: (objectClass=group)).
        /// </summary>
        /// <returns>The filter string.</returns>
        public string BuildFilter()
        {
            return FilterStrings.GroupFilter;
        }
    }
}

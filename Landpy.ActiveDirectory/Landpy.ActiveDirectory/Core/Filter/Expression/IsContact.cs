namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// Is contact filter (Eg: (objectClass=contact)).
    /// </summary>
    public class IsContact : IFilter
    {
        /// <summary>
        /// Build the AD filter string (Eg: (objectClass=contact)).
        /// </summary>
        /// <returns>The filter string.</returns>
        public string BuildFilter()
        {
            return FilterStrings.ContactFilter;
        }
    }
}

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// Is OU filter (Eg: (objectClass=organizationalUnit)).
    /// </summary>
    public class IsOU : IFilter
    {
        /// <summary>
        /// Build the AD filter string (Eg: (objectClass=organizationalUnit)).
        /// </summary>
        /// <returns>The filter string.</returns>
        public string BuildFilter()
        {
            return FilterStrings.OrganizationalUnitFilter;
        }
    }
}

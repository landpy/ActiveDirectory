namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// Is domain filter (Eg: (objectClass=domainDNS)).
    /// </summary>
    public class IsDomain : IFilter
    {
        /// <summary>
        /// Build the AD filter string (Eg: (objectClass=domainDNS)).
        /// </summary>
        /// <returns>The filter string.</returns>
        public string BuildFilter()
        {
            return FilterStrings.DomainFilter;
        }
    }
}

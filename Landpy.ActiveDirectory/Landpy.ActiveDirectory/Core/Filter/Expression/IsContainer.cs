namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// Is container filter (Eg: (objectClass=container)).
    /// </summary>
    public class IsContainer : IFilter
    {
        /// <summary>
        /// Build the AD filter string (Eg: (objectClass=container)).
        /// </summary>
        /// <returns>The filter string.</returns>
        public string BuildFilter()
        {
            return FilterStrings.ContainerFilter;
        }
    }
}

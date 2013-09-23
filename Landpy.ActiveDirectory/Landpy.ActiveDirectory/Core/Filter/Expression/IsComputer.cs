namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// Is computer filter (Eg: (objectClass=computer)).
    /// </summary>
    public class IsComputer : IFilter
    {
        /// <summary>
        /// Build the AD filter string (Eg: (objectClass=computer)).
        /// </summary>
        /// <returns>The filter string.</returns>
        public string BuildFilter()
        {
            return FilterStrings.ComputerFilter;
        }
    }
}

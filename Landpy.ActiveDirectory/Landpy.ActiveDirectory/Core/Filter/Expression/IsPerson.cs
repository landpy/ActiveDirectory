namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// Is person filter (Eg: (objectClass=person)).
    /// </summary>
    public class IsPerson : IFilter
    {
        /// <summary>
        /// Build the AD filter string (Eg: (objectClass=person)).
        /// </summary>
        /// <returns>The filter string.</returns>
        public string BuildFilter()
        {
            return FilterStrings.PersonFilter;
        }
    }
}

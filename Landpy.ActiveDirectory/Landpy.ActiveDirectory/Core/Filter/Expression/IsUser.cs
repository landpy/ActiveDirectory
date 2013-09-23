namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// Is user filter (Eg: (objectClass=user)).
    /// </summary>
    public class IsUser : IFilter
    {
        /// <summary>
        /// Build the AD filter string (Eg: (objectClass=user)).
        /// </summary>
        /// <returns>The filter string.</returns>
        public string BuildFilter()
        {
            return FilterStrings.UserFilter;
        }
    }
}

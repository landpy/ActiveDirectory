using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Attribute.Value;

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
            IFilter filter = new Is(AttributeNames.ObjectClass, OrganizationalUnitAttributeValues.OrganizationalUnit);
            return filter.BuildFilter();
        }
    }
}

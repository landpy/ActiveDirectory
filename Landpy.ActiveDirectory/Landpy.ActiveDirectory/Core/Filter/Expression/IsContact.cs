using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Attribute.Value;

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
            IFilter filter = new And(new Is(AttributeNames.ObjectClass, ContactAttributeValues.Contact),
                new IsNot(AttributeNames.ObjectClass, ComputerAttributeValues.Computer));
            return filter.BuildFilter();
        }
    }
}

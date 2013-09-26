using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Attribute.Value;

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// Is password settings filter (Eg: (objectClass=msDs-PasswordSettings)).
    /// </summary>
    public class IsPasswordSettings : IFilter
    {
        /// <summary>
        /// Build the AD filter string (Eg: (&amp;(cn=pangxiaoliang)(mail=pang*))).
        /// </summary>
        /// <returns></returns>
        public string BuildFilter()
        {
            IFilter filter = new Is(AttributeNames.ObjectClass, PasswordSettingsAttributeValues.MsDs_PasswordSettings);
            return filter.BuildFilter();
        }
    }
}

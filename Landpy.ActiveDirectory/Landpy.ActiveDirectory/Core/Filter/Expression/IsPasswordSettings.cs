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
            return FilterStrings.PasswordSettingsFilter;
        }
    }
}

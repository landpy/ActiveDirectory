namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class IsPasswordSettings : IFilter
    {
        public string BuildFilter()
        {
            return FilterStrings.PasswordSettingsFilter;
        }
    }
}

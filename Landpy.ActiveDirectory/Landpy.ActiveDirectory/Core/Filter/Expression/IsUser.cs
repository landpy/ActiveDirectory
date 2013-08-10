namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class IsUser : IFilter
    {
        public string BuildFilter()
        {
            return FilterStrings.UserFilter;
        }
    }
}

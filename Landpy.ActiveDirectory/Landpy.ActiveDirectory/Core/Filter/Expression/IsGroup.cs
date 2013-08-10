namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class IsGroup : IFilter
    {
        public string BuildFilter()
        {
            return FilterStrings.GroupFilter;
        }
    }
}

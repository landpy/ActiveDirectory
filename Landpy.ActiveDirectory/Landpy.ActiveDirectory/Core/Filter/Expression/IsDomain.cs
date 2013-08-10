namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class IsDomain : IFilter
    {
        public string BuildFilter()
        {
            return FilterStrings.DomainFilter;
        }
    }
}

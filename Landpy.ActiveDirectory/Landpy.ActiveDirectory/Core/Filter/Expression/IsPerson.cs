namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class IsPerson : IFilter
    {
        public string BuildFilter()
        {
            return FilterStrings.PersonFilter;
        }
    }
}

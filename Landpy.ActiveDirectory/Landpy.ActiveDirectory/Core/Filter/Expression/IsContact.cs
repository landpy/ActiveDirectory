namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class IsContact : IFilter
    {
        public string BuildFilter()
        {
            return FilterStrings.ContactFilter;
        }
    }
}

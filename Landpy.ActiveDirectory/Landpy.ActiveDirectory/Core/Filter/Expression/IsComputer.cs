namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class IsComputer : IFilter
    {
        public string BuildFilter()
        {
            return FilterStrings.ComputerFilter;
        }
    }
}

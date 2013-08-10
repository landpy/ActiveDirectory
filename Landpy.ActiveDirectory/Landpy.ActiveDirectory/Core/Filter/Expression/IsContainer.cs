namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class IsContainer: IFilter
    {
        public string BuildFilter()
        {
            return FilterStrings.ContainerFilter;
        }
    }
}

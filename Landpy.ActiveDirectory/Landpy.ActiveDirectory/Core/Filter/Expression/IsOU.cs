using System;

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class IsOU : IFilter
    {
        public string BuildFilter()
        {
            return String.Format(FilterStrings.OrganizationalUnitFilter);
        }
    }
}

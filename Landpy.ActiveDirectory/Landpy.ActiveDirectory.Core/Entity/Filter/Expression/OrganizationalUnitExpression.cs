using System;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Filter
{
    class OrganizationalUnitExpression : IFilter
    {
        string IFilter.BuildFilter()
        {
            return String.Format(FilterStrings.OrganizationalUnitFilter);
        }

        void IFilter.Add(IFilter filter)
        {
            throw new NotImplementedException();
        }

        void IFilter.Remove(IFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}

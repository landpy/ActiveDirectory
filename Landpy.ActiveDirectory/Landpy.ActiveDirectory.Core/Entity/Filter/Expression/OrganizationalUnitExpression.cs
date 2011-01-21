using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.CommonParam;
using Landpy.ActiveDirectory.Core;

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

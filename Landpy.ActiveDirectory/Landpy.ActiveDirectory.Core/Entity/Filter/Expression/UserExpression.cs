using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.CommonParam;
using Landpy.ActiveDirectory.Core;

namespace Landpy.ActiveDirectory.Filter
{
    class UserExpression : IFilter
    {
        string IFilter.BuildFilter()
        {
            return String.Format(FilterStrings.UserFilter);
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

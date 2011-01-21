using System;
using Landpy.ActiveDirectory.CommonParam;

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

using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.Core;

namespace Landpy.ActiveDirectory.Filter
{
    class AllExpression : IFilter
    {
        string IFilter.BuildFilter()
        {
            return String.Empty;
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

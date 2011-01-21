using System;
using System.Collections.Generic;
using System.Text;

namespace Landpy.ActiveDirectory
{
    public interface IFilter
    {
        string BuildFilter();
        void Add(IFilter filter);
        void Remove(IFilter filter);
    }
}

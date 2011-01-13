using System;
using System.Collections.Generic;
using System.Text;

namespace Landpy.ActiveDirectory.Core
{
    public interface IFilter
    {
        string BuildFilter();
    }
}

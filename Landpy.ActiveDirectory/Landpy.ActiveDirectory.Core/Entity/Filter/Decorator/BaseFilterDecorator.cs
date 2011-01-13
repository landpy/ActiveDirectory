using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.Core;

namespace Landpy.ActiveDirectory.Entity.Filter
{
    abstract class BaseFilterDecorator : IFilter
    {
        protected IFilter filter;

        public BaseFilterDecorator()
        {
        }

        protected BaseFilterDecorator(IFilter filter)
        {
            this.filter = filter;
        }

        public abstract string BuildFilter();
    }
}

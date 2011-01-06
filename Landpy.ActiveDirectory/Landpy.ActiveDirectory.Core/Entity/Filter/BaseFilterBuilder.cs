using System;
using System.Collections.Generic;
using System.Text;

namespace Landpy.ActiveDirectory.Entity.Filter
{
    abstract class BaseFilterBuilder
    {
        private string filter;

        public string Filter
        {
            get
            {
                return filter.ToString();
            }
        }

        protected BaseFilterBuilder()
        {
        }

        protected abstract string BuildFilter();
    }
}

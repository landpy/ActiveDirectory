using System.Collections.Generic;

namespace Landpy.ActiveDirectory.Filter
{
    abstract class BaseFilter : IFilter
    {
        protected List<IFilter> filters;

        protected BaseFilter()
        {
            this.filters = new List<IFilter>();
        }

        public abstract string BuildFilter();

        void IFilter.Add(IFilter filter)
        {
            this.filters.Add(filter);
        }

        void IFilter.Remove(IFilter filter)
        {
            this.filters.Remove(filter);
        }
    }
}

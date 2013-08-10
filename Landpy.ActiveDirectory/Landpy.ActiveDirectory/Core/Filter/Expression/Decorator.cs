using System.Collections.Generic;
using System.Text;

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public abstract class Decorator : IFilter
    {
        private List<IFilter> Filters { get; set; }

        protected Decorator(params IFilter[] filters)
        {
            this.Filters = new List<IFilter>(filters);
        }

        public string BuildFilter()
        {
            var childrenFilterString = new StringBuilder();
            foreach (var filter in this.Filters)
            {
                childrenFilterString.Append(filter.BuildFilter());
            }
            return this.BuildExpresion(childrenFilterString.ToString());
        }

        protected abstract string BuildExpresion(string childrenFilterString);
    }
}

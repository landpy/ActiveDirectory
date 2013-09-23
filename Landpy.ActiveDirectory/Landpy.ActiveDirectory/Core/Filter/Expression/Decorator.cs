using System.Collections.Generic;
using System.Text;

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// The decorator pattern base class.
    /// </summary>
    public abstract class Decorator : IFilter
    {
        private List<IFilter> Filters { get; set; }

        /// <summary>
        /// The constructure with filter collection.
        /// The filter must inherit from IFilter interface.
        /// </summary>
        /// <param name="filters">The filter collection.</param>
        protected Decorator(params IFilter[] filters)
        {
            this.Filters = new List<IFilter>(filters);
        }

        /// <summary>
        /// Build the AD filter string (Eg: (&amp;(cn=pangxiaoliang)(mail=pang*))).
        /// </summary>
        /// <returns></returns>
        public string BuildFilter()
        {
            var childrenFilterString = new StringBuilder();
            foreach (var filter in this.Filters)
            {
                childrenFilterString.Append(filter.BuildFilter());
            }
            return this.BuildExpression(childrenFilterString.ToString());
        }

        /// <summary>
        /// Build the filter expression.
        /// </summary>
        /// <param name="childrenFilterString">The children filter string.</param>
        /// <returns>The filter expression.</returns>
        protected abstract string BuildExpression(string childrenFilterString);
    }
}

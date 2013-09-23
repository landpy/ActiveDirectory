using System;

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// The AD or filter (Eg: (|{0})).
    /// </summary>
    public class Or : Decorator
    {
        /// <summary>
        /// The constructure with filter collection (Eg: (|{0})).
        /// The filter must inherit from IFilter interface.
        /// </summary>
        /// <param name="filters"></param>
        public Or(params IFilter[] filters)
            : base(filters)
        {
        }

        /// <summary>
        /// Build the filter expression.
        /// </summary>
        /// <param name="childrenFilterString">The children filter string.</param>
        /// <returns>The filter expression.</returns>
        protected override string BuildExpression(string childrenFilterString)
        {
            return String.Format(ExpressionTemplates.Or, childrenFilterString);
        }
    }
}

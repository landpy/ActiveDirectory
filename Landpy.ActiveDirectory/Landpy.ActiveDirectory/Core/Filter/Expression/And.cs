using System;

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// The AD and filter (Eg: (&amp;{0})).
    /// </summary>
    public class And : Decorator
    {
        /// <summary>
        /// The constructure with filter collection param(Eg: (&amp;{0})).
        /// The filter must inherit from IFilter interface.
        /// </summary>
        /// <param name="filters">The filter collection.</param>
        public And(params IFilter[] filters)
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
            return String.Format(ExpressionTemplates.And, childrenFilterString);
        }
    }
}

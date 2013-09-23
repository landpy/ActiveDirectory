using System;

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// The base class of attricute only key filter.
    /// </summary>
    public abstract class AttributeKeyFilter : IFilter
    {
        private string AttributeName { get; set; }

        /// <summary>
        /// The constructor with attribute name param.
        /// </summary>
        /// <param name="attributeName">The attribute name which can be find in Landpy.ActiveDirectory.Entity.Attribute.Name namespace or custom set.</param>
        protected AttributeKeyFilter(string attributeName)
        {
            this.AttributeName = attributeName;
        }

        /// <summary>
        /// Build the AD filter string (Eg: (&amp;(cn=pangxiaoliang)(mail=pang*))).
        /// </summary>
        /// <returns>The filter string.</returns>
        public string BuildFilter()
        {
            return String.Format(this.BuildExpressionTemplate(), this.AttributeName);
        }

        /// <summary>
        /// Build the expression template.
        /// </summary>
        /// <returns>The expression template.</returns>
        protected abstract string BuildExpressionTemplate();
    }
}

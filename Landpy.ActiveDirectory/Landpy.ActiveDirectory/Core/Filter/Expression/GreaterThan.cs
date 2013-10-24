﻿namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// The AD less than fitler (Eg: ({0}>={1})).
    /// </summary>
    public class GreaterThan : AttributeKeyValueFilter
    {
        /// <summary>
        /// The constructure with attribute name and attribute vaule params (Eg: ({0}>={1})).
        /// </summary>
        /// <param name="attributeName">The attribute name which can be find in Landpy.ActiveDirectory.Entity.Attribute.Name namespace or custom set.</param>
        /// <param name="attributeValue">The attribute value which can be find in Landpy.ActiveDirectory.Entity.Attribute.Value namespace or custom set.</param>
        public GreaterThan(string attributeName, string attributeValue)
            : base(attributeName, attributeValue)
        {
        }

        /// <summary>
        /// Build the expression template.
        /// </summary>
        /// <returns>The expression template.</returns>
        protected override string BuildExpressionTemplate()
        {
            return ExpressionTemplates.GreaterThan;
        }
    }
}

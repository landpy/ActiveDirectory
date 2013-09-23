namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// The AD has no value filter (Eg: (!{0}=*)).
    /// </summary>
    public class HasNoValue : AttributeKeyFilter
    {
        /// <summary>
        /// The constructure with attribute name param (Eg: (!{0}=*)).
        /// </summary>
        /// <param name="attributeName">The attribute name which can be find in Landpy.ActiveDirectory.Entity.Attribute.Name namespace or custom set.</param>
        public HasNoValue(string attributeName)
            : base(attributeName)
        {
        }

        /// <summary>
        /// Build the expression template.
        /// </summary>
        /// <returns>The expression template.</returns>
        protected override string BuildExpressionTemplate()
        {
            return ExpressionTemplates.HasNoValueExpression;
        }
    }
}

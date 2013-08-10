namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class Is : AttributeKeyValueFilter
    {
        public Is(string attributeName, string attributeValue)
            : base(attributeName, attributeValue)
        {
        }

        protected override string BuildExpressionTemplate()
        {
            return ExpressionTemplates.IsExpression;
        }
    }
}

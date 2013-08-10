namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class StartWith : AttributeKeyValueFilter
    {
        public StartWith(string attributeName, string attributeValue)
            : base(attributeName, attributeValue)
        {
        }

        protected override string BuildExpressionTemplate()
        {
            return ExpressionTemplates.StartWithExpression;
        }
    }
}

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class EndWith : AttributeKeyValueFilter
    {
        public EndWith(string attributeName, string attributeValue)
            : base(attributeName, attributeValue)
        {
        }

        protected override string BuildExpressionTemplate()
        {
            return ExpressionTemplates.EndWithExpression;
        }
    }
}

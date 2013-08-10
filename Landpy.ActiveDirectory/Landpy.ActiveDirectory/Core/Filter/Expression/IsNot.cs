namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class IsNot : AttributeKeyValueFilter
    {
        public IsNot(string attributeName, string attributeValue)
            : base(attributeName, attributeValue)
        {
        }

        protected override string BuildExpressionTemplate()
        {
            return ExpressionTemplates.IsNotExpression;
        }
    }
}

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class HasNoValue : AttributeKeyFilter
    {
        public HasNoValue(string attributeName)
            : base(attributeName)
        {
        }

        protected override string BuildExpressionTemplate()
        {
            return ExpressionTemplates.HasNoValueExpression;
        }
    }
}

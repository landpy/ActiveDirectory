namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class HasAValue : AttributeKeyFilter
    {
        public HasAValue(string attributeName)
            : base(attributeName)
        {
        }

        protected override string BuildExpressionTemplate()
        {
            return ExpressionTemplates.HasAValueExpression;
        }
    }
}

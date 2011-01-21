using System.Collections.Generic;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Filter
{
    class HasAValueExpressionDecorator : BaseExpressionDecorator
    {
        public HasAValueExpressionDecorator(IFilter filter, string attributeName)
            : base(filter, attributeName)
        {
        }

        public HasAValueExpressionDecorator(IFilter filer, ICollection<string> attributeNames)
            : base(filer, attributeNames)
        {
        }

        public override string BuildFilter()
        {
            return this.BuildOneParamFilter(ExpressionTemplates.HasAValueExpression);
        }
    }
}

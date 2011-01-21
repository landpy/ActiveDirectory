using System.Collections.Generic;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Filter
{
    class HasNoValueExpressionDecorator : BaseExpressionDecorator
    {
        public HasNoValueExpressionDecorator(IFilter filter, string attributeName)
            : base(filter, attributeName)
        {
        }

        public HasNoValueExpressionDecorator(IFilter filer, ICollection<string> attributeNames)
            : base(filer, attributeNames)
        {
        }

        public override string BuildFilter()
        {
            return this.BuildOneParamFilter(ExpressionTemplates.HasNoValueExpression);
        }
    }
}

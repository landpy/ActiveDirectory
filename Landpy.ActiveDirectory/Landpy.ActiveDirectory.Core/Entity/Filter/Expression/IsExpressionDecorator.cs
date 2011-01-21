using System.Collections.Generic;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Filter
{
    class IsExpressionDecorator : BaseExpressionDecorator
    {
        public IsExpressionDecorator(IFilter filter, string attributeName, string attributeValue)
            : base(filter, attributeName, attributeValue)
        {
        }

        public IsExpressionDecorator(IFilter filter, IDictionary<string, string> attributeDictionary)
            : base(filter, attributeDictionary)
        {
        }

        public override string BuildFilter()
        {
            return this.BuildTwoParamsFilter(ExpressionTemplates.IsExpression);
        }
    }
}

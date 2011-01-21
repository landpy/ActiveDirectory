using System.Collections.Generic;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Filter
{
    class IsNotExpressionDecorator : BaseExpressionDecorator
    {
        public IsNotExpressionDecorator(IFilter filter, string attributeName, string attributeValue)
            : base(filter, attributeName, attributeValue)
        {
        }

        public IsNotExpressionDecorator(IFilter filter, IDictionary<string, string> attributeDictionary)
            : base(filter, attributeDictionary)
        {
        }

        public override string BuildFilter()
        {
            return this.BuildTwoParamsFilter(ExpressionTemplates.IsNotExpression);
        }
    }
}

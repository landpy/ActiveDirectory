using System.Collections.Generic;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Filter
{
    class EndWithExpressionDecorator : BaseExpressionDecorator
    {
        public EndWithExpressionDecorator(IFilter filter, string attributeName, string attributeValue)
            : base(filter, attributeName, attributeValue)
        {
        }

        public EndWithExpressionDecorator(IFilter filter, IDictionary<string, string> attributeDictionary)
            : base(filter, attributeDictionary)
        {
        }

        public override string BuildFilter()
        {
            return this.BuildTwoParamsFilter(ExpressionTemplates.EndWithExpression);
        }
    }
}

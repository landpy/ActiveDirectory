using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.CommonParam;
using Landpy.ActiveDirectory.Core;

namespace Landpy.ActiveDirectory.Filter
{
    class EndWithExpressionDecorator : BaseExpressionDecorator
    {
        public EndWithExpressionDecorator(IFilter filter, string attributeName, string attributeValue)
            : base(filter, attributeName, attributeValue)
        {
        }

        public override string BuildFilter()
        {
            string newExpression = String.Format(ExpressionTemplates.EndWithExpression, this.attributeName, this.attributeValue);
            return String.Format(ExpressionTemplates.Join, this.filter.BuildFilter(), newExpression);
        }
    }
}

using System;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Filter
{
    class AndExpressionDecorator : BaseExpressionDecorator
    {
        public AndExpressionDecorator(IFilter filter)
            : base(filter)
        {
        }

        public override string BuildFilter()
        {
            return String.Format(ExpressionTemplates.And, this.filter.BuildFilter());
        }
    }
}

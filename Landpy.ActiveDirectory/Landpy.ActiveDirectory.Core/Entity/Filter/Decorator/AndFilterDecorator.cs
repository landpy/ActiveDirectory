using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.CommonParam;
using Landpy.ActiveDirectory.Core;

namespace Landpy.ActiveDirectory.Entity.Filter
{
    class AndFilterDecorator : BaseFilterDecorator
    {
        public AndFilterDecorator(IFilter filter)
            : base(filter)
        {
        }

        public override string BuildFilter()
        {
            return String.Format(ExpressionTemplates.And, this.filter.BuildFilter());
        }
    }
}

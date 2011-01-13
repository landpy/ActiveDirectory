using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Entity.Filter.Decorator
{
    class OrFilterDecorator : BaseFilterDecorator
    {
        public OrFilterDecorator(IFilter filter)
            : base(filter)
        {
        }

        public override string BuildFilter()
        {
            return String.Format(ExpressionTemplates.Or, filter.BuildFilter());
        }
    }
}

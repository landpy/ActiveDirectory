using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Entity.Filter
{
    class IsFilterDecorator : BaseFilterDecorator
    {
        private string attributeName;
        private string attributeValue;

        public string AttributeName
        {
            set { this.attributeName = value; }
        }

        public string AttributeValue
        {
            set { this.attributeValue = value; }
        }

        public IsFilterDecorator(IFilter filter)
            : base(filter)
        {
        }

        public IsFilterDecorator(IFilter filter, string attributeName, string attributeValue)
            : base(filter)
        {
            this.attributeName = attributeName;
            this.attributeValue = attributeValue;
        }

        public override string BuildFilter()
        {
            string newExpression = String.Format(ExpressionTemplates.IsExpression, this.attributeName, this.attributeValue);
            return String.Format(ExpressionTemplates.Join, this.filter.BuildFilter(), newExpression);
        }
    }
}

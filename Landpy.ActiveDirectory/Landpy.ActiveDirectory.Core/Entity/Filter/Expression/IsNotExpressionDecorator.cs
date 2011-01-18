using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.CommonParam;
using Landpy.ActiveDirectory.Exception;

namespace Landpy.ActiveDirectory.Entity.Filter
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
            string newExpression = String.Empty;
            bool isSingleAttribute = (!String.IsNullOrEmpty(this.attributeName) && !String.IsNullOrEmpty(this.attributeValue));
            bool isCollectionAttribute = (attributeDictionary != null && attributeDictionary.Count != 0);
            if (isSingleAttribute)
            {
                newExpression = String.Format(ExpressionTemplates.IsNotExpression, this.attributeName, this.attributeValue);
            }
            else if (isCollectionAttribute)
            {
                StringBuilder filterStringBuilder = new StringBuilder();
                foreach (string key in this.attributeDictionary.Keys)
                {
                    string expression = String.Format(ExpressionTemplates.IsNotExpression, key, this.attributeDictionary[key]);
                    filterStringBuilder.Append(expression);
                }
                newExpression = filterStringBuilder.ToString();
            }
            else
            {
                throw new DataMissingException("(AttributeName, AttributeValue) or (AttributeDictionary).");
            }
            return String.Format(ExpressionTemplates.Join, this.filter.BuildFilter(), newExpression);
        }
    }
}

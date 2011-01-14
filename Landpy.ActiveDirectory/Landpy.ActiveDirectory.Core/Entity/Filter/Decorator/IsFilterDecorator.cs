using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.CommonParam;
using Landpy.ActiveDirectory.Exception;

namespace Landpy.ActiveDirectory.Entity.Filter
{
    class IsFilterDecorator : BaseFilterDecorator
    {
        private string attributeName;
        private string attributeValue;
        private IDictionary<string, string> attributeDictionary;

        public string AttributeName
        {
            set { this.attributeName = value; }
        }

        public string AttributeValue
        {
            set { this.attributeValue = value; }
        }

        public IDictionary<string, string> AttributeDictionary
        {
            set { this.attributeDictionary = value; }
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

        public IsFilterDecorator(IFilter filter, IDictionary<string, string> attributeDictionary)
            : base(filter)
        {
            this.attributeDictionary = attributeDictionary;
        }

        public override string BuildFilter()
        {
            string newExpression = String.Empty;
            bool isSingleAttribute = (!String.IsNullOrEmpty(this.attributeName) && !String.IsNullOrEmpty(this.attributeValue));
            bool isCollectionAttribute = (attributeDictionary != null && attributeDictionary.Count != 0);
            if (isSingleAttribute)
            {
                newExpression = String.Format(ExpressionTemplates.IsExpression, this.attributeName, this.attributeValue);
            }
            else if (isCollectionAttribute)
            {
                StringBuilder filterStringBuilder = new StringBuilder();
                foreach (string key in this.attributeDictionary.Keys)
                {
                    string expression = String.Format(ExpressionTemplates.IsExpression, key, this.attributeDictionary[key]);
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

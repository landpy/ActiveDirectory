using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.CommonParam;
using Landpy.ActiveDirectory.Exception;

namespace Landpy.ActiveDirectory.Filter
{
    abstract class BaseExpressionDecorator : IFilter
    {
        protected IFilter filter;
        protected string attributeName;
        protected string attributeValue;
        protected IDictionary<string, string> attributeDictionary;
        protected ICollection<string> attributeNames;

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

        public ICollection<string> AttributeNames
        {
            set { this.attributeNames = value; }
        }

        public BaseExpressionDecorator()
        {
        }

        protected BaseExpressionDecorator(IFilter filter)
        {
            this.filter = filter;
        }

        protected BaseExpressionDecorator(IFilter filter, string attributeName)
            : this(filter)
        {
            this.AttributeName = attributeName;
        }

        protected BaseExpressionDecorator(IFilter filter, string attributeName, string attributeValue)
            : this(filter, attributeName)
        {
            this.attributeValue = attributeValue;
        }

        protected BaseExpressionDecorator(IFilter filter, IDictionary<string, string> attributeDictionary)
            : this(filter)
        {
            this.attributeDictionary = attributeDictionary;
        }

        protected BaseExpressionDecorator(IFilter filter, ICollection<string> attributeNames)
            : this(filter)
        {
            this.attributeNames = attributeNames;
        }

        public abstract string BuildFilter();

        protected string BuildTwoParamsFilter(string expressionTemplate)
        {
            string newExpression = String.Empty;
            bool isSingleAttribute = (!String.IsNullOrEmpty(this.attributeName) && !String.IsNullOrEmpty(this.attributeValue));
            bool isCollectionAttribute = (attributeDictionary != null && attributeDictionary.Count != 0);
            if (isSingleAttribute)
            {
                newExpression = String.Format(expressionTemplate, this.attributeName, this.attributeValue);
            }
            else if (isCollectionAttribute)
            {
                StringBuilder filterStringBuilder = new StringBuilder();
                foreach (string key in this.attributeDictionary.Keys)
                {
                    string expression = String.Format(expressionTemplate, key, this.attributeDictionary[key]);
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

        protected string BuildOneParamFilter(string expressionTemplate)
        {
            string newExpression = String.Empty;
            bool isSingleAttribute = (!String.IsNullOrEmpty(this.attributeName) && !String.IsNullOrEmpty(this.attributeValue));
            bool isCollectionAttribute = (attributeDictionary != null && attributeDictionary.Count != 0);
            if (isSingleAttribute)
            {
                newExpression = String.Format(expressionTemplate, this.attributeName);
            }
            else if (isCollectionAttribute)
            {
                StringBuilder filterStringBuilder = new StringBuilder();
                foreach (string attributeName in this.attributeNames)
                {
                    string expression = String.Format(expressionTemplate, attributeName);
                    filterStringBuilder.Append(expression);
                }
                newExpression = filterStringBuilder.ToString();
            }
            else
            {
                throw new DataMissingException("(AttributeName) or (AttributeNames).");
            }
            return String.Format(ExpressionTemplates.Join, this.filter.BuildFilter(), newExpression);
        }

        void IFilter.Add(IFilter filter)
        {
            throw new NotImplementedException();
        }

        void IFilter.Remove(IFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}

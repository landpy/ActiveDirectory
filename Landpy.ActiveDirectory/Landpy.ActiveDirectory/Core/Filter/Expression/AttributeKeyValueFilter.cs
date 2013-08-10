using System;
namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public abstract class AttributeKeyValueFilter : IFilter
    {
        private string AttributeName { get; set; }
        private string AttributeValue { get; set; }

        protected AttributeKeyValueFilter(string attributeName, string attributeValue)
        {
            this.AttributeName = attributeName;
            this.AttributeValue = attributeValue;
        }

        public string BuildFilter()
        {
            return String.Format(this.BuildExpressionTemplate(), this.AttributeName, this.AttributeValue);
        }

        protected abstract string BuildExpressionTemplate();
    }
}

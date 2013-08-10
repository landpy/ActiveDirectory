using System;

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public abstract class AttributeKeyFilter : IFilter
    {
        private string AttributeName { get; set; }

        protected AttributeKeyFilter(string attributeName)
        {
            this.AttributeName = attributeName;
        }

        public string BuildFilter()
        {
            return String.Format(this.BuildExpressionTemplate(), this.AttributeName);
        }

        protected abstract string BuildExpressionTemplate();
    }
}

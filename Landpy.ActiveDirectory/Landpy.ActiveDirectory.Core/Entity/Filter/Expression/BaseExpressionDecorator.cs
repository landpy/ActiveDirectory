using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.Core;

namespace Landpy.ActiveDirectory.Entity.Filter
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

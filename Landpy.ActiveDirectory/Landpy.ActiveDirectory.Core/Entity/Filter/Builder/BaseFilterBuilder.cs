using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.CommonParam;
using Landpy.ActiveDirectory.Core;

namespace Landpy.ActiveDirectory.Entity.Filter
{
    abstract class BaseFilterBuilder : IFilter
    {
        public abstract string BuildFilter();

        protected string Is(string attributeName, string attributeValue)
        {
            return String.Format(ExpressionTemplates.IsExpression, attributeName, attributeValue);
        }

        protected string IsNot(string attributeName, string attributeValue)
        {
            return String.Format(ExpressionTemplates.IsNotExpression, attributeName, attributeValue);
        }

        protected string StartWith(string attributeName, string attributeValue)
        {
            return String.Format(ExpressionTemplates.StartWithExpression, attributeName, attributeValue);
        }

        protected string EndWith(string attributeName, string attributeValue)
        {
            return String.Format(ExpressionTemplates.EndWithExpression, attributeName, attributeValue);
        }

        protected string HasValue(string attriubteName)
        {
            return String.Format(ExpressionTemplates.HasAValueExpression, attriubteName);
        }

        protected string HasNoValue(string attributeName)
        {
            return String.Format(ExpressionTemplates.HasNoValueExpression, attributeName);
        }

        protected string And(params string[] expressions)
        {
            StringBuilder filter = new StringBuilder();
            filter.AppendFormat("({0}", ExpressionTemplates.And);
            foreach (string expression in expressions)
            {
                filter.AppendFormat("({0})", expression);
            }
            filter.Append(")");
            return filter.ToString();
        }

        protected string Or(params string[] expressions)
        {
            StringBuilder filter = new StringBuilder();
            filter.AppendFormat("({0}", ExpressionTemplates.Or);
            foreach (string expression in expressions)
            {
                filter.AppendFormat("({0})", expression);
            }
            filter.Append(")");
            return filter.ToString();
        }

        string IFilter.BuildFilter()
        {
            throw new NotImplementedException();
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

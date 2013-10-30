using System;
using Landpy.ActiveDirectory.Entity.Attribute.Name;

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// The base class of attricute key and value filter.
    /// </summary>
    public abstract class AttributeKeyValueFilter : IFilter
    {
        private string AttributeName { get; set; }
        private string AttributeValue { get; set; }

        /// <summary>
        /// The constructure with attribute name and attribute vaule params.
        /// </summary>
        /// <param name="attributeName">The attribute name which can be find in Landpy.ActiveDirectory.Entity.Attribute.Name namespace or custom set.</param>
        /// <param name="attributeValue">The attribute value which can be find in Landpy.ActiveDirectory.Entity.Attribute.Value namespace or custom set.</param>
        protected AttributeKeyValueFilter(string attributeName, string attributeValue)
        {
            this.AttributeName = attributeName;
            if (attributeName.Equals(AttributeNames.ObjectGuid, StringComparison.CurrentCultureIgnoreCase))
            {
                this.AttributeValue = GuidHexConvertor.Convert(new Guid(attributeValue));
            }
            else
            {
                this.AttributeValue = attributeValue.Replace(@"\", @"\5c").Replace(@"*", @"\2a").Replace(@"(", @"\28").Replace(@")", @"\29").Replace(@"/", @"\2f");
            }
        }

        /// <summary>
        /// Build the AD filter string (Eg: (&amp;(cn=pangxiaoliang)(mail=pang*))).
        /// </summary>
        /// <returns>The filter string.</returns>
        public string BuildFilter()
        {
            return String.Format(this.BuildExpressionTemplate(), this.AttributeName, this.AttributeValue);
        }

        /// <summary>
        /// Build the expression template.
        /// </summary>
        /// <returns>The expression template.</returns>
        protected abstract string BuildExpressionTemplate();
    }
}

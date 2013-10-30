using System;
using Landpy.ActiveDirectory.Entity.Attribute.Name;

namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    /// <summary>
    /// The AD custom filter, you can add native fitler string.
    /// </summary>
    public class Custom : IFilter
    {
        private string FilterString { get; set; }

        /// <summary>
        ///  The constructure with native fitler string param.
        /// </summary>
        /// <param name="filterString">The native filter string.</param>
        public Custom(string filterString)
        {
            if (filterString.IndexOf(AttributeNames.ObjectGuid, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                string hexFilterString = filterString;
                string[] filterSections = filterString.Split(new char[] { '(', ')' });
                foreach (var filterSection in filterSections)
                {
                    if (filterSection.IndexOf(AttributeNames.ObjectGuid, StringComparison.CurrentCultureIgnoreCase) != -1)
                    {
                        string hexFilterSection = String.Format(@"{0}{1}", filterSection.Substring(0, 11), GuidHexConvertor.Convert(new Guid(filterSection.Substring(11))));
                        hexFilterString = hexFilterString.Replace(filterSection, hexFilterSection);
                    }
                }
                this.FilterString = hexFilterString;
            }
            else
            {
                this.FilterString = filterString;
            }
        }

        /// <summary>
        /// Build the AD native filter string.
        /// </summary>
        /// <returns>The native filter string.</returns>
        public string BuildFilter()
        {
            return String.Format(ExpressionTemplates.Parenthesis, this.FilterString);
        }
    }
}

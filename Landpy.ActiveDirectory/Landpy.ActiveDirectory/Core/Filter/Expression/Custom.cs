namespace Landpy.ActiveDirectory.Core.Filter.Expression
{
    public class Custom : IFilter
    {
        private string FilterString { get; set; }

        /// <summary>
        ///  The AD custom filter, you can add native fitler string.
        /// </summary>
        /// <param name="filterString">The native filter string.</param>
        public Custom(string filterString)
        {
            this.FilterString = filterString;
        }

        /// <summary>
        /// Build the AD native filter string.
        /// </summary>
        /// <returns>The native filter string.</returns>
        public string BuildFilter()
        {
            return this.FilterString;
        }
    }
}

using System.DirectoryServices;
using System;

namespace Landpy.ActiveDirectory.Entity.TypeAdapter
{
    class SingleLineAdapter : StringAdapter
    {
        public SingleLineAdapter(ResultPropertyValueCollection resultPropertyValueCollection)
            : base(resultPropertyValueCollection)
        {
            if (this.ResultPropertyValueCollection.Count == 0)
            {
                this.Value = String.Empty;
            }
            else
            {
                this.Value = this.ResultPropertyValueCollection[0].ToString();
            }
        }

        public SingleLineAdapter(SearchResult searchResult, string propertyName)
            : base(searchResult, propertyName)
        {
            using (var directoryEntry = searchResult.GetDirectoryEntry())
            {
                directoryEntry.RefreshCache(new string[] { propertyName });
                if (directoryEntry.Properties[propertyName].Count == 0)
                {
                    this.Value = String.Empty;
                }
                else
                {
                    this.Value = directoryEntry.Properties[propertyName].Value.ToString();
                }
            }
        }
    }
}

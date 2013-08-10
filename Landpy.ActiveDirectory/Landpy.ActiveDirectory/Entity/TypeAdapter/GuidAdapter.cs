using System;
using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Entity.TypeAdapter
{
    class GuidAdapter : IGuid
    {
        public Guid Value { get; private set; }

        public GuidAdapter(ResultPropertyValueCollection resultPropertyValueCollection)
        {
            if (resultPropertyValueCollection.Count == 0)
            {
                this.Value = Guid.Empty;
            }
            else
            {
                this.Value = new Guid(resultPropertyValueCollection[0] as byte[]);
            }
        }

        public GuidAdapter(SearchResult searchResult, string propertyName)
        {
            using (var directoryEntry = searchResult.GetDirectoryEntry())
            {
                directoryEntry.RefreshCache(new string[] { propertyName });
                if (directoryEntry.Properties[propertyName].Count == 0)
                {
                    this.Value = Guid.Empty;
                }
                else
                {
                    this.Value = new Guid(directoryEntry.Properties[propertyName].Value.ToString());
                }
            }
        }
    }
}

using System.DirectoryServices;
using System.Security.Principal;
using System;

namespace Landpy.ActiveDirectory.Entity.TypeAdapter
{
    class SidAdapter : StringAdapter
    {
        public SidAdapter(ResultPropertyValueCollection resultPropertyValueCollection)
            : base(resultPropertyValueCollection)
        {
            if (this.ResultPropertyValueCollection.Count == 0)
            {
                this.Value = String.Empty;
            }
            else
            {
                this.Value = new SecurityIdentifier(this.ResultPropertyValueCollection[0] as byte[], 0).ToString();
            }
        }

        public SidAdapter(SearchResult searchResult, string propertyName)
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
                    this.Value = new SecurityIdentifier(directoryEntry.Properties[propertyName].Value as byte[], 0).ToString();
                }
            }
        }
    }
}

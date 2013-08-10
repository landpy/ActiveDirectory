using System.Collections.Generic;
using System.DirectoryServices;
using System.Security.Principal;

namespace Landpy.ActiveDirectory.Entity.TypeAdapter
{
    class SidsAdapter : IStringList
    {
        public IList<string> Value { get; private set; }

        public SidsAdapter(SearchResult searchResult, string propertyName)
        {
            using (var directoryEntry = searchResult.GetDirectoryEntry())
            {
                directoryEntry.RefreshCache(new string[] { propertyName });
                if (directoryEntry.Properties[propertyName].Count == 0)
                {
                    this.Value = null;
                }
                else
                {
                    this.Value = new List<string>();
                    foreach (var resultPropertyValue in directoryEntry.Properties[propertyName])
                    {
                        this.Value.Add(new SecurityIdentifier(resultPropertyValue as byte[], 0).ToString());
                    }
                }
            }
        }
    }
}

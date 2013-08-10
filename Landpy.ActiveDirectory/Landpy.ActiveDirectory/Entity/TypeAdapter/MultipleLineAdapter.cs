using System.Collections.Generic;
using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Entity.TypeAdapter
{
    class MultipleLineAdapter : IStringList
    {
        public IList<string> Value { get; private set; }

        public MultipleLineAdapter(ResultPropertyValueCollection resultPropertyValueCollection)
        {
            if (resultPropertyValueCollection.Count == 0)
            {
                this.Value = null;
            }
            else
            {
                this.Value = new List<string>();
                foreach (var resultPropertyValue in resultPropertyValueCollection)
                {
                    this.Value.Add(resultPropertyValue.ToString());
                }
            }
        }

        public MultipleLineAdapter(SearchResult searchResult, string propertyName)
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
                        this.Value.Add(resultPropertyValue.ToString());
                    }
                }
            }
        }
    }
}

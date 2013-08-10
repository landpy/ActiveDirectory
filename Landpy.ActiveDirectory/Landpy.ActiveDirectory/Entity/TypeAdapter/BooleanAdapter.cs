using System;
using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Entity.TypeAdapter
{
    class BooleanAdapter : IBoolean
    {
        public bool Value { get; private set; }

        public BooleanAdapter(ResultPropertyValueCollection resultPropertyValueCollection)
        {
            if (resultPropertyValueCollection.Count == 0)
            {
                this.Value = false;
            }
            else
            {
                this.Value = Boolean.Parse(resultPropertyValueCollection[0].ToString());
            }
        }

        public BooleanAdapter(SearchResult searchResult, string propertyName)
        {
            using (var directoryEntry = searchResult.GetDirectoryEntry())
            {
                directoryEntry.RefreshCache(new string[] { propertyName });
                if (directoryEntry.Properties[propertyName].Count == 0)
                {
                    this.Value = false;
                }
                else
                {
                    this.Value = Boolean.Parse(directoryEntry.Properties[propertyName].Value.ToString());
                }
            }
        }
    }
}

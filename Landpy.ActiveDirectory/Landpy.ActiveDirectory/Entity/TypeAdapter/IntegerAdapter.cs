using System;
using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Entity.TypeAdapter
{
    class IntegerAdapter : IInteger
    {
        public int Value { get; private set; }

        public IntegerAdapter(ResultPropertyValueCollection resultPropertyValueCollection)
        {
            if (resultPropertyValueCollection.Count == 0)
            {
                this.Value = -1;
            }
            else
            {
                this.Value = Int32.Parse(resultPropertyValueCollection[0].ToString());
            }
        }

        public IntegerAdapter(SearchResult searchResult, string propertyName)
        {
            using (var directoryEntry = searchResult.GetDirectoryEntry())
            {
                directoryEntry.RefreshCache(new string[] { propertyName });
                if (directoryEntry.Properties[propertyName].Count == 0)
                {
                    this.Value = -1;
                }
                else
                {
                    this.Value = Int32.Parse(directoryEntry.Properties[propertyName].Value.ToString());
                }
            }
        }
    }
}

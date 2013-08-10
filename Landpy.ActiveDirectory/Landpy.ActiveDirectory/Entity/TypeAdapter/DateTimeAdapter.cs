using System;
using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Entity.TypeAdapter
{
    class DateTimeAdapter : IDateTime
    {
        public DateTime Value { get; private set; }

        public DateTimeAdapter(ResultPropertyValueCollection resultPropertyValueCollection)
        {
            if (resultPropertyValueCollection.Count == 0)
            {
                this.Value = DateTime.MinValue;
            }
            else
            {
                this.Value = (DateTime)resultPropertyValueCollection[0];
            }
        }

        public DateTimeAdapter(SearchResult searchResult, string propertyName)
        {
            using (var directoryEntry = searchResult.GetDirectoryEntry())
            {
                directoryEntry.RefreshCache(new string[] { propertyName });
                if (directoryEntry.Properties[propertyName].Count == 0)
                {
                    this.Value = DateTime.MinValue;
                }
                else
                {
                    this.Value = (DateTime)directoryEntry.Properties[propertyName].Value;
                }
            }
        }
    }
}

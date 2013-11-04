using System;
using System.DirectoryServices;
using System.Reflection;

namespace Landpy.ActiveDirectory.Entity.TypeAdapter
{
    class LargeIntegerAdapter : ILargeInteger
    {
        public DateTime Value { get; private set; }

        public LargeIntegerAdapter(ResultPropertyValueCollection resultPropertyValueCollection)
        {
            if (resultPropertyValueCollection.Count == 0)
            {
                this.Value = DateTime.MinValue;
            }
            else
            {
                var accountExpires = (Int64)resultPropertyValueCollection[0];
                if (!accountExpires.Equals(Int64.MaxValue))
                {
                    this.Value = DateTime.FromFileTimeUtc(accountExpires);
                }
            }
        }

        public LargeIntegerAdapter(SearchResult searchResult, string propertyName)
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
                    var accountExpires = (Int64)searchResult.Properties[propertyName][0];
                    if (!accountExpires.Equals(Int64.MaxValue))
                    {
                        this.Value = DateTime.FromFileTimeUtc(accountExpires);
                    }
                }
            }
        }
    }
}

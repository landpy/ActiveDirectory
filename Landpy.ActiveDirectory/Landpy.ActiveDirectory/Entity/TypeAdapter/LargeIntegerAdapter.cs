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
                this.Value = this.LongFromLargeInteger(resultPropertyValueCollection[0]);
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
                    this.Value = this.LongFromLargeInteger(directoryEntry.Properties[propertyName].Value);
                }
            }
        }

        private DateTime LongFromLargeInteger(object largeInteger)
        {
            Type type = largeInteger.GetType();
            int highPart = (int)type.InvokeMember("HighPart", BindingFlags.GetProperty, null, largeInteger, null);
            int lowPart = (int)type.InvokeMember("LowPart", BindingFlags.GetProperty, null, largeInteger, null);
            DateTime lastSetDate = DateTime.FromFileTime((((long)(highPart) << 32) + lowPart));
            return lastSetDate;
        }
    }
}

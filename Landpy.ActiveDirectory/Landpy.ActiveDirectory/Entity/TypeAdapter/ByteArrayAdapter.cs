using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Entity.TypeAdapter
{
    class ByteArrayAdapter : IByteArray
    {
        public byte[] Value { get; private set; }

        public ByteArrayAdapter(ResultPropertyValueCollection resultPropertyValueCollection)
        {
            if (resultPropertyValueCollection.Count == 0)
            {
                this.Value = null;
            }
            else
            {
                this.Value = resultPropertyValueCollection[0] as byte[];                
            }
        }

        public ByteArrayAdapter(SearchResult searchResult, string propertyName)
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
                    this.Value = directoryEntry.Properties[propertyName].Value as byte[];
                }
            }
        }
    }
}

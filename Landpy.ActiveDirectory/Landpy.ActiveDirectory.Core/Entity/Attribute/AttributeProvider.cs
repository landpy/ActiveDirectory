using System;
using System.DirectoryServices;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Entity.Attribute
{
    public class AttributeProvider
    {
        private SearchResult searchResult;

        public AttributeProvider(SearchResult searchResult)
        {
            this.searchResult = searchResult;
        }

        public  BaseAttribute<byte[]> GetSidAttribute()
        {
            return new ByteAttribute(this.searchResult.Properties[AttributeNames.ObjectSid]);
        }

        public BaseAttribute<Guid> GetGuidAttribute()
        {
            return new GuidAttribute(this.searchResult.Properties[AttributeNames.ObjectGUID]);
        }

        public BaseAttribute<string> GetCNAttribute()
        {
            return new SingleLineAttribute(this.searchResult.Properties[AttributeNames.CN]);
        }

        public BaseAttribute<byte[]> GetThumbnailPhotoAttribute()
        {
            return new ByteAttribute(this.searchResult.Properties[AttributeNames.ThumbnailPhoto]);
        }
    }
}

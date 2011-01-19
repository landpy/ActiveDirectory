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

        public BaseAttribute GetSidAttribute()
        {
            return new ByteAttribute(this.searchResult.Properties[AttributeNames.ObjectSid]);
        }

        public BaseAttribute GetGuidAttribute()
        {
            return new GuidAttribute(this.searchResult.Properties[AttributeNames.ObjectGUID]);
        }

        public BaseAttribute GetCNAttribute()
        {
            return new SingleLineAttribute(this.searchResult.Properties[AttributeNames.CN]);
        }

        public BaseAttribute GetThumbnailPhotoAttribute()
        {
            return new ByteAttribute(this.searchResult.Properties[AttributeNames.ThumbnailPhoto]);
        }

        public BaseAttribute GetDistinguishedNameAttribute()
        {
            return new SingleLineAttribute(this.searchResult.Properties[AttributeNames.DistinguishedName]);
        }

        public BaseAttribute GetNameAttribute()
        {
            return new SingleLineAttribute(this.searchResult.Properties[AttributeNames.Name]);
        }
    }
}

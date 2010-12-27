using System;
using System.DirectoryServices;
using Landpy.ActiveDirectory.Entity.Attribute;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Entity
{
    class OrganizationalUnit : BaseADObject
    {
        public OrganizationalUnit(SearchResult searchResult)
            : base(searchResult)
        {
        }

        /// <summary>
        /// The objectGUID attribute.
        /// </summary>
        public Guid ObjectGUID
        {
            get
            {
                BaseAttribute<Guid> guidAttribute = this.attributeProvider.GetGuidAttribute();
                return guidAttribute.Value;
            }
        }

        /// <summary>
        /// The cn attribute.
        /// </summary>
        public string CN
        {
            get
            {
                BaseAttribute<string> cnAttribute = this.attributeProvider.GetCNAttribute();
                return cnAttribute.Value;
            }
        }

        /// <summary>
        /// The thumbnailPhoto attribute.
        /// </summary>
        public byte[] ThumbnailPhoto
        {
            get
            {
                BaseAttribute<byte[]> thumbnailPhotoAttribute = this.attributeProvider.GetThumbnailPhotoAttribute();
                return thumbnailPhotoAttribute.Value;
            }
        }
    }
}

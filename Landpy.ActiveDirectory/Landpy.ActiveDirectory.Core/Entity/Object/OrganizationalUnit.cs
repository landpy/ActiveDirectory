using System;
using System.DirectoryServices;
using System.Collections.Generic;
using Landpy.ActiveDirectory.Entity.Attribute;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Entity.Object
{
    public class OrganizationalUnit : BaseADObject
    {
        public OrganizationalUnit(SearchResult searchResult, OperatorSecurity operatorSecurity)
            : base(searchResult, operatorSecurity)
        {
        }

        /// <summary>
        /// The objectGUID attribute.
        /// </summary>
        public Guid ObjectGUID
        {
            get
            {
                BaseAttribute guidAttribute = this.attributeProvider.GetGuidAttribute();
                return (Guid)guidAttribute.Value;
            }
        }

        /// <summary>
        /// The cn attribute.
        /// </summary>
        public string CN
        {
            get
            {
                BaseAttribute cnAttribute = this.attributeProvider.GetCNAttribute();
                return cnAttribute.Value.ToString();
            }
        }

        /// <summary>
        /// The thumbnailPhoto attribute.
        /// </summary>
        public byte[] ThumbnailPhoto
        {
            get
            {
                BaseAttribute thumbnailPhotoAttribute = this.attributeProvider.GetThumbnailPhotoAttribute();
                return thumbnailPhotoAttribute.Value as byte[];
            }
        }

        public string Name
        {
            get
            {
                BaseAttribute nameAttribute = this.attributeProvider.GetNameAttribute();
                return nameAttribute.Value.ToString();
            }
        }

        //public ICollection<User> Users
        //{
        //    get
        //    {

        //    }
        //}
    }
}

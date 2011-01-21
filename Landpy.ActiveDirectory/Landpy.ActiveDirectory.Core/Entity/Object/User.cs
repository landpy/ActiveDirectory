using System;
using System.DirectoryServices;
using System.Security.Principal;
using Landpy.ActiveDirectory.Attribute;
using Landpy.ActiveDirectory.CommonParam;
using Landpy.ActiveDirectory.Filter;

namespace Landpy.ActiveDirectory.Object
{
    /// <summary>
    /// The user AD object.
    /// </summary>
    public class User : BaseADObject
    {
        public User(SearchResult searchResult, OperatorSecurity operatorSecurity)
            : base(searchResult, operatorSecurity)
        {
        }

        private string objectSid;
        private Guid objectGUID;
        private string cn;
        private byte[] thumbnailPhoto;
        private string distinguishedName;
        private OrganizationalUnit organizationalUnit;

        /// <summary>
        /// The objectSid attribute.
        /// </summary>
        public string ObjectSid
        {
            get
            {
                if (String.IsNullOrEmpty(this.objectSid))
                {
                    BaseAttribute sidAttribute = this.attributeProvider.GetSidAttribute();
                    if (sidAttribute.Value != null)
                    {
                        this.objectSid = new SecurityIdentifier(sidAttribute.Value as byte[], 0).ToString();
                    }
                }
                return this.objectSid;
            }
            set
            {
                this.objectSid = value;
            }
        }

        /// <summary>
        /// The objectGUID attribute.
        /// </summary>
        public Guid ObjectGUID
        {
            get
            {
                if (this.objectGUID == Guid.Empty)
                {
                    BaseAttribute guidAttribute = this.attributeProvider.GetGuidAttribute();
                    this.objectGUID = (Guid)guidAttribute.Value;
                }
                return this.objectGUID;
            }
            set
            {
                this.objectGUID = value;
            }
        }

        /// <summary>
        /// The cn attribute.
        /// </summary>
        public string CN
        {
            get
            {
                if (String.IsNullOrEmpty(this.cn))
                {
                    BaseAttribute cnAttribute = this.attributeProvider.GetCNAttribute();
                    this.cn = cnAttribute.Value.ToString();
                }
                return this.cn;
            }
            set
            {
                this.cn = value;
            }
        }

        /// <summary>
        /// The thumbnailPhoto attribute.
        /// </summary>
        public byte[] ThumbnailPhoto
        {
            get
            {
                if (this.thumbnailPhoto == null)
                {
                    BaseAttribute thumbnailPhotoAttribute = this.attributeProvider.GetThumbnailPhotoAttribute();
                    this.thumbnailPhoto = thumbnailPhotoAttribute.Value as byte[];
                }
                return this.thumbnailPhoto;
            }
            set
            {
                this.thumbnailPhoto = value;
            }
        }

        public string DistinguishedName
        {
            get
            {
                if (String.IsNullOrEmpty(this.distinguishedName))
                {
                    BaseAttribute distinguishedNameAttribute = this.attributeProvider.GetDistinguishedNameAttribute();
                    this.distinguishedName = distinguishedNameAttribute.Value.ToString();
                }
                return this.distinguishedName;
            }
        }

        public OrganizationalUnit OrganizationalUnit
        {
            get
            {
                string ouDN = this.DistinguishedName.Substring(this.DistinguishedName.IndexOf(',') + 1);
                IADObjectReader<OrganizationalUnit> adObjectReader = new ADObjectReader<OrganizationalUnit>(this.operatorSecurity);
                IFilter filter = new OrganizationalUnitExpression();
                filter = new IsExpressionDecorator(filter, AttributeNames.DistinguishedName, ouDN);
                filter = new AndExpressionDecorator(filter);
                return adObjectReader.ReadADObjectByFilter(filter);
            }
        }
    }
}

using System.Collections.Generic;
using System.DirectoryServices;
using System;
using System.Linq;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Attribute.Value;
using Landpy.ActiveDirectory.Entity.TypeAdapter;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The basic class of the AD object.
    /// </summary>
    public abstract class ADObject : IDisposable
    {
        private DirectoryEntry directoryEntry;
        private string cn;
        private Guid objectGuid;
        private string distinguishedName;
        private string name;
        private string canonicalName;
        private DateTime createTime;
        private DateTime modifyTime;
        private string description;
        private IList<string> directReports;
        private string displayName;
        private string msDS_PrincipalName;
        private string office;
        private string zipOrPostalCode;
        private IList<string> postOfficeBoxs;
        private string webPage;
        private IList<string> otherWebPages;

        /// <summary>
        /// The SearchResult.
        /// </summary>
        protected SearchResult SearchResult { get; private set; }

        /// <summary>
        /// The DirectoryEntry.
        /// </summary>
        protected DirectoryEntry DirectoryEntry
        {
            get { return directoryEntry ?? (directoryEntry = this.SearchResult.GetDirectoryEntry()); }
        }

        /// <summary>
        /// The AD operator.
        /// </summary>
        protected IADOperator ADOperator { get; private set; }

        /// <summary>
        /// The path of the directory entry.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// The AD object type.
        /// </summary>
        public ADObjectType Type { get; private set; }

        /// <summary>
        /// The cn attribute.
        /// </summary>
        public string CN
        {
            get
            {
                if (String.IsNullOrEmpty(this.cn))
                {
                    this.cn = new SingleLineAdapter(this.SearchResult.Properties[AttributeNames.CN]).Value;
                }
                return this.cn;
            }
        }

        /// <summary>
        /// The object guid attribute.
        /// </summary>
        public Guid ObjectGuid
        {
            get
            {
                if (this.objectGuid == Guid.Empty)
                {
                    this.objectGuid = new GuidAdapter(this.SearchResult.Properties[AttributeNames.ObjectGuid]).Value;
                }
                return this.objectGuid;
            }
        }

        /// <summary>
        /// The distinguished name attribute.
        /// </summary>
        public string DistinguishedName
        {
            get
            {
                if (String.IsNullOrEmpty(this.distinguishedName))
                {
                    this.distinguishedName =
                        new SingleLineAdapter(this.SearchResult.Properties[AttributeNames.DistinguishedName]).Value;
                }
                return this.distinguishedName;
            }
        }

        /// <summary>
        /// The full name.
        /// </summary>
        public string Name
        {
            get
            {
                if (String.IsNullOrEmpty(this.name))
                {
                    this.name = new SingleLineAdapter(this.SearchResult.Properties[AttributeNames.Name]).Value;
                }
                return this.name;
            }
        }

        /// <summary>
        /// The canonical name.
        /// </summary>
        public string CanonicalName
        {
            get
            {
                if (String.IsNullOrEmpty(this.canonicalName))
                {
                    this.canonicalName = new SingleLineAdapter(this.SearchResult, AttributeNames.CanonicalName).Value;
                }
                return this.canonicalName;
            }
        }

        /// <summary>
        /// The create time.
        /// </summary>
        public DateTime CreateTime
        {
            get
            {
                if (this.createTime == DateTime.MinValue)
                {
                    this.createTime = new DateTimeAdapter(this.SearchResult, AttributeNames.CreateTimeStamp).Value;
                }
                return this.createTime;
            }
        }

        /// <summary>
        /// The modify time.
        /// </summary>
        public DateTime ModifyTime
        {
            get
            {
                if (this.modifyTime == DateTime.MinValue)
                {
                    this.modifyTime = new DateTimeAdapter(this.SearchResult, AttributeNames.ModifyTimeStamp).Value;
                }
                return this.modifyTime;
            }
        }

        /// <summary>
        /// The description.
        /// </summary>
        public string Description
        {
            get
            {
                if (String.IsNullOrEmpty(this.description))
                {
                    this.description =
                        new SingleLineAdapter(this.SearchResult.Properties[AttributeNames.Description]).Value;
                }
                return this.description;
            }
            set
            {
                this.DirectoryEntry.Properties[AttributeNames.Description].Value = value;
                this.description = value;
            }
        }

        /// <summary>
        /// The direct reports.
        /// </summary>
        public IList<string> DirectReports
        {
            get
            {
                if (this.directReports == null)
                {
                    this.directReports = new MultipleLineAdapter(this.SearchResult.Properties[AttributeNames.DirectReports]).Value;
                }
                return this.directReports;
            }
        }

        /// <summary>
        /// The display name.
        /// </summary>
        public string DisplayName
        {
            get
            {
                if (String.IsNullOrEmpty(this.displayName))
                {
                    this.displayName = new SingleLineAdapter(this.SearchResult.Properties[AttributeNames.Displayname]).Value;
                }
                return this.displayName;
            }
            set
            {
                this.DirectoryEntry.Properties[AttributeNames.Displayname].Value = value;
                this.displayName = value;
            }
        }

        /// <summary>
        /// The Logon name for 2000(eg: [DomainName]\[UserName]).
        /// </summary>
        public string MsDS_PrincipalName
        {
            get
            {
                if (String.IsNullOrEmpty(this.msDS_PrincipalName))
                {
                    this.msDS_PrincipalName = new SingleLineAdapter(this.SearchResult, AttributeNames.MsDS_PrincipalName).Value;
                }
                return this.msDS_PrincipalName;
            }
        }

        /// <summary>
        /// The office.
        /// </summary>
        public string Office
        {
            get
            {
                if (String.IsNullOrEmpty(this.office))
                {
                    this.office = new SingleLineAdapter(this.SearchResult.Properties[AttributeNames.PhysicalDeliveryOfficeName]).Value;
                }
                return this.office;
            }
            set
            {
                this.DirectoryEntry.Properties[AttributeNames.PhysicalDeliveryOfficeName].Value = value;
                this.office = value;
            }
        }

        /// <summary>
        /// The zip or postal code.
        /// </summary>
        public string ZipOrPostalCode
        {
            get
            {
                if (String.IsNullOrEmpty(this.zipOrPostalCode))
                {
                    this.zipOrPostalCode = new SingleLineAdapter(this.SearchResult.Properties[AttributeNames.PostalCode]).Value;
                }
                return this.zipOrPostalCode;
            }
            set
            {
                this.DirectoryEntry.Properties[AttributeNames.PostalCode].Value = value;
                this.zipOrPostalCode = value;
            }
        }

        /// <summary>
        /// The P.O.Box.
        /// </summary>
        public IList<string> PostOfficeBoxs
        {
            get
            {
                if (this.postOfficeBoxs == null)
                {
                    this.postOfficeBoxs = new MultipleLineAdapter(this.SearchResult.Properties[AttributeNames.PostOfficeBox]).Value;
                }
                return this.postOfficeBoxs;
            }
            set
            {
                this.DirectoryEntry.Properties[AttributeNames.PostOfficeBox].Value = value;
                this.postOfficeBoxs = value;
            }
        }

        /// <summary>
        /// The web page.
        /// </summary>
        public string WebPage
        {
            get
            {
                if (String.IsNullOrEmpty(this.webPage))
                {
                    this.webPage = new SingleLineAdapter(this.SearchResult.Properties[AttributeNames.WWWHomePage]).Value;
                }
                return this.webPage;
            }
            set
            {
                this.DirectoryEntry.Properties[AttributeNames.WWWHomePage].Value = value;
                this.webPage = value;
            }
        }

        /// <summary>
        /// The other web pages.
        /// </summary>
        public IList<string> OtherWebPages
        {
            get
            {
                if (this.otherWebPages == null)
                {
                    this.otherWebPages = new MultipleLineAdapter(this.SearchResult.Properties[AttributeNames.Url]).Value;
                }
                return this.otherWebPages;
            }
            set
            {
                this.DirectoryEntry.Properties[AttributeNames.Url].Value = value;
                this.otherWebPages = value;
            }
        }

        /// <summary>
        /// The constructor with AD operator and SearchResult params.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="searchResult">The SearchResult.</param>
        internal protected ADObject(IADOperator adOperator, SearchResult searchResult)
        {
            this.SearchResult = searchResult;
            this.Path = searchResult.Path;
            this.Type = GetADObjectType(searchResult);
            this.ADOperator = adOperator;
        }

        /// <summary>
        /// Dispose the resource of the directory entry.
        /// </summary>
        public void Dispose()
        {
            if (this.directoryEntry != null)
            {
                this.directoryEntry.Close();
            }
        }

        /// <summary>
        /// Find one AD object by objectGUID.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="objectGuid">The objectGUID.</param>
        /// <returns>One AD object.</returns>
        public static ADObject FindOneByObjectGUID(IADOperator adOperator, Guid objectGuid)
        {
            ADObject adObject;
            using (var objectGuidDirectoryEntryRepository = new ObjectGUIDDirectoryEntryRepository(adOperator, objectGuid))
            {
                adObject = GetADObject(adOperator, objectGuidDirectoryEntryRepository.GetSearchResult());
            }
            return adObject;
        }

        /// <summary>
        /// Save the directory entry.
        /// </summary>
        public void Save()
        {
            this.DirectoryEntry.CommitChanges();
        }

        /// <summary>
        /// Delete the directory entry.
        /// </summary>
        public void Delete()
        {
            this.DirectoryEntry.DeleteTree();
        }

        /// <summary>
        /// Get the attribute value.
        /// </summary>
        /// <typeparam name="TAttributeValue">The attribute value generic type.</typeparam>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The attribute value.</returns>
        public TAttributeValue GetAttributeValue<TAttributeValue>(string attributeName) where TAttributeValue : class
        {
            TAttributeValue attributeValue = default(TAttributeValue);
            if (typeof(TAttributeValue) == typeof(string))
            {
                attributeValue = new SingleLineAdapter(this.SearchResult.Properties[attributeName]).Value as TAttributeValue;
            }
            else if (typeof(TAttributeValue) == typeof(byte[]))
            {
                attributeValue = new ByteArrayAdapter(this.SearchResult.Properties[attributeName]).Value as TAttributeValue;
            }
            else if (typeof(TAttributeValue) == typeof(DateTime))
            {
                attributeValue = new DateTimeAdapter(this.SearchResult, attributeName).Value as TAttributeValue;
            }
            else if (typeof(TAttributeValue) == typeof(Guid))
            {
                attributeValue = new GuidAdapter(this.SearchResult.Properties[attributeName]).Value as TAttributeValue;
            }
            else if (typeof(TAttributeValue) == typeof(int))
            {
                attributeValue = new IntegerAdapter(this.SearchResult.Properties[attributeName]).Value as TAttributeValue;
            }
            else if (typeof(TAttributeValue) == typeof(IList<string>))
            {
                attributeValue = new MultipleLineAdapter(this.SearchResult.Properties[attributeName]).Value as TAttributeValue;
            }
            return attributeValue;
        }

        /// <summary>
        /// Set the attribute value.
        /// </summary>
        /// <typeparam name="TAttributeValue">The attribute value generic type.</typeparam>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public void SetAttributeValue<TAttributeValue>(string attributeName, TAttributeValue attributeValue)
        {
            this.DirectoryEntry.Properties[attributeName].Value = attributeValue;
        }

        /// <summary>
        /// Clear the attribute value.
        /// </summary>
        /// <param name="attributename">The attribute name.</param>
        public void ClearAttributeValue(string attributename)
        {
            this.DirectoryEntry.Properties[attributename].Clear();
        }

        internal static ADObject GetADObject(IADOperator adOperator, SearchResult searchResult)
        {
            ADObject adObject;
            ADObjectType adObjectType = GetADObjectType(searchResult);
            switch (adObjectType)
            {
                case ADObjectType.User:
                    adObject = new UserObject(adOperator, searchResult);
                    break;
                case ADObjectType.Contact:
                    adObject = new ContactObject(adOperator, searchResult);
                    break;
                case ADObjectType.Computer:
                    adObject = new ComputerObject(adOperator, searchResult);
                    break;
                case ADObjectType.Container:
                    adObject = new ContainerObject(adOperator, searchResult);
                    break;
                case ADObjectType.Group:
                    adObject = new GroupObject(adOperator, searchResult);
                    break;
                case ADObjectType.InetOrgPerson:
                    adObject = new InetOrgPersonObject(adOperator, searchResult);
                    break;
                case ADObjectType.MSMQQueueAlias:
                    adObject = new MSMQQueueAliasObject(adOperator, searchResult);
                    break;
                case ADObjectType.MsImaging_PSPs:
                    adObject = new MsImaging_PSPsObject(adOperator, searchResult);
                    break;
                case ADObjectType.OrganizationalUnit:
                    adObject = new OrganizationalUnitObject(adOperator, searchResult);
                    break;
                case ADObjectType.Printer:
                    adObject = new PrinterObject(adOperator, searchResult);
                    break;
                case ADObjectType.SharedFolder:
                    adObject = new SharedFolderObject(adOperator, searchResult);
                    break;
                default:
                    adObject = new UnknownObject(adOperator, searchResult);
                    break;
            }
            return adObject;
        }

        internal static ADObjectType GetADObjectType(SearchResult searchResult)
        {
            var resultPropertyValueCollection = searchResult.Properties[AttributeNames.ObjectClass];
            for (int index = 0; index < resultPropertyValueCollection.Count; index++)
            {
                switch (resultPropertyValueCollection[index].ToString())
                {
                    case UserAttributeValues.User:
                        return ADObjectType.User;
                    case ContactAttributeValues.Contact:
                        return ADObjectType.Contact;
                    case ComputerAttributeValues.Computer:
                        return ADObjectType.Computer;
                    case ContainerAttributeValues.Container:
                        return ADObjectType.Container;
                    case GroupAttributeValues.Group:
                        return ADObjectType.Group;
                    case InetOrgPersonAttributeValues.InetOrgPerson:
                        return ADObjectType.InetOrgPerson;
                    case MSMQQueueAliasAttributeValues.MSMQQueueAlias:
                        return ADObjectType.MSMQQueueAlias;
                    case MsImaging_PSPsAttributeValues.MsImaging_PSPs:
                        return ADObjectType.MsImaging_PSPs;
                    case OrganizationalUnitAttributeValues.OrganizationalUnit:
                        return ADObjectType.OrganizationalUnit;
                    case PrinterAttributeValues.Printer:
                        return ADObjectType.Printer;
                    case SharedFolderAttributeValues.SharedFolder:
                        return ADObjectType.SharedFolder;
                    default:
                        break;
                }
            }
            return ADObjectType.Unknow;
        }
    }
}
using System.Collections.Generic;
using System.DirectoryServices;
using System;
using System.Linq;
using Landpy.ActiveDirectory.Attributes;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Attribute.Value;
using Landpy.ActiveDirectory.Entity.Query;
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
        private IList<ADObject> directReportObjects;

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
        [ADOriginalAttributeName(AttributeNames.CN)]
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
        [ADOriginalAttributeName(AttributeNames.ObjectGuid)]
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
        [ADOriginalAttributeName(AttributeNames.DistinguishedName)]
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
        [ADOriginalAttributeName(AttributeNames.Name)]
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
        [ADOriginalAttributeName(AttributeNames.CanonicalName)]
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
        [ADOriginalAttributeName(AttributeNames.CreateTimeStamp)]
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
        [ADOriginalAttributeName(AttributeNames.ModifyTimeStamp)]
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
        [ADOriginalAttributeName(AttributeNames.Description)]
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
        [ADOriginalAttributeName(AttributeNames.DirectReports)]
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
        /// The direct report AD objects.
        /// </summary>
        public IList<ADObject> DirectReportObjects
        {
            get
            {
                if (this.directReportObjects == null)
                {
                    this.directReportObjects = FindAllByDNs(this.ADOperator, this.DirectReports);
                }
                return this.directReportObjects;
            }
        }

        /// <summary>
        /// The display name.
        /// </summary>
        [ADOriginalAttributeName(AttributeNames.Displayname)]
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
        [ADOriginalAttributeName(AttributeNames.MsDS_PrincipalName)]
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
        [ADOriginalAttributeName(AttributeNames.PhysicalDeliveryOfficeName)]
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
        [ADOriginalAttributeName(AttributeNames.PostalCode)]
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
        [ADOriginalAttributeName(AttributeNames.PostOfficeBox)]
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
                SetAttributeValue(AttributeNames.PostOfficeBox, value);
                this.postOfficeBoxs = value;
            }
        }

        /// <summary>
        /// The web page.
        /// </summary>
        [ADOriginalAttributeName(AttributeNames.WWWHomePage)]
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
        [ADOriginalAttributeName(AttributeNames.Url)]
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
                SetAttributeValue(AttributeNames.Url, value);
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
            this.ADOperator = adOperator;
            this.SearchResult = searchResult;
            if (searchResult != null)
            {
                this.Path = searchResult.Path;
            }
            this.Type = GetADObjectType(searchResult);

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
        /// Find one AD object by filter.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="filter">The filter</param>
        /// <returns>One AD object.</returns>
        internal static TADObject FindOneByFilter<TADObject>(IADOperator adOperator, IFilter filter) where TADObject : class
        {
            TADObject adObject;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                adObject = GetADObject(adOperator, directoryEntryRepository.GetSearchResult(filter)) as TADObject;
            }
            return adObject;
        }

        /// <summary>
        /// Find all AD objects by filter.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="filter">The filter</param>
        /// <returns>All AD objects.</returns>
        internal static List<TADObject> FindAllByFilter<TADObject>(IADOperator adOperator, IFilter filter)
        {
            List<TADObject> adObjects;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                using (var searchResultCollection = directoryEntryRepository.GetSearchResultCollection(filter))
                {
                    var objects = (from SearchResult searchResult in searchResultCollection
                                   select GetADObject(adOperator, searchResult)).ToList();
                    adObjects = objects.Cast<TADObject>().ToList();
                }
            }
            return adObjects;
        }

        /// <summary>
        /// Find one AD object by filter and path.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="filter">The filter</param>
        /// <param name="ldapPath">The LDAP path.</param>
        /// <param name="queryScopeType">The query scope type.</param>
        /// <returns>One AD object.</returns>
        internal static TADObject FindOneByFilter<TADObject>(IADOperator adOperator, IFilter filter, string ldapPath, QueryScopeType queryScopeType) where TADObject : class
        {
            TADObject adObject;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator, ldapPath, queryScopeType))
            {
                adObject = GetADObject(adOperator, directoryEntryRepository.GetSearchResult(filter)) as TADObject;
            }
            return adObject;
        }

        /// <summary>
        /// Find all AD objects by filter and path.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="filter">The filter</param>
        /// <param name="ldapPath">The LDAP path.</param>
        /// <param name="queryScopeType">The query scope type.</param>
        /// <returns>All AD objects.</returns>
        internal static List<TADObject> FindAllByFilter<TADObject>(IADOperator adOperator, IFilter filter, string ldapPath, QueryScopeType queryScopeType)
        {
            List<TADObject> adObjects;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator, ldapPath, queryScopeType))
            {
                using (var searchResultCollection = directoryEntryRepository.GetSearchResultCollection(filter))
                {
                    var objects = (from SearchResult searchResult in searchResultCollection
                                   select GetADObject(adOperator, searchResult)).ToList();
                    adObjects = objects.Cast<TADObject>().ToList();
                }
            }
            return adObjects;
        }

        /// <summary>
        /// Verify whether the AD object with the object guid exists.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="objectGuid">The AD object guid.</param>
        /// <returns>Whether the AD Object exists.</returns>
        public static bool DoesADObjectExists(IADOperator adOperator, Guid objectGuid)
        {
            bool doesADObjectExists;
            using (var objectGuidDirectoryEntryRepository = new ObjectGUIDDirectoryEntryRepository(adOperator, objectGuid))
            {
                doesADObjectExists = objectGuidDirectoryEntryRepository.Exists;
            }
            return doesADObjectExists;
        }

        /// <summary>
        /// Find one AD object by objectGUID.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="objectGuid">The objectGUID.</param>
        /// <returns>One AD object.</returns>
        public static ADObject FindOneByObjectGUID(IADOperator adOperator, Guid objectGuid)
        {
            ADObject adObject = null;
            using (var objectGuidDirectoryEntryRepository = new ObjectGUIDDirectoryEntryRepository(adOperator, objectGuid))
            {
                if (objectGuidDirectoryEntryRepository.Exists)
                {
                    adObject = GetADObject(adOperator, objectGuidDirectoryEntryRepository.GetSearchResult());
                }
            }
            return adObject;
        }

        /// <summary>
        /// Fine one AD object by distinguished name.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="distinguishedName">The distinguished name.</param>
        /// <returns>One AD object.</returns>
        public static ADObject FindOneByDN(IADOperator adOperator, string distinguishedName)
        {
            return FindOneByFilter<ADObject>(adOperator, new Is(AttributeNames.DistinguishedName, distinguishedName));
        }

        /// <summary>
        /// Find all AD objects by distinguished names.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="distinguishedNames">The distinguished names.</param>
        /// <returns>All AD objects.</returns>
        public static IList<ADObject> FindAllByDNs(IADOperator adOperator, IList<string> distinguishedNames)
        {
            List<ADObject> adObjects;
            var filters = distinguishedNames.Select(distinguishedName => new Is(AttributeNames.DistinguishedName, distinguishedName)).Cast<IFilter>().ToList();
            if (filters.Count != 0)
            {
                IFilter filter = new Or(filters.ToArray());
                adObjects = FindAllByFilter<ADObject>(adOperator, filter);
            }
            else
            {
                adObjects = new List<ADObject>();
            }
            return adObjects;
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
        public TAttributeValue GetAttributeValue<TAttributeValue>(string attributeName)
        {
            object attributeValue = default(TAttributeValue);
            if (typeof(TAttributeValue) == typeof(string))
            {
                attributeValue = new SingleLineAdapter(this.SearchResult.Properties[attributeName]).Value;
            }
            else if (typeof(TAttributeValue) == typeof(byte[]))
            {
                attributeValue = new ByteArrayAdapter(this.SearchResult.Properties[attributeName]).Value;
            }
            else if (typeof(TAttributeValue) == typeof(DateTime))
            {
                attributeValue = new DateTimeAdapter(this.SearchResult, attributeName).Value;
            }
            else if (typeof(TAttributeValue) == typeof(Guid))
            {
                attributeValue = new GuidAdapter(this.SearchResult.Properties[attributeName]).Value;
            }
            else if (typeof(TAttributeValue) == typeof(int))
            {
                attributeValue = new IntegerAdapter(this.SearchResult.Properties[attributeName]).Value;
            }
            else if (typeof(TAttributeValue) == typeof(IList<string>) || typeof(TAttributeValue) == typeof(List<string>))
            {
                attributeValue = new MultipleLineAdapter(this.SearchResult.Properties[attributeName]).Value;
            }
            return (TAttributeValue)attributeValue;
        }

        /// <summary>
        /// Set the attribute value.
        /// </summary>
        /// <typeparam name="TAttributeValue">The attribute value generic type.</typeparam>
        /// <param name="attributeName">The attribute name.</param>
        /// <param name="attributeValue">The attribute value.</param>
        public void SetAttributeValue<TAttributeValue>(string attributeName, TAttributeValue attributeValue)
        {
            if (typeof(TAttributeValue) == typeof(IList<string>) || typeof(TAttributeValue) == typeof(List<string>))
            {
                var attributeValueItems = attributeValue as IList<string>;
                if (attributeValueItems != null)
                {
                    this.DirectoryEntry.Properties[attributeName].Clear();
                    foreach (var attributeValueItem in attributeValueItems)
                    {
                        this.DirectoryEntry.Properties[attributeName].Add(attributeValueItem);
                    }
                }
            }
            else
            {
                this.DirectoryEntry.Properties[attributeName].Value = attributeValue;
            }
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
                case ADObjectType.Domain:
                    adObject = new DomainObject(adOperator, searchResult);
                    break;
                case ADObjectType.PasswordSettings:
                    adObject = new PasswordSettingsObject(adOperator, searchResult);
                    break;
                default:
                    adObject = new UnknownObject(adOperator, searchResult);
                    break;
            }
            return adObject;
        }

        internal static ADObjectType GetADObjectType(SearchResult searchResult)
        {
            ADObjectType adObjectType = ADObjectType.Unknow;
            if (searchResult != null)
            {
                var resultPropertyValueCollection = searchResult.Properties[AttributeNames.ObjectClass];
                for (int index = 0; index < resultPropertyValueCollection.Count; index++)
                {
                    switch (resultPropertyValueCollection[index].ToString())
                    {
                        case UserAttributeValues.User:
                            adObjectType = ADObjectType.User;
                            break;
                        case ContactAttributeValues.Contact:
                            adObjectType = ADObjectType.Contact;
                            break;
                        case ComputerAttributeValues.Computer:
                            adObjectType = ADObjectType.Computer;
                            break;
                        case ContainerAttributeValues.Container:
                            adObjectType = ADObjectType.Container;
                            break;
                        case GroupAttributeValues.Group:
                            adObjectType = ADObjectType.Group;
                            break;
                        case InetOrgPersonAttributeValues.InetOrgPerson:
                            adObjectType = ADObjectType.InetOrgPerson;
                            break;
                        case MSMQQueueAliasAttributeValues.MSMQQueueAlias:
                            adObjectType = ADObjectType.MSMQQueueAlias;
                            break;
                        case MsImaging_PSPsAttributeValues.MsImaging_PSPs:
                            adObjectType = ADObjectType.MsImaging_PSPs;
                            break;
                        case OrganizationalUnitAttributeValues.OrganizationalUnit:
                            adObjectType = ADObjectType.OrganizationalUnit;
                            break;
                        case PrinterAttributeValues.Printer:
                            adObjectType = ADObjectType.Printer;
                            break;
                        case SharedFolderAttributeValues.SharedFolder:
                            adObjectType = ADObjectType.SharedFolder;
                            break;
                        case DomainAttributeValues.Domain:
                            adObjectType = ADObjectType.Domain;
                            break;
                        case PasswordSettingsAttributeValues.MsDS_PasswordSettings:
                            adObjectType = ADObjectType.PasswordSettings;
                            break;
                        default:
                            break;
                    }
                }
            }
            return adObjectType;
        }
    }
}
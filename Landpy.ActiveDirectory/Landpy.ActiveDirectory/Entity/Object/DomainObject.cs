using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using Landpy.ActiveDirectory.Attributes;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.TypeAdapter;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The domain AD object.
    /// </summary>
    public class DomainObject : ADObject
    {
        private int groupPolicyMinimumPasswordLength;
        private bool? isMustMeetComplexityRequirments;

        /// <summary>
        /// The group policy minimum password length.
        /// </summary>
        [ADOriginalAttributeName(DomainAttributeNames.MinPwdLength)]
        public int GroupPolicyMinimumPasswordLength
        {
            get
            {
                if (this.groupPolicyMinimumPasswordLength == -1)
                {
                    this.groupPolicyMinimumPasswordLength = new IntegerAdapter(this.SearchResult.Properties[DomainAttributeNames.MinPwdLength]).Value;
                }
                return this.groupPolicyMinimumPasswordLength;
            }
            set
            {
                this.DirectoryEntry.Properties[DomainAttributeNames.MinPwdLength].Value = value;
                this.groupPolicyMinimumPasswordLength = value;
            }
        }

        /// <summary>
        /// Is must meet complexity requirements policy.
        /// </summary>
        [ADOriginalAttributeName(DomainAttributeNames.PwdProperties)]
        public bool IsMustMeetComplexityRequirments
        {
            get
            {
                if (isMustMeetComplexityRequirments == null)
                {
                    isMustMeetComplexityRequirments = (new IntegerAdapter(this.SearchResult.Properties[DomainAttributeNames.PwdProperties]).Value % 2 == 1);
                }
                return (bool)(isMustMeetComplexityRequirments);
            }
            set
            {
                this.DirectoryEntry.Properties[DomainAttributeNames.PwdProperties].Value = value;
                this.isMustMeetComplexityRequirments = value;
            }
        }

        /// <summary>
        /// The domain object constructure with AD operator and SearchResult params.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="searchResult">The SearchResult.</param>
        public DomainObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
            this.groupPolicyMinimumPasswordLength = -1;
        }

        /// <summary>
        /// Find one domain object.
        /// </summary>
        /// <returns>One domain object.</returns>
        public static DomainObject FindOne(IADOperator adOperator)
        {
            return FindOneByFilter<DomainObject>(adOperator, new IsDomain());
        }

        /// <summary>
        /// Get the current domain object with no password.
        /// </summary>
        /// <returns></returns>
        public static DomainObject GetCurrent()
        {
            DomainObject domainObject;
            var directoryContext = new DirectoryContext(DirectoryContextType.Domain);
            using (Domain domain = Domain.GetDomain(directoryContext))
            {
                using (DirectoryEntry domainDirectoryEntry = domain.GetDirectoryEntry())
                {
                    using (var directoryEntryRepository = new DirectoryEntryRepository(domainDirectoryEntry))
                    {
                        domainObject = (from SearchResult searchResult in directoryEntryRepository.GetSearchResultCollection(new And(new IsDomain()))
                                        select new DomainObject(null, searchResult)).SingleOrDefault();
                    }
                }
            }
            return domainObject;
        }
    }
}

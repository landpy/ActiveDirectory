using System.DirectoryServices;
using System.Linq;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.TypeAdapter;

namespace Landpy.ActiveDirectory.Entity.Object
{
    public class DomainObject : ADObject
    {
        private int groupPolicyMinimumPasswordLength;
        private bool? isMustMeetComplexityRequirments;

        /// <summary>
        /// The group policy minimum password length.
        /// </summary>
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
            DomainObject domainObject;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                domainObject = (from SearchResult searchResult in directoryEntryRepository.GetSearchResultCollection(new And(new IsDomain()))
                                select new DomainObject(adOperator, searchResult)).SingleOrDefault();
            }
            return domainObject;
        }
    }
}

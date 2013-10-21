using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using Landpy.ActiveDirectory.Attributes;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.TypeAdapter;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The password settings object.
    /// </summary>
    public class PasswordSettingsObject : ADObject
    {
        private int customPolicyMinimumPasswordLength;
        private bool? isMustMeetComplexityRequirments;

        /// <summary>
        /// The group policy minimum password length.
        /// </summary>
        [ADOriginalAttributeName(PasswordSettingsAttributeNames.MsDS_MinimumPasswordLength)]
        public int CustomPolicyMinimumPasswordLength
        {
            get
            {
                if (this.customPolicyMinimumPasswordLength == -1)
                {
                    this.customPolicyMinimumPasswordLength = new IntegerAdapter(this.SearchResult.Properties[PasswordSettingsAttributeNames.MsDS_MinimumPasswordLength]).Value;
                }
                return this.customPolicyMinimumPasswordLength;
            }
        }

        /// <summary>
        /// Is must meet complexity requirements policy.
        /// </summary>
        [ADOriginalAttributeName(PasswordSettingsAttributeNames.MsDS_PasswordComplexityEnabled)]
        public bool IsMustMeetComplexityRequirments
        {
            get
            {
                if (isMustMeetComplexityRequirments == null)
                {
                    isMustMeetComplexityRequirments = new BooleanAdapter(this.SearchResult.Properties[PasswordSettingsAttributeNames.MsDS_PasswordComplexityEnabled]).Value;
                }
                return (bool)(isMustMeetComplexityRequirments);
            }
        }

        /// <summary>
        /// The constructor with AD operator and SearchResult params.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="searchResult">The SearchResult.</param>
        public PasswordSettingsObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
            this.customPolicyMinimumPasswordLength = -1;
        }

        /// <summary>
        /// Find one domain object.
        /// </summary>
        /// <returns>One domain object.</returns>
        public static IList<PasswordSettingsObject> FindAll(IADOperator adOperator, string userCn)
        {
            IList<PasswordSettingsObject> passwordSettingsObjects;
            var userObject = UserObject.FindOneByCN(adOperator, userCn);
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                passwordSettingsObjects = (from SearchResult searchResult in directoryEntryRepository.GetSearchResultCollection(
                                              new And(
                                                  new IsPasswordSettings(),
                                                  new Or(
                                                      new Is(PSOAttributeNames.MsDS_PSOAppliesTo, userObject.DistinguishedName),
                                                      new Is(PSOAttributeNames.MsDS_PSOAppliesTo, userObject.ObjectSid))))
                                           select new PasswordSettingsObject(adOperator, searchResult)).ToList();
            }
            return passwordSettingsObjects;
        }
    }
}

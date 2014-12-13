using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using Landpy.ActiveDirectory.Attributes;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Command;
using Landpy.ActiveDirectory.Entity.TypeAdapter;
using Landpy.ActiveDirectory.Entity.Attribute.Name;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The user AD object.
    /// </summary>
    public class UserObject : PersonObject
    {
        private string objectSid;
        private string sAMAccountName;
        private string principalName;
        private IList<string> groupSids;
        private UserAccountControlType accountControlType;
        private bool isMustChangePwdNextLogon;
        private bool isEnabled;
        private bool isLocked;
        private DateTime accountExpiresTime;

        /// <summary>
        /// The object sid.
        /// </summary>
        [ADOriginalAttributeName(UserAttributeNames.ObjectSid)]
        public string ObjectSid
        {
            get
            {
                if (String.IsNullOrEmpty(this.objectSid))
                {
                    this.objectSid = new SidAdapter(this.SearchResult.Properties[UserAttributeNames.ObjectSid]).Value;
                }
                return this.objectSid;
            }
        }

        /// <summary>
        /// The pre Win2000 inditity name.
        /// </summary>
        [ADOriginalAttributeName(UserAttributeNames.SAMAccountName)]
        public string SAMAccountName
        {
            get
            {
                if (String.IsNullOrEmpty(this.sAMAccountName))
                {
                    this.sAMAccountName = new SingleLineAdapter(this.SearchResult.Properties[UserAttributeNames.SAMAccountName]).Value;
                }
                return this.sAMAccountName;
            }
            set
            {
                this.DirectoryEntry.Properties[UserAttributeNames.SAMAccountName].Value = value;
                this.sAMAccountName = value;
            }
        }

        /// <summary>
        /// The user logon name(eg: [UserName]@[DomainName]).
        /// </summary>
        [ADOriginalAttributeName(UserAttributeNames.UserPrincipalName)]
        public string PrincipalName
        {
            get
            {
                if (String.IsNullOrEmpty(this.principalName))
                {
                    this.principalName = new SingleLineAdapter(this.SearchResult.Properties[UserAttributeNames.UserPrincipalName]).Value;
                }
                return this.principalName;
            }
            set
            {
                this.DirectoryEntry.Properties[UserAttributeNames.UserPrincipalName].Value = value;
                this.principalName = value;
            }
        }

        /// <summary>
        /// The group sids.
        /// </summary>
        [ADOriginalAttributeName(UserAttributeNames.TokenGroups)]
        public IList<string> GroupSids
        {
            get
            {
                if (this.groupSids == null)
                {
                    this.groupSids = new SidsAdapter(this.SearchResult, UserAttributeNames.TokenGroups).Value;
                }
                return this.groupSids;
            }
        }

        /// <summary>
        /// The user account control type.
        /// </summary>
        [ADOriginalAttributeName(UserAttributeNames.UserAccountControl)]
        public UserAccountControlType AccountControlType
        {
            get
            {
                if (this.accountControlType == UserAccountControlType.Unknow)
                {
                    this.accountControlType = (UserAccountControlType)(new IntegerAdapter(this.SearchResult.Properties[UserAttributeNames.UserAccountControl]).Value);
                }
                return this.accountControlType;
            }
            set
            {
                this.DirectoryEntry.Properties[UserAttributeNames.UserAccountControl].Value = value;
                this.accountControlType = value;
            }
        }

        /// <summary>
        /// Gets whether is domain admin.
        /// </summary>
        public bool IsDomainAdmin
        {
            get
            {
                return (from groupSid in this.GroupSids
                        where groupSid.EndsWith("-512")
                        select groupSid).Any();
            }
        }

        /// <summary>
        /// Gets whether is account operator.
        /// </summary>
        public bool IsAccountOperator
        {
            get
            {
                return (from groupSid in this.GroupSids
                        where groupSid.EndsWith("-548")
                        select groupSid).Any();
            }
        }

        /// <summary>
        /// Gets or sets whether the user must reset the password when next logon.
        /// </summary>
        [ADOriginalAttributeName(UserAttributeNames.PwdLastSet)]
        public bool IsMustChangePwdNextLogon
        {
            get
            {
                DateTime largeInteger = new LargeIntegerAdapter(this.SearchResult, UserAttributeNames.PwdLastSet).Value;
                if (largeInteger == new DateTime(1601, 1, 1, 0, 0, 0))
                {
                    this.isMustChangePwdNextLogon = true;
                }
                else
                {
                    this.isMustChangePwdNextLogon = false;
                }
                return this.isMustChangePwdNextLogon;
            }
            set
            {
                this.isMustChangePwdNextLogon = value;
                if (value)
                {
                    this.DirectoryEntry.Properties[UserAttributeNames.PwdLastSet].Value = 0;
                }
                else
                {
                    this.DirectoryEntry.Properties[UserAttributeNames.PwdLastSet].Value = -1;
                }
            }
        }

        /// <summary>
        /// Gets whether the user is enabled.
        /// </summary>
        [ADOriginalAttributeName(UserAttributeNames.UserAccountControl)]
        public bool IsEnabled
        {
            get
            {
                int userAccountControlValue = new IntegerAdapter(this.SearchResult.Properties[UserAttributeNames.UserAccountControl]).Value;
                if (((UserAccountControlType)(userAccountControlValue) & UserAccountControlType.AccountDisabled) != UserAccountControlType.AccountDisabled)
                {
                    this.isEnabled = true;
                }
                return this.isEnabled;
            }
            set
            {
                int userAccountControlValue = new IntegerAdapter(this.SearchResult.Properties[UserAttributeNames.UserAccountControl]).Value;
                var userAccountControlType = (UserAccountControlType)userAccountControlValue;
                if (value)
                {
                    this.DirectoryEntry.Properties[UserAttributeNames.UserAccountControl].Value = userAccountControlType | UserAccountControlType.AccountDisabled;
                }
                this.isEnabled = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the user is locked.
        /// </summary>
        [ADOriginalAttributeName(UserAttributeNames.LockoutTime)]
        public bool IsLocked
        {
            get
            {
                DateTime largeInteger = new LargeIntegerAdapter(this.SearchResult, UserAttributeNames.LockoutTime).Value;
                if (largeInteger == new DateTime(1601, 1, 1, 0, 0, 0))
                {
                    this.isLocked = false;
                }
                else
                {
                    this.isLocked = true;
                }
                return this.isLocked;
            }
            set
            {
                this.isLocked = value;
                if (value)
                {
                    this.DirectoryEntry.Properties[UserAttributeNames.LockoutTime].Value = 0;
                }
                else
                {
                    this.DirectoryEntry.Properties[UserAttributeNames.LockoutTime].Value = -1;
                }
            }
        }

        /// <summary>
        /// Gets or sets the account expires time (UTC) of user.
        /// </summary>
        [ADOriginalAttributeName(UserAttributeNames.AccountExpires)]
        public DateTime AccountExpiresTime
        {
            get
            {
                if (this.accountExpiresTime == DateTime.MinValue)
                {
                    this.accountExpiresTime = new LargeIntegerAdapter(this.SearchResult, UserAttributeNames.AccountExpires).Value;
                }
                return this.accountExpiresTime;
            }
            set
            {
                this.accountExpiresTime = value;
                this.DirectoryEntry.Properties[UserAttributeNames.AccountExpires].Value = value.ToFileTimeUtc().ToString();
            }
        }

        internal UserObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
        }

        /// <summary>
        /// Fine one user object by sid.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="sid">The sid.</param>
        /// <returns>One user object.</returns>
        public static UserObject FindOneBySid(IADOperator adOperator, string sid)
        {
            return FindOneByFilter<UserObject>(adOperator, new And(new IsUser(), new Is(UserAttributeNames.ObjectSid, sid)));
        }

        /// <summary>
        /// Find one user object by sAMAccountName.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="sAMAccountName">The sAMAccountName.</param>
        /// <returns>One user object.</returns>
        public static UserObject FindOneBySAMAccountName(IADOperator adOperator, string sAMAccountName)
        {
            return FindOneByFilter<UserObject>(adOperator, new And(new IsUser(), new Is(UserAttributeNames.SAMAccountName, sAMAccountName)));
        }

        /// <summary>
        /// Fine one user object by common name.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="cn">The common name.</param>
        /// <returns>One user object.</returns>
        public static UserObject FindOneByCN(IADOperator adOperator, string cn)
        {
            return FindOneByFilter<UserObject>(adOperator, new And(new IsUser(), new Is(AttributeNames.CN, cn)));
        }

        /// <summary>
        /// Find all user directory entry.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <returns></returns>
        public static IList<UserObject> FindAll(IADOperator adOperator)
        {
            return FindAllByFilter<UserObject>(adOperator, new IsUser());
        }

        /// <summary>
        /// Find all user directory entry by filter.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>All user directory entry by filter.</returns>
        public static IList<UserObject> FindAll(IADOperator adOperator, IFilter filter)
        {
            return FindAllByFilter<UserObject>(adOperator, new And(new IsUser(), filter));
        }

        /// <summary>
        /// Reset the password.
        /// </summary>
        /// <param name="password">The password</param>
        public void ResetPassword(string password)
        {
            this.DirectoryEntry.Invoke(UserCommandNames.SetPassword, new object[] { password });
            this.DirectoryEntry.CommitChanges();
        }
    }
}
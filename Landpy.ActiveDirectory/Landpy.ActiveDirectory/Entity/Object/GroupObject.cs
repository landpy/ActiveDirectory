﻿using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using Landpy.ActiveDirectory.Attributes;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.TypeAdapter;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The group AD object.
    /// </summary>
    public class GroupObject : ADObject
    {
        private string managedBy;
        private string objectSid;
        private string sAMAccountName;
        private IList<string> groupSids;
        private string email;
        private string notes;
        private IList<string> members;
        private GroupType groupType;
        private GroupScopeType groupScopeType;

        /// <summary>
        /// The object sid.
        /// </summary>
        [ADOriginalAttributeName(GroupAttributeNames.ObjectSid)]
        public string ObjectSid
        {
            get
            {
                if (String.IsNullOrEmpty(this.objectSid))
                {
                    this.objectSid = new SidAdapter(this.SearchResult.Properties[GroupAttributeNames.ObjectSid]).Value;
                }
                return this.objectSid;
            }
        }

        /// <summary>
        /// The pre Win2000 inditity name.
        /// </summary>
        [ADOriginalAttributeName(GroupAttributeNames.SAMAccountName)]
        public string SAMAccountName
        {
            get
            {
                if (String.IsNullOrEmpty(this.sAMAccountName))
                {
                    this.sAMAccountName = new SingleLineAdapter(this.SearchResult.Properties[GroupAttributeNames.SAMAccountName]).Value;
                }
                return this.sAMAccountName;
            }
            set
            {
                this.DirectoryEntry.Properties[GroupAttributeNames.SAMAccountName].Value = value;
                this.sAMAccountName = value;
            }
        }

        /// <summary>
        /// The group sids.
        /// </summary>
        [ADOriginalAttributeName(GroupAttributeNames.TokenGroups)]
        public IList<string> GroupSids
        {
            get
            {
                if (this.groupSids == null)
                {
                    this.groupSids = new SidsAdapter(this.SearchResult, GroupAttributeNames.TokenGroups).Value;
                }
                return this.groupSids;
            }
        }

        /// <summary>
        /// The managed by user distinguish name.
        /// </summary>
        [ADOriginalAttributeName(GroupAttributeNames.ManagedBy)]
        public string ManagedBy
        {
            get
            {
                if (String.IsNullOrEmpty(this.managedBy))
                {
                    this.managedBy = new SingleLineAdapter(this.SearchResult.Properties[GroupAttributeNames.ManagedBy]).Value;
                }
                return this.managedBy;
            }
            set
            {
                this.DirectoryEntry.Properties[GroupAttributeNames.ManagedBy].Value = value;
                this.managedBy = value;
            }
        }

        /// <summary>
        /// The email.
        /// </summary>
        [ADOriginalAttributeName(PersonAttributeNames.Mail)]
        public string Email
        {
            get
            {
                if (String.IsNullOrEmpty(this.email))
                {
                    this.email = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.Mail]).Value;
                }
                return this.email;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.Mail].Value = value;
                this.email = value;
            }
        }

        /// <summary>
        /// The notes.
        /// </summary>
        [ADOriginalAttributeName(PersonAttributeNames.Info)]
        public string Notes
        {
            get
            {
                if (String.IsNullOrEmpty(this.notes))
                {
                    this.notes = new SingleLineAdapter(this.SearchResult.Properties[PersonAttributeNames.Info]).Value;
                }
                return this.notes;
            }
            set
            {
                this.DirectoryEntry.Properties[PersonAttributeNames.Info].Value = value;
                this.notes = value;
            }
        }

        /// <summary>
        /// The members.
        /// </summary>
        [ADOriginalAttributeName(GroupAttributeNames.Member)]
        public IList<string> Members
        {
            get
            {
                if (this.members == null)
                {
                    this.members = new MultipleLineAdapter(this.SearchResult.Properties[GroupAttributeNames.Member]).Value;
                }
                return this.members;
            }
            set
            {
                SetAttributeValue(GroupAttributeNames.Member, value);
                this.members = value;
            }
        }

        /// <summary>
        /// The group type.
        /// </summary>
        [ADOriginalAttributeName(GroupAttributeNames.GroupType)]
        public GroupType GroupType
        {
            get
            {
                if (this.groupType == GroupType.Unknow)
                {
                    int groupTypeValue = new IntegerAdapter(this.SearchResult.Properties[GroupAttributeNames.GroupType]).Value;
                    var buildInGroupType = (BuildInGroupType)groupTypeValue;
                    if ((buildInGroupType & BuildInGroupType.Security) != BuildInGroupType.None)
                    {
                        this.groupType = GroupType.Security;
                    }
                    else
                    {
                        this.groupType = GroupType.Distribution;
                    }
                }
                return this.groupType;
            }
        }

        /// <summary>
        /// The group scope type.
        /// </summary>
        [ADOriginalAttributeName(GroupAttributeNames.GroupType)]
        public GroupScopeType GroupScopeType
        {
            get
            {
                if (this.groupScopeType == GroupScopeType.Unknow)
                {
                    int groupTypeValue = new IntegerAdapter(this.SearchResult.Properties[GroupAttributeNames.GroupType]).Value;
                    var buildInGroupType = (BuildInGroupType)groupTypeValue;
                    if ((buildInGroupType & BuildInGroupType.DomainLocalGroup) != BuildInGroupType.None)
                    {
                        this.groupScopeType = GroupScopeType.DomainLocal;
                    }
                    else if ((buildInGroupType & BuildInGroupType.GlobalGroup) != BuildInGroupType.None)
                    {
                        this.groupScopeType = GroupScopeType.Global;
                    }
                    else if ((buildInGroupType & BuildInGroupType.UniversalGroup) != BuildInGroupType.None)
                    {
                        this.groupScopeType = GroupScopeType.Universal;
                        ;
                    }
                }
                return this.groupScopeType;
            }
        }

        internal GroupObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
        }

        /// <summary>
        /// Fine one user directory entry.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="sid">The sid.</param>
        /// <returns></returns>
        public static GroupObject FindOneBySid(IADOperator adOperator, string sid)
        {
            return FindOneByFilter<GroupObject>(adOperator, new Is(GroupAttributeNames.ObjectSid, sid));
        }

        /// <summary>
        /// Fine one group object by common name.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="cn">The common name.</param>
        /// <returns>One group object.</returns>
        public static GroupObject FindOneByCN(IADOperator adOperator, string cn)
        {
            return FindOneByFilter<GroupObject>(adOperator, new And(new IsGroup(), new Is(AttributeNames.CN, cn)));
        }

        /// <summary>
        /// Find all group objects.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <returns>All group objects.</returns>
        public static IList<GroupObject> FindAll(IADOperator adOperator)
        {
            return FindAllByFilter<GroupObject>(adOperator, new IsGroup());
        }

        /// <summary>
        /// Find all group objects by filter.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>All group objects by filter.</returns>
        public static IList<GroupObject> FindAll(IADOperator adOperator, IFilter filter)
        {
            return FindAllByFilter<GroupObject>(adOperator, new And(new IsGroup(), filter));
        }
    }
}
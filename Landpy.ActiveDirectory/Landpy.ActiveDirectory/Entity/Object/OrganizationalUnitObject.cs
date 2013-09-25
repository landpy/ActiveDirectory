﻿using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Attribute.Value;
using Landpy.ActiveDirectory.Entity.TypeAdapter;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The organizational unit AD object.
    /// </summary>
    public class OrganizationalUnitObject : ADObject
    {
        private string ou;
        private string street;
        private string city;
        private string stateOrProvince;
        private string co;
        private string c;
        private string managedBy;
        private IList<UserObject> users;
        private IList<ContactObject> contacts;
        private IList<ComputerObject> computers;
        private IList<OrganizationalUnitObject> organizationalUnits;

        /// <summary>
        /// The ou.
        /// </summary>
        public string OU
        {
            get
            {
                if (String.IsNullOrEmpty(this.ou))
                {
                    this.ou = new SingleLineAdapter(this.SearchResult.Properties[OrganizationalUnitAttributeNames.OU]).Value;
                }
                return this.ou;
            }
        }

        /// <summary>
        /// The street.
        /// </summary>
        public string Street
        {
            get
            {
                if (String.IsNullOrEmpty(this.street))
                {
                    this.street = new SingleLineAdapter(this.SearchResult.Properties[OrganizationalUnitAttributeNames.Street]).Value;
                }
                return this.street;
            }
            set
            {
                this.DirectoryEntry.Properties[OrganizationalUnitAttributeNames.Street].Value = value;
                this.street = value;
            }
        }

        /// <summary>
        /// The city.
        /// </summary>
        public string City
        {
            get
            {
                if (String.IsNullOrEmpty(this.city))
                {
                    this.city = new SingleLineAdapter(this.SearchResult.Properties[OrganizationalUnitAttributeNames.L]).Value;
                }
                return this.city;
            }
            set
            {
                this.DirectoryEntry.Properties[OrganizationalUnitAttributeNames.L].Value = value;
                this.city = value;
            }
        }

        /// <summary>
        /// The state / province.
        /// </summary>
        public string StateOrProvince
        {
            get
            {
                if (String.IsNullOrEmpty(this.stateOrProvince))
                {
                    this.stateOrProvince = new SingleLineAdapter(this.SearchResult.Properties[OrganizationalUnitAttributeNames.ST]).Value;
                }
                return this.stateOrProvince;
            }
            set
            {
                this.DirectoryEntry.Properties[OrganizationalUnitAttributeNames.ST].Value = value;
                this.stateOrProvince = value;
            }
        }

        /// <summary>
        /// The country or region.
        /// </summary>
        public string CO
        {
            get
            {
                if (String.IsNullOrEmpty(this.co))
                {
                    this.co = new SingleLineAdapter(this.SearchResult.Properties[OrganizationalUnitAttributeNames.CO]).Value;
                }
                return this.co;
            }
            set
            {
                this.DirectoryEntry.Properties[OrganizationalUnitAttributeNames.CO].Value = value;
                this.co = value;
            }
        }

        /// <summary>
        /// The country or region abbreviation (eg: CN).
        /// </summary>
        public string C
        {
            get
            {
                if (String.IsNullOrEmpty(this.c))
                {
                    this.c = new SingleLineAdapter(this.SearchResult.Properties[OrganizationalUnitAttributeNames.C]).Value;
                }
                return this.c;
            }
            set
            {
                this.DirectoryEntry.Properties[OrganizationalUnitAttributeNames.C].Value = value;
                this.c = value;
            }
        }

        /// <summary>
        /// The managed by user distinguish name.
        /// </summary>
        public string ManagedBy
        {
            get
            {
                if (String.IsNullOrEmpty(this.managedBy))
                {
                    this.managedBy = new SingleLineAdapter(this.SearchResult.Properties[ComputerAttributeNames.ManagedBy]).Value;
                }
                return this.managedBy;
            }
            set
            {
                this.DirectoryEntry.Properties[ComputerAttributeNames.ManagedBy].Value = value;
                this.managedBy = value;
            }
        }

        /// <summary>
        /// The child users.
        /// </summary>
        public IList<UserObject> Users
        {
            get
            {
                if (this.users == null)
                {
                    this.users = new List<UserObject>();
                    foreach (DirectoryEntry child in this.DirectoryEntry.Children)
                    {
                        using (child)
                        {
                            using (var directoryEntryRepository = new DirectoryEntryRepository(this.ADOperator))
                            {
                                var searchResult = directoryEntryRepository.GetSearchResult(new Is(AttributeNames.DistinguishedName, child.Properties[AttributeNames.DistinguishedName].Value.ToString()));
                                if (GetADObjectType(searchResult) == ADObjectType.User)
                                {
                                    this.users.Add(new UserObject(this.ADOperator, searchResult));
                                }
                            }
                        }
                    }
                }
                return this.users;
            }
        }

        /// <summary>
        /// The child contacts.
        /// </summary>
        public IList<ContactObject> Contacts
        {
            get
            {
                if (this.contacts == null)
                {
                    this.contacts = new List<ContactObject>();
                    foreach (DirectoryEntry child in this.DirectoryEntry.Children)
                    {
                        using (child)
                        {
                            using (var directoryEntryRepository = new DirectoryEntryRepository(this.ADOperator))
                            {
                                var searchResult = directoryEntryRepository.GetSearchResult(new Is(AttributeNames.DistinguishedName, child.Properties[AttributeNames.DistinguishedName].Value.ToString()));
                                if (GetADObjectType(searchResult) == ADObjectType.Contact)
                                {
                                    this.contacts.Add(new ContactObject(this.ADOperator, searchResult));
                                }
                            }
                        }
                    }
                }
                return this.contacts;
            }
        }

        /// <summary>
        /// The child computers.
        /// </summary>
        public IList<ComputerObject> Computers
        {
            get
            {
                if (this.computers == null)
                {
                    this.computers = new List<ComputerObject>();
                    foreach (DirectoryEntry child in this.DirectoryEntry.Children)
                    {
                        using (child)
                        {
                            using (var directoryEntryRepository = new DirectoryEntryRepository(this.ADOperator))
                            {
                                var searchResult = directoryEntryRepository.GetSearchResult(new Is(AttributeNames.DistinguishedName, child.Properties[AttributeNames.DistinguishedName].Value.ToString()));
                                if (GetADObjectType(searchResult) == ADObjectType.Computer)
                                {
                                    this.computers.Add(new ComputerObject(this.ADOperator, searchResult));
                                }
                            }
                        }
                    }
                }
                return this.computers;
            }
        }

        /// <summary>
        /// The child organizational units.
        /// </summary>
        public IList<OrganizationalUnitObject> OrganizationalUnits
        {
            get
            {
                if (this.organizationalUnits == null)
                {
                    this.organizationalUnits = new List<OrganizationalUnitObject>();
                    foreach (DirectoryEntry child in this.DirectoryEntry.Children)
                    {
                        using (child)
                        {
                            using (var directoryEntryRepository = new DirectoryEntryRepository(this.ADOperator))
                            {
                                var searchResult = directoryEntryRepository.GetSearchResult(new Is(AttributeNames.DistinguishedName, child.Properties[AttributeNames.DistinguishedName].Value.ToString()));
                                if (GetADObjectType(searchResult) == ADObjectType.OrganizationalUnit)
                                {
                                    this.organizationalUnits.Add(new OrganizationalUnitObject(this.ADOperator, searchResult));
                                }
                            }
                        }
                    }
                }
                return this.organizationalUnits;
            }
        }

        internal OrganizationalUnitObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
        }

        /// <summary>
        /// Add OU.
        /// </summary>
        /// <param name="ouName">OU name.</param>
        /// <returns>OU object.</returns>
        public OrganizationalUnitObject AddOrganizationalUnit(string ouName)
        {
            var ouDirectoryEntry = this.DirectoryEntry.Children.Add(String.Format(@"{0}={1}", OrganizationalUnitAttributeNames.OU, ouName), OrganizationalUnitAttributeValues.OrganizationalUnit);
            ouDirectoryEntry.CommitChanges();
            return FindOneByOU(this.ADOperator, ouName);
        }

        /// <summary>
        /// Add Group.
        /// </summary>
        /// <param name="groupName">Group name.</param>
        /// <returns>Group object.</returns>
        public GroupObject AddGroup(string groupName)
        {
            var groupDirectoryEntry = this.DirectoryEntry.Children.Add(String.Format(@"{0}={1}", AttributeNames.CN, groupName), GroupAttributeValues.Group);
            groupDirectoryEntry.CommitChanges();
            return GroupObject.FindOneByCN(this.ADOperator, groupName);
        }

        /// <summary>
        /// Add User.
        /// </summary>
        /// <param name="userName">User name.</param>
        /// <returns>User object.</returns>
        public UserObject AddUser(string userName)
        {
            var userDirectoryEntry = this.DirectoryEntry.Children.Add(String.Format(@"{0}={1}", AttributeNames.CN, userName), UserAttributeValues.User);
            userDirectoryEntry.CommitChanges();
            return UserObject.FindOneByCN(this.ADOperator, userName);
        }

        /// <summary>
        /// Fine one ou object by common name.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="ouName">The OU name.</param>
        /// <returns>One ou object.</returns>
        public static OrganizationalUnitObject FindOneByOU(IADOperator adOperator, string ouName)
        {
            OrganizationalUnitObject organizationalUnitObject;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                organizationalUnitObject = (from SearchResult searchResult in directoryEntryRepository.GetSearchResultCollection(new And(new IsOU(), new Is(OrganizationalUnitAttributeNames.OU, ouName)))
                                            select new OrganizationalUnitObject(adOperator, searchResult)).SingleOrDefault();
            }
            return organizationalUnitObject;
        }

        /// <summary>
        /// Find all ou objects.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <returns>All ou objects.</returns>
        public static IList<OrganizationalUnitObject> FindAll(IADOperator adOperator)
        {
            IList<OrganizationalUnitObject> organizationalUnitObjects;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                organizationalUnitObjects = (from SearchResult searchResult in directoryEntryRepository.GetSearchResultCollection(new And(new IsOU()))
                                             select new OrganizationalUnitObject(adOperator, searchResult)).ToList();
            }
            return organizationalUnitObjects;
        }

        /// <summary>
        /// Find all ou objects.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>All ou objects by filter.</returns>
        public static IList<OrganizationalUnitObject> FindAll(IADOperator adOperator, IFilter filter)
        {
            IList<OrganizationalUnitObject> organizationalUnitObjects;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                organizationalUnitObjects = (from SearchResult searchResult in directoryEntryRepository.GetSearchResultCollection(new And(new IsOU(), filter))
                                             select new OrganizationalUnitObject(adOperator, searchResult)).ToList();
            }
            return organizationalUnitObjects;
        }
    }
}
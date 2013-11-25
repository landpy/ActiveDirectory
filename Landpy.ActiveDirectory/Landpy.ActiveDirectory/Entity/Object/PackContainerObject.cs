using System.Collections.Generic;
using System.DirectoryServices;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The pack container AD object which contains children objects.
    /// </summary>
    public abstract class PackContainerObject : ADObject
    {
        private IList<UserObject> users;
        private IList<ContactObject> contacts;
        private IList<ComputerObject> computers;

        internal protected PackContainerObject(IADOperator adOperator, SearchResult searchResult) :
            base(adOperator, searchResult)
        {
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
                            var user = FindOneByFilter<UserObject>(this.ADOperator,
                                new And(
                                    new Is(AttributeNames.DistinguishedName, child.Properties[AttributeNames.DistinguishedName].Value.ToString()),
                                    new IsUser()
                                    ));
                            if (user != null)
                            {
                                this.users.Add(user);
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
                            var contact = FindOneByFilter<ContactObject>(this.ADOperator,
                                new And(
                                    new Is(AttributeNames.DistinguishedName, child.Properties[AttributeNames.DistinguishedName].Value.ToString()),
                                    new IsContact()
                                    ));
                            if (contact != null)
                            {
                                this.contacts.Add(contact);
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
                            var computer = FindOneByFilter<ComputerObject>(this.ADOperator,
                                new And(
                                    new Is(AttributeNames.DistinguishedName, child.Properties[AttributeNames.DistinguishedName].Value.ToString()),
                                    new IsComputer()));
                            if (computer != null)
                            {
                                this.computers.Add(computer);
                            }
                        }
                    }
                }
                return this.computers;
            }
        }
    }
}

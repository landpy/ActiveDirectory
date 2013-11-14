using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The container AD object.
    /// </summary>
    public class ContainerObject : ADObject
    {
        private IList<UserObject> users;
        private IList<ContactObject> contacts;
        private IList<ComputerObject> computers;

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

        internal ContainerObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
        }

        /// <summary>
        /// Find one container object by common name.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="cn">The common name.</param>
        /// <returns>One container object.</returns>
        public static ContainerObject FindOneByCN(IADOperator adOperator, string cn)
        {
            return FindOneByFilter<ContainerObject>(adOperator, new And(new IsContainer(), new Is(AttributeNames.CN, cn)));
        }

        /// <summary>
        /// Find all container objects.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <returns>All container objects.</returns>
        public static IList<ContainerObject> FindAll(IADOperator adOperator)
        {
            return FindAllByFilter<ContainerObject>(adOperator, new IsContainer());
        }

        /// <summary>
        /// Find all container objects with filter.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>All container objects with filter.</returns>
        public static IList<ContainerObject> FindAll(IADOperator adOperator, IFilter filter)
        {
            return FindAllByFilter<ContainerObject>(adOperator, new And(new IsContainer(), filter));
        }
    }
}
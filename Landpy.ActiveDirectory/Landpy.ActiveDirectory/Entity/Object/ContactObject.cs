using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Core.Filter;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The contact AD object.
    /// </summary>
    public class ContactObject : PersonObject
    {
        internal ContactObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
        }

        /// <summary>
        /// Find one contact object by common name.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="cn">The common name.</param>
        /// <returns>One contact object.</returns>
        public static ContactObject FindOneByCN(IADOperator adOperator, string cn)
        {
            ContactObject contactObject;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                contactObject = (from SearchResult searchResult in directoryEntryRepository.GetSearchResultCollection(new And(new IsContact(), new Is(AttributeNames.CN, cn)))
                                 select new ContactObject(adOperator, searchResult)).SingleOrDefault();
            }
            return contactObject;
        }

        /// <summary>
        /// Find all contact objects.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <returns>All contact objects.</returns>
        public static IList<ContactObject> FindAll(IADOperator adOperator)
        {
            IList<ContactObject> contactObjects;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                contactObjects = (from SearchResult searchResult in directoryEntryRepository.GetSearchResultCollection(new And(new IsContact()))
                                  select new ContactObject(adOperator, searchResult)).ToList();
            }
            return contactObjects;
        }

        /// <summary>
        /// Find all contact objects with filter.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>All contact objects with filter.</returns>
        public static IList<ContactObject> FindAll(IADOperator adOperator, IFilter filter)
        {
            IList<ContactObject> contactObjects;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                contactObjects = (from SearchResult searchResult in directoryEntryRepository.GetSearchResultCollection(new And(new IsContact(), filter))
                                  select new ContactObject(adOperator, searchResult)).ToList();
            }
            return contactObjects;
        }
    }
}
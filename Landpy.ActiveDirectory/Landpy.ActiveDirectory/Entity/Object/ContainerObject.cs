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
            ContainerObject containerObject;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                containerObject = (from SearchResult searchResult in directoryEntryRepository.GetSearchResultCollection(new And(new IsContainer(), new Is(AttributeNames.CN, cn)))
                                   select new ContainerObject(adOperator, searchResult)).SingleOrDefault();
            }
            return containerObject;
        }

        /// <summary>
        /// Find all container objects.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <returns>All container objects.</returns>
        public static IList<ContainerObject> FindAll(IADOperator adOperator)
        {
            IList<ContainerObject> containerObjects;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                containerObjects = (from SearchResult searchResult in directoryEntryRepository.GetSearchResultCollection(new And(new IsContainer()))
                                    select new ContainerObject(adOperator, searchResult)).ToList();
            }
            return containerObjects;
        }

        /// <summary>
        /// Find all container objects with filter.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>All container objects with filter.</returns>
        public static IList<ContainerObject> FindAll(IADOperator adOperator, IFilter filter)
        {
            IList<ContainerObject> containerObjects;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                containerObjects = (from SearchResult searchResult in directoryEntryRepository.GetSearchResultCollection(new And(new IsContainer(), filter))
                                    select new ContainerObject(adOperator, searchResult)).ToList();
            }
            return containerObjects;
        }
    }
}
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Entity.Object;

namespace Landpy.ActiveDirectory.Entity.Query
{
    public static class ADObjectQuery
    {
        public static IList<ADObject> List(IADOperator adOperator, IFilter filter)
        {
            List<ADObject> adObjects;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                adObjects = (from SearchResult searchResult in directoryEntryRepository.GetSearchResultCollection(filter)
                             select ADObject.GetADObject(adOperator, searchResult)).ToList();
            }
            return adObjects;
        }

        public static ADObject SingleAndDefault(IADOperator adOperator, IFilter filter)
        {
            ADObject adObject;
            using (var directoryEntryRepository = new DirectoryEntryRepository(adOperator))
            {
                adObject = ADObject.GetADObject(adOperator, directoryEntryRepository.GetSearchResult(filter));
            }
            return adObject;
        }
    }
}

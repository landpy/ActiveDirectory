using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Entity.Object;

namespace Landpy.ActiveDirectory.Entity.Query
{
    /// <summary>
    /// Query the AD objects.
    /// </summary>
    public static class ADObjectQuery
    {
        /// <summary>
        /// Get all the AD objects which is matched with the filter.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="filter">The root AD filter.</param>
        /// <returns>All the AD objects which is matched with the filter.</returns>
        public static IList<ADObject> List(IADOperator adOperator, IFilter filter)
        {
            return ADObject.FindAllByFilter<ADObject>(adOperator, filter);
        }

        /// <summary>
        /// Get the single AD object which is matched with the filter.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="filter">The root AD filter.</param>
        /// <returns>The single AD object which is matched with the filter.</returns>
        public static ADObject SingleAndDefault(IADOperator adOperator, IFilter filter)
        {
            return ADObject.FindOneByFilter<ADObject>(adOperator, filter);
        }
    }
}

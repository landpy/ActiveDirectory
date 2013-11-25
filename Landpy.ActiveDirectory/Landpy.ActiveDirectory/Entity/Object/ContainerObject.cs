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
    public class ContainerObject : PackContainerObject
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
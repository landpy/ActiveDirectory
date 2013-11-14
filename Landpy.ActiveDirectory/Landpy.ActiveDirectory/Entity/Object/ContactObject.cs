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
            return FindOneByFilter<ContactObject>(adOperator, new And(new IsContact(), new Is(AttributeNames.CN, cn)));
        }

        /// <summary>
        /// Find all contact objects.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <returns>All contact objects.</returns>
        public static IList<ContactObject> FindAll(IADOperator adOperator)
        {
            return FindAllByFilter<ContactObject>(adOperator, new IsContact());
        }

        /// <summary>
        /// Find all contact objects with filter.
        /// </summary>
        /// <param name="adOperator">The AD operator.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>All contact objects with filter.</returns>
        public static IList<ContactObject> FindAll(IADOperator adOperator, IFilter filter)
        {
            return FindAllByFilter<ContactObject>(adOperator, new And(new IsContact(), filter));
        }
    }
}
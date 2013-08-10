using System.DirectoryServices;
using Landpy.ActiveDirectory.Core;

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
    }
}
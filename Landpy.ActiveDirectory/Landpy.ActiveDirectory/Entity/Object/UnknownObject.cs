using System.DirectoryServices;
using Landpy.ActiveDirectory.Core;

namespace Landpy.ActiveDirectory.Entity.Object
{
    class UnknownObject : ADObject
    {
        internal UnknownObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
        }
    }
}

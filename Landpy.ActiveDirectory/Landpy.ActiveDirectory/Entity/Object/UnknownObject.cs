using System.DirectoryServices;
using Landpy.ActiveDirectory.Core;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The unknow AD object, always specifies the result is null object.
    /// </summary>
    public class UnknownObject : ADObject
    {
        internal UnknownObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
        }
    }
}

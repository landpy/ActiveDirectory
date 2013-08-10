using System.DirectoryServices;
using Landpy.ActiveDirectory.Core;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The inetOrgPerson obejct.
    /// </summary>
    public class InetOrgPersonObject : ADObject
    {
        internal InetOrgPersonObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
        }
    }
}
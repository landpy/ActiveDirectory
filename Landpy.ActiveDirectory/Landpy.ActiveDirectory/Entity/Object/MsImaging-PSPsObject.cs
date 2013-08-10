using System.DirectoryServices;
using Landpy.ActiveDirectory.Core;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The msImaging-PSPs AD object.
    /// </summary>
    public class MsImaging_PSPsObject : ADObject
    {
        internal MsImaging_PSPsObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
        }
    }
}
using System.DirectoryServices;
using Landpy.ActiveDirectory.Core;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The shared folder AD object.
    /// </summary>
    public class SharedFolderObject : ADObject
    {
        internal SharedFolderObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
        }
    }
}
using System.DirectoryServices;
using Landpy.ActiveDirectory.Core;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The container AD object.
    /// </summary>
    public class ContainerObject : PersonObject
    {
        internal ContainerObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
        }
    }
}
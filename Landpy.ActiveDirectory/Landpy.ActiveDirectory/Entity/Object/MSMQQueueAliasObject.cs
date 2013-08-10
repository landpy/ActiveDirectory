using System.DirectoryServices;
using Landpy.ActiveDirectory.Core;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The mSMQQueueAlias AD object.
    /// </summary>
    public class MSMQQueueAliasObject : ADObject
    {
        internal MSMQQueueAliasObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
        }
    }
}
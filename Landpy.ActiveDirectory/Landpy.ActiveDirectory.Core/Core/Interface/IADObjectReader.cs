using System.Collections.Generic;
using Landpy.ActiveDirectory.Filter;
using Landpy.ActiveDirectory.Object;

namespace Landpy.ActiveDirectory
{
    public interface IADObjectReader<ADObject> where ADObject : BaseADObject
    {
        ADObject ReadADObjectByFilter(IFilter filter);
        ICollection<ADObject> ReadADObjectsByFilter(IFilter filter);
    }
}

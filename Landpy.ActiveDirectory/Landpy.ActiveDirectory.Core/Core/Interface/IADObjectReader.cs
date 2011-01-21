using System;
using System.DirectoryServices;
using System.Collections.Generic;
using Landpy.ActiveDirectory.Object;
using Landpy.ActiveDirectory.Filter;

namespace Landpy.ActiveDirectory
{
    public interface IADObjectReader<ADObject> where ADObject : BaseADObject
    {
        ADObject ReadADObjectByFilter(IFilter filter);
        ICollection<ADObject> ReadADObjectsByFilter(IFilter filter);
    }
}

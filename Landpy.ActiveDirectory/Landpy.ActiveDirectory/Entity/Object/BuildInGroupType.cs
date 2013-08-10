using System;

namespace Landpy.ActiveDirectory.Entity.Object
{
    [Flags]
    enum BuildInGroupType
    {
        None = 0,
        Security = -2147483648,
        GlobalGroup = 2,
        LocalGroup = 4,
        DomainLocalGroup = 4,
        UniversalGroup = 8,
    }
}

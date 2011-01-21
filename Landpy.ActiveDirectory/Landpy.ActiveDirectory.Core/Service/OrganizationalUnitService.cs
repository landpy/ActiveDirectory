using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.Object;
using System.DirectoryServices;
using Landpy.ActiveDirectory.Filter;

namespace Landpy.ActiveDirectory.Service
{
    public class OrganizationalUnitService : ADObjectService<OrganizationalUnit>
    {
        public OrganizationalUnitService(OperatorSecurity operatorSecurity)
            : base(operatorSecurity)
        {
            this.filter = new OrganizationalUnitExpression();
        }
    }
}

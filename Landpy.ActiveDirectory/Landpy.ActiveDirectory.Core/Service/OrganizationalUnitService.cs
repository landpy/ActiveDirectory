using System;
using System.Collections.Generic;
using System.Text;
using Landpy.ActiveDirectory.Entity.Object;
using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Service
{
    public class OrganizationalUnitService : BaseService<OrganizationalUnit>
    {
        public OrganizationalUnitService(OperatorSecurity operatorSecurity)
            : base(operatorSecurity)
        {
        }

        public override OrganizationalUnit FindObjectByCN(string cn)
        {
            throw new NotImplementedException();
        }

        public override OrganizationalUnit FindObjectByObjectGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public override ICollection<OrganizationalUnit> FindObjectsByObjectClass(string objectClass)
        {
            throw new NotImplementedException();
        }

        public override bool Save(OrganizationalUnit adObject)
        {
            throw new NotImplementedException();
        }
    }
}

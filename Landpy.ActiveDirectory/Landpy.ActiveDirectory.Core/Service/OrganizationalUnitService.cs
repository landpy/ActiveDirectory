using Landpy.ActiveDirectory.Filter;
using Landpy.ActiveDirectory.Object;

namespace Landpy.ActiveDirectory.Service
{
    public class OrganizationalUnitService : ADObjectService<OrganizationalUnit>
    {
        public OrganizationalUnitService(OperatorSecurity operatorSecurity)
            : base(operatorSecurity)
        {
            this.filter = new OrganizationalUnitExpression();
        }

        public override void Flush()
        {
            this.filter = new OrganizationalUnitExpression();
        }
    }
}

using Landpy.ActiveDirectory.Filter;
using Landpy.ActiveDirectory.Object;

namespace Landpy.ActiveDirectory.Service
{
    public class UserService : ADObjectService<User>
    {
        public UserService(OperatorSecurity operatorSecurity)
            : base(operatorSecurity)
        {
            this.filter = new UserExpression();
        }
    }
}

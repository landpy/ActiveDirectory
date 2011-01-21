using Landpy.ActiveDirectory.CommonParam;
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

        public User FindObjectBySid(string sid)
        {
            this.filter = new IsExpressionDecorator(filter, AttributeNames.ObjectSid, sid);
            this.filter = new AndExpressionDecorator(filter);
            return this.adObjectReader.ReadADObjectByFilter(filter);
        }

        public override void Flush()
        {
            this.filter = new UserExpression();
        }
    }
}

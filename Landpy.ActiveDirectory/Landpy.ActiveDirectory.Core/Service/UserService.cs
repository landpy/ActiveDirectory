using Landpy.ActiveDirectory.Entity.Object;
using System.Collections.Generic;
using System.DirectoryServices;
using System;
using Landpy.ActiveDirectory.Entity.Filter;

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

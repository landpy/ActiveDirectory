using Landpy.ActiveDirectory.Entity.Object;
using System.Collections.Generic;
using System.DirectoryServices;
using System;
using Landpy.ActiveDirectory.Entity.Filter;

namespace Landpy.ActiveDirectory.Service
{
    public class UserService : BaseService<User>
    {
        public UserService(OperatorSecurity operatorSecurity)
            : base(operatorSecurity)
        {
            filter = new UserFilter();
        }
    }
}

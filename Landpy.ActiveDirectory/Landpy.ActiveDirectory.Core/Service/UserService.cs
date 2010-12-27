using Landpy.ActiveDirectory.Entity;
using System.Collections.Generic;
using System.DirectoryServices;
using System;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Service
{
    public class UserService : BaseService<User>
    {
        public UserService(OperatorSecurity operatorSecurity)
            : base(operatorSecurity)
        {
        }

        public override User FindObjectByCN(string cn)
        {
            string filter = String.Format("(&({0})({1}={2}))", FilterStrings.UserFilter, AttributeNames.CN, cn);
            return this.FindOne(filter);
        }

        public override User FindObjectByObjectGuid(Guid guid)
        {
            string filter = String.Format("(&({0})({1}={2}))", FilterStrings.UserFilter, AttributeNames.ObjectGUID, this.GetGUIDBinaryString(guid));
            return this.FindOne(filter);
        }

        public override ICollection<User> FindObjectsByObjectClass(string objectClass)
        {
            string filter = String.Format("(&({0})({1}={2}))", FilterStrings.UserFilter, AttributeNames.ObjectClass, objectClass);
            return this.FindAll(filter);
        }

        public override bool Save(User adObject)
        {
            bool isSuccess = false;
            return isSuccess;
        }
    }
}

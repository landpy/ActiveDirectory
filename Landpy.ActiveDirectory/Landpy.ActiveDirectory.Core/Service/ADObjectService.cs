using System.Collections.Generic;
using System;
using System.DirectoryServices;
using System.Text;
using Landpy.ActiveDirectory.Object;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Filter;
using Landpy.ActiveDirectory.CommonParam;

namespace Landpy.ActiveDirectory.Service
{
    public class ADObjectService<ADObject> where ADObject : BaseADObject
    {
        #region Member Data

        protected OperatorSecurity operatorSecurity;
        protected IFilter filter;
        protected IADObjectReader<ADObject> adObjectReader;

        #endregion

        #region Constructor Method

        protected ADObjectService(OperatorSecurity operatorSecurity)
        {
            this.operatorSecurity = operatorSecurity;
            this.adObjectReader = new ADObjectReader<ADObject>(this.operatorSecurity);
        }

        #endregion

        #region Interface Method

        public ADObject FindObjectByCN(string cn)
        {
            filter = new IsExpressionDecorator(filter, AttributeNames.CN, cn);
            filter = new AndExpressionDecorator(filter);
            return this.adObjectReader.ReadADObjectByFilter(filter);
        }

        public ADObject FindObjectByObjectGuid(Guid guid)
        {
            filter = new IsExpressionDecorator(filter, AttributeNames.ObjectGUID, ConvertUtility.ConvertGuidToGuidBinaryString(guid));
            filter = new AndExpressionDecorator(filter);
            return this.adObjectReader.ReadADObjectByFilter(filter);
        }

        public ADObject FindObjectByName(string name)
        {
            filter = new IsExpressionDecorator(filter, AttributeNames.Name, name);
            filter = new AndExpressionDecorator(filter);
            return this.adObjectReader.ReadADObjectByFilter(filter);
        }

        public ICollection<ADObject> FindObjectsByObjectClass(string objectClass)
        {
            filter = new IsExpressionDecorator(filter, AttributeNames.ObjectClass, objectClass);
            filter = new AndExpressionDecorator(filter);
            return this.adObjectReader.ReadADObjectsByFilter(filter);
        }

        #endregion

    }
}

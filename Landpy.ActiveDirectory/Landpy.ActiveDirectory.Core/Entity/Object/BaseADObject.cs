using System.DirectoryServices;
using Landpy.ActiveDirectory.Entity.Attribute;

namespace Landpy.ActiveDirectory.Entity.Object
{
    public abstract class BaseADObject
    {
        protected AttributeProvider attributeProvider;
        protected OperatorSecurity operatorSecurity;

        protected BaseADObject(SearchResult searchResult, OperatorSecurity operatorSecurity)
        {
            if (searchResult != null)
            {
                this.attributeProvider = new AttributeProvider(searchResult);
            }
            this.operatorSecurity = operatorSecurity;
        }
    }
}

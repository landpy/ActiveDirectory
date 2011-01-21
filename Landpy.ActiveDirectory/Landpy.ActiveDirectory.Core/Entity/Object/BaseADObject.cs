using System.DirectoryServices;
using Landpy.ActiveDirectory.Attribute;

namespace Landpy.ActiveDirectory.Object
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

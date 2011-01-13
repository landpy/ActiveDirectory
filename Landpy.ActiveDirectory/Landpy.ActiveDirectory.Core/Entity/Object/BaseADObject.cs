using System.DirectoryServices;
using Landpy.ActiveDirectory.Entity.Attribute;

namespace Landpy.ActiveDirectory.Entity.Object
{
    public abstract class BaseADObject
    {
        protected AttributeProvider attributeProvider;

        protected BaseADObject(SearchResult searchResult)
        {
            if (searchResult != null)
            {
                this.attributeProvider = new AttributeProvider(searchResult);
            }
        }
    }
}

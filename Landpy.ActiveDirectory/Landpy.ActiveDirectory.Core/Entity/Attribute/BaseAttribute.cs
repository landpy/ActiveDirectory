using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Attribute
{
    public abstract class BaseAttribute
    {
        protected string name;
        protected object value;
        protected ResultPropertyValueCollection resultPropertyValueCollection;

        public object Value
        {
            get { return value; }
        }

        public string Name
        {
            get { return name; }
        }

        protected BaseAttribute(ResultPropertyValueCollection resultPropertyValueCollection)
        {
            this.resultPropertyValueCollection = resultPropertyValueCollection;
        }
    }
}

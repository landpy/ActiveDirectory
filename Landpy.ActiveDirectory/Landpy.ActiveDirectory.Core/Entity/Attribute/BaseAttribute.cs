using System;
using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Entity.Attribute
{
    public abstract class BaseAttribute<T>
    {
        protected T value;
        protected ResultPropertyValueCollection resultPropertyValueCollection;

        public T Value
        {
            get { return value; }
        }

        protected BaseAttribute(ResultPropertyValueCollection resultPropertyValueCollection)
        {
            this.resultPropertyValueCollection = resultPropertyValueCollection;
        }
    }
}

using System.Collections;
using System.Collections.Generic;

namespace Landpy.ActiveDirectory.Attribute
{
    class AttributeSet : IEnumerable
    {
        private Dictionary<string, object> attributes;

        object this[string name]
        {
            get
            {
                return this.attributes[name];
            }
        }

        public AttributeSet()
        {
            this.attributes = new Dictionary<string, object>();
        }

        public void Add(BaseAttribute baseAttribute)
        {
            this.attributes.Add(baseAttribute.Name, baseAttribute.Value);
        }

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            yield return attributes;
        }

        #endregion
    }
}
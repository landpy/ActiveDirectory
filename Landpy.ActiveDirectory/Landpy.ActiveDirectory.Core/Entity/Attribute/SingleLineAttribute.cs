using System;
using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Attribute
{
    public class SingleLineAttribute : BaseAttribute
    {
        public SingleLineAttribute(ResultPropertyValueCollection resultPropertyValueCollection)
            : base(resultPropertyValueCollection)
        {
            if (resultPropertyValueCollection != null &&
                resultPropertyValueCollection.Count > 0 &&
                resultPropertyValueCollection[0] != null)
            {
                this.value = resultPropertyValueCollection[0];
            }
        }
    }
}

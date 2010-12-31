using System;
using System.DirectoryServices;

namespace Landpy.ActiveDirectory.Entity.Attribute
{
    public class GuidAttribute : BaseAttribute
    {
        public GuidAttribute(ResultPropertyValueCollection resultPropertyValueCollection)
            : base(resultPropertyValueCollection)
        {
            if (resultPropertyValueCollection != null &&
                resultPropertyValueCollection.Count > 0 &&
                resultPropertyValueCollection[0] != null)
            {
                this.value = new Guid(resultPropertyValueCollection[0] as byte[]);
            }
        }
    }
}

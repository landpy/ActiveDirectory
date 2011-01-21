using System;
using System.Collections.Generic;

namespace Landpy.ActiveDirectory.LQL
{
    [Serializable]
    public class Where
    {
        public List<Attribute> Attributes
        {
            get;
            set;
        }

        public Where()
        {
            this.Attributes = new List<Attribute>();
        }
    }
}

using System.Collections.Generic;
using System.DirectoryServices;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The pack AD object which contains children objects.
    /// </summary>
    public abstract class PackObject : PackContainerObject
    {
        private IList<OrganizationalUnitObject> organizationalUnits;

        protected PackObject(IADOperator adOperator, SearchResult searchResult)
            : base(adOperator, searchResult)
        {
        }

        /// <summary>
        /// The child organizational units.
        /// </summary>
        public IList<OrganizationalUnitObject> OrganizationalUnits
        {
            get
            {
                if (this.organizationalUnits == null)
                {
                    this.organizationalUnits = new List<OrganizationalUnitObject>();
                    foreach (DirectoryEntry child in this.DirectoryEntry.Children)
                    {
                        using (child)
                        {
                            var organizationalUnit = FindOneByFilter<OrganizationalUnitObject>(this.ADOperator,
                                new And(
                                    new Is(AttributeNames.DistinguishedName, child.Properties[AttributeNames.DistinguishedName].Value.ToString()),
                                    new IsOU()));
                            if (organizationalUnit != null)
                            {
                                this.organizationalUnits.Add(organizationalUnit);
                            }
                        }
                    }
                }
                return this.organizationalUnits;
            }
        }
    }
}

using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.TestSuite.Common;
using NUnit.Framework;
using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Entity.Attribute.Name;

namespace Landpy.ActiveDirectory.TestSuite.FilterModule
{
    class EndWithFilterUnitTest : BaseUnitTest
    {
        [TestCase]
        public void TestEndWithFilter()
        {
            IFilter filter = new EndWith(AttributeNames.CN, "p");
            Assert.AreEqual("(cn=*p)", filter.BuildFilter());
        }
    }
}

using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.TestSuite.Common;
using NUnit.Framework;
using Contains = Landpy.ActiveDirectory.Core.Filter.Expression.Contains;

namespace Landpy.ActiveDirectory.TestSuite.FilterModule
{
    class ContainsFilterUnitTest : BaseUnitTest
    {
        [TestCase]
        public void TestContainsFilter()
        {
            IFilter filter = new Contains(AttributeNames.CN, "ng");
            Assert.AreEqual("(cn=*ng*)", filter.BuildFilter());
        }
    }
}

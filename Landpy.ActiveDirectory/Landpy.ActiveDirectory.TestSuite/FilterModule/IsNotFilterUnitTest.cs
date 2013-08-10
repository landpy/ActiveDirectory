using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.TestSuite.Common;
using NUnit.Framework;
using Landpy.ActiveDirectory.Entity.Attribute.Name;

namespace Landpy.ActiveDirectory.TestSuite.FilterModule
{
    class IsNotFilterUnitTest : BaseUnitTest
    {
        [TestCase]
        public void TestIsFilter()
        {
            IFilter filter = new IsNot(AttributeNames.CN, "pangxiaoliang");
            Assert.AreEqual("(!cn=pangxiaoliang)", filter.BuildFilter());
        }
    }
}

using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.TestSuite.Common;
using NUnit.Framework;

namespace Landpy.ActiveDirectory.TestSuite.FilterModule
{
    class GreaterThanFilterUnitTest : BaseUnitTest
    {
        [TestCase]
        public void TestGreaterThanFilter()
        {
            IFilter filter = new GreaterThan(AttributeNames.CN, "pangxiaoliang");
            Assert.AreEqual("(cn>=pangxiaoliang)", filter.BuildFilter());
        }
    }
}

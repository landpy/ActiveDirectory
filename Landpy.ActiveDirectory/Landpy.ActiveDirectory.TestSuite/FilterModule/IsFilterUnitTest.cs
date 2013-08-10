using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.TestSuite.Common;
using NUnit.Framework;
using Is = Landpy.ActiveDirectory.Core.Filter.Expression.Is;
using Landpy.ActiveDirectory.Entity.Attribute.Name;

namespace Landpy.ActiveDirectory.TestSuite.FilterModule
{
    class IsFilterUnitTest : BaseUnitTest
    {
        [TestCase]
        public void TestIsFilter()
        {
            IFilter filter = new Is(AttributeNames.CN,"pangxiaoliang");
            Assert.AreEqual("(cn=pangxiaoliang)", filter.BuildFilter());
        }
    }
}

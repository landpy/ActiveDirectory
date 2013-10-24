using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.TestSuite.Common;
using NUnit.Framework;

namespace Landpy.ActiveDirectory.TestSuite.FilterModule
{
    class ApproxFilterUnitTest : BaseUnitTest
    {
        [TestCase]
        public void TestApproxFilter()
        {
            IFilter filter = new Approx(AttributeNames.CN, "pangxiaoliang");
            Assert.AreEqual("(cn~=pangxiaoliang)", filter.BuildFilter());
        }
    }
}

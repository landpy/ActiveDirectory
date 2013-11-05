using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.TestSuite.Common;
using NUnit.Framework;

namespace Landpy.ActiveDirectory.TestSuite.FilterModule
{
    class LessThanFilterUnitTest : BaseUnitTest
    {
        [TestCase]
        public void TestLessThanFilter()
        {
            IFilter filter = new LessThanOrEqualTo(AttributeNames.CN, "pang");
            Assert.AreEqual("(cn<=pang)", filter.BuildFilter());
        }
    }
}

using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.TestSuite.Common;
using NUnit.Framework;
using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Entity.Attribute.Name;

namespace Landpy.ActiveDirectory.TestSuite.FilterModule
{
    class StartWithFilterUnitTest : BaseUnitTest
    {
        [TestCase]
        public void TestStartWithFilter()
        {
            IFilter filter = new StartWith(AttributeNames.CN, "p");
            Assert.AreEqual("(cn=p*)", filter.BuildFilter());
        }
    }
}

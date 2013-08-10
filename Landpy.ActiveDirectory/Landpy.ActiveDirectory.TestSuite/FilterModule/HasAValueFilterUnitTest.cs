using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.TestSuite.Common;
using NUnit.Framework;

namespace Landpy.ActiveDirectory.TestSuite.FilterModule
{
    class HasAValueFilterUnitTest : BaseUnitTest
    {
        [TestCase]
        public void TestHasValueFilter()
        {
            IFilter filter = new HasAValue(AttributeNames.CN);
            Assert.AreEqual("(cn=*)", filter.BuildFilter());
        }
    }
}

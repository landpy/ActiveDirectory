using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.TestSuite.Common;
using NUnit.Framework;

namespace Landpy.ActiveDirectory.TestSuite.FilterModule
{
    class CustomFilterUnitTest : BaseUnitTest
    {
        private IFilter CustomFilter { get; set; }

        protected override void SetUp()
        {
            this.CustomFilter = new Custom("(cn=pangxiaoliang)");
        }

        [TestCase]
        public void TestCustomFilter()
        {
            Assert.AreEqual("(cn=pangxiaoliang)", this.CustomFilter.BuildFilter());
        }
    }
}

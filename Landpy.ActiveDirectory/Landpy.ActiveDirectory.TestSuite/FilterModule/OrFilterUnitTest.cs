using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.TestSuite.Common;
using Landpy.TestFramwork.Configuration;
using NUnit.Framework;

namespace Landpy.ActiveDirectory.TestSuite.FilterModule
{
    class OrFilterUnitTest : BaseUnitTest
    {
        private string OrFilterString { get; set; }

        protected override void SetUp()
        {
            this.OrFilterString = TF.GetConfig().Properties["OrFilterString"];
        }

        [TestCase]
        public void TestSimpleAndFilter()
        {
            IFilter filter = new Or(new IsOU(), new IsUser());
            Assert.AreEqual(this.OrFilterString, filter.BuildFilter());
        }
    }
}

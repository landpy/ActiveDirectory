using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.TestSuite.Common;
using Landpy.TestFramwork.Configuration;
using NUnit.Framework;

namespace Landpy.ActiveDirectory.TestSuite.FilterModule
{
    class AndFilterUnitTest : BaseUnitTest
    {
        private string AndFilterString { get; set; }

        protected override void SetUp()
        {
            this.AndFilterString = TF.GetConfig().Properties["AndFilterString"];
        }

        [TestCase]
        public void TestSimpleAndFilter()
        {
            IFilter filter = new And(new IsOU(), new IsUser());
            Assert.AreEqual(this.AndFilterString, filter.BuildFilter());
        }
    }
}

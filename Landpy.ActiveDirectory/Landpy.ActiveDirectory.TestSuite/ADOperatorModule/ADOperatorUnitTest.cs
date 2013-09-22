using NUnit.Framework;
using Landpy.ActiveDirectory.Core;
namespace Landpy.ActiveDirectory.TestSuite.ADOperatorModule
{
    [TestFixture]
    class ADOperatorUnitTest
    {
        private IADOperator ADOperator { get; set; }
        private string UserLoginName { get; set; }
        private string UserPassword { get; set; }
        private string OperateDomainName { get; set; }

        [TestFixtureSetUp]
        public void SetUp()
        {
            this.UserLoginName = @"landpy\pangxiaoliang";
            this.UserPassword = @"abc123,./";
            this.OperateDomainName = @"landpy";
            this.ADOperator = new ADOperator(this.UserLoginName, this.UserPassword, this.OperateDomainName);
        }

        [TestCase]
        public void TestGetOperatorInfo()
        {
            var operatorInfo = this.ADOperator.GetOperatorInfo();
            Assert.AreEqual(this.UserLoginName, operatorInfo.UserLoginName);
            Assert.AreEqual(this.UserPassword, operatorInfo.Password);
            Assert.AreEqual(this.OperateDomainName, operatorInfo.OperateDomainName);
        }
    }
}

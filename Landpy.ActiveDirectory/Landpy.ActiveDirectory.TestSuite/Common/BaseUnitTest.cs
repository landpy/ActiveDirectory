using Landpy.ActiveDirectory.Core;
using Landpy.TestFramwork.Configuration;
using Moq;
using NUnit.Framework;

namespace Landpy.ActiveDirectory.TestSuite.Common
{
    [TestFixture]
    class BaseUnitTest
    {
        protected IADOperator ADOperator { get; set; }

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var mock = new Mock<IADOperator>();
            var adOperatorInfo = new ADOperatorInfo
                        {
                            UserLoginName = TF.GetConfig().Properties["DomainUserName"],
                            Password = TF.GetConfig().Properties["DomainUserPassword"],
                            OperateDomainName = TF.GetConfig().Properties["DomainName"],
                        };
            mock.Setup(m => m.GetOperatorInfo()).Returns(adOperatorInfo);
            this.ADOperator = mock.Object;
            this.SetUp();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            this.TearDown();
        }

        protected virtual void SetUp()
        {
        }

        protected virtual void TearDown()
        {
        }
    }
}

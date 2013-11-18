using System;
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
        protected IADOperator AnonymousADOperator { get; set; }
        protected IADOperator LargeAmountADOperator { get; set; }

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            // Normal
            var mock = new Mock<IADOperator>();
            var adOperatorInfo = new ADOperatorInfo
                        {
                            UserLoginName = TF.GetConfig().Properties["DomainUserName"],
                            Password = TF.GetConfig().Properties["DomainUserPassword"],
                            OperateDomainName = TF.GetConfig().Properties["DomainName"],
                        };
            mock.Setup(m => m.GetOperatorInfo()).Returns(adOperatorInfo);
            this.ADOperator = mock.Object;
            // Anonymous
            var anonymousMock = new Mock<IADOperator>();
            adOperatorInfo = new ADOperatorInfo
                        {
                            UserLoginName = String.Empty,
                            Password = String.Empty,
                            OperateDomainName = TF.GetConfig().Properties["DomainName"],
                        };
            anonymousMock.Setup(m => m.GetOperatorInfo()).Returns(adOperatorInfo);
            this.AnonymousADOperator = anonymousMock.Object;
            // Large amount
            var largeAmountMock = new Mock<IADOperator>();
            var largeAmountADOperatorInfo = new ADOperatorInfo
            {
                UserLoginName = TF.GetConfig().Properties["LargeAmountDomainUserName"],
                Password = TF.GetConfig().Properties["LargeAmountDomainUserPassword"],
                OperateDomainName = TF.GetConfig().Properties["LargeAmountDomainName"],
            };
            largeAmountMock.Setup(m => m.GetOperatorInfo()).Returns(largeAmountADOperatorInfo);
            this.LargeAmountADOperator = largeAmountMock.Object;
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

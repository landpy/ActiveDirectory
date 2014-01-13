using System.Net;
using NUnit.Framework;
using System;
using Moq;
using SharePointBoost.TestFramework;

namespace YourNameSpace.TargetClassModule
{
    [TestFixture]
    class TargetClassUnitTest
    {
        private IProxyObject ProxyObject { get; set; }
        private string HostName { get; set; }

        [TestFixtureSetUp]
        public void SetUp()
        {
            this.HostName = TFConfiguration.GetTFConfiguration().Properties["HostName"];
            var mock = new Mock<IMockObject>();
            mock.Setup(m => m.GetMockName()).Returns("MoqMockName");
            this.ProxyObject = new ProxyObject(mock.Object);
        }

        [TestCase]
        public void TestShowMock()
        {
            Assert.AreEqual(String.Format(@"{0}:MoqMockName", this.HostName), this.ProxyObject.MockObjectName);
        }
    }

    #region Need to be removed, just as an example.

    public interface IMockObject
    {
        string GetMockName();
    }

    public interface IProxyObject
    {
        string MockObjectName { get; }
    }

    public class ProxyObject : IProxyObject
    {
        private string mockObjectName;
        private IMockObject MockObject { get; set; }
        public string MockObjectName
        {
            get
            {
                if (String.IsNullOrEmpty(this.mockObjectName))
                {
                    this.mockObjectName = this.GetMockObjectName();
                }
                return this.mockObjectName;
            }
        }

        public ProxyObject(IMockObject mockObject)
        {
            this.MockObject = mockObject;
        }

        public string GetMockObjectName()
        {
            return String.Format(@"{0}:{1}", Dns.GetHostName().ToLower(), this.MockObject.GetMockName());
        }
    }

    #endregion

}

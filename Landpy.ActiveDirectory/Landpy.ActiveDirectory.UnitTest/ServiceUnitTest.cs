using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Landpy.ActiveDirectory.Service;
using Landpy.ActiveDirectory.Entity.Object;

namespace Landpy.ActiveDirectory.UnitTest
{
    /// <summary>
    /// Summary description for ServiceUnitTest
    /// </summary>
    [TestClass]
    public class ServiceUnitTest
    {
        private UserService userService;
        private OrganizationalUnitService organizationalUnitService;

        public ServiceUnitTest()
        {
            OperatorSecurity operatorSecurity = new OperatorSecurity("LDAP://192.168.6.67", "Administrator", "liu-pxl821102");
            this.userService = new UserService(operatorSecurity);
            this.organizationalUnitService = new OrganizationalUnitService(operatorSecurity);
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestADObjectService()
        {
            User user = userService.FindObjectByCN("pangxiaoliang");
            Assert.AreEqual<Guid>(new Guid("325d590f-f344-4575-8362-569f47a108ff"), user.ObjectGUID);
            Assert.AreEqual<string>("NewOU", user.OrganizationalUnit.Name);
            OrganizationalUnit ou = this.organizationalUnitService.FindObjectByName("LandpyTest");
            Assert.AreEqual<Guid>(new Guid("b23f6bf4-b4ad-40bc-8593-3629c5475f49"), ou.ObjectGUID);
            OrganizationalUnit userOU = this.organizationalUnitService.FindObjectByName("PangLevel1OU");
        }
    }
}

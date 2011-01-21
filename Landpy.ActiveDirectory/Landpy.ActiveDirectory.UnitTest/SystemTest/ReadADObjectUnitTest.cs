using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;
using Landpy.ActiveDirectory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Landpy.ActiveDirectory.Object;
using Landpy.ActiveDirectory.Filter;
using Landpy.ActiveDirectory.CommonParam;
using Landpy.ActiveDirectory.Service;

namespace Landpy.ActiveDirectory.UnitTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ReadADObjectUnitTest
    {
        public ReadADObjectUnitTest()
        {
        }

        private OperatorSecurity operatorSecurity;
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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            operatorSecurity = new OperatorSecurity("LDAP://192.168.6.67", "Administrator", "liu-pxl821102");
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestADObjectReader()
        {
            IADObjectReader<User> reader = new ADObjectReader<User>(this.operatorSecurity);
            IFilter filter = new UserExpression();
            filter = new EndWithExpressionDecorator(filter, AttributeNames.CN, "liang");
            filter = new AndExpressionDecorator(filter);
            User user = reader.ReadADObjectByFilter(filter);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void TestService()
        {
            UserService userService = new UserService(this.operatorSecurity);
            User user = userService.FindObjectByCN("pangxiaoliang");
            Assert.AreEqual<string>("NewOU", user.OrganizationalUnit.Name);
        }
    }
}

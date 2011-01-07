using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;
using Landpy.ActiveDirectory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Landpy.ActiveDirectory.UnitTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        public UnitTest()
        {
            OperatorSecurity operatorSecurity = new OperatorSecurity("LDAP://192.168.6.67", "Administrator", "liu-pxl821102");
            this.adObjectReader = new ADObjectReader(operatorSecurity);
            this.adObjectWriter = new ADObjectWriter(operatorSecurity);
        }

        private TestContext testContextInstance;
        private IADObjectReader adObjectReader;
        private IADObjectWriter adObjectWriter;

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
        public void TestADObjectReader()
        {
            string filter = "cn=pangxiaoliang";
            SearchResult searchResult = this.adObjectReader.ReadSearchResultByFilter(filter);
            if (searchResult != null)
            {
                string inputDescription = "Landpy Test Description";
                //this.adObjectWriter.WriteSearchResult(searchResult,"description",""
                //SearchResult searchResult = this.adObjectReader.ReadSearchResultByFilter("cn=pangxiaoliang");
                //string description = searchResult.Properties["Description"][0].ToString();
                //Assert.AreEqual<string>(inputDescription, description);
            }
            else
            {
                Assert.Fail("Please check the filter string which get the SearchResult. (filter string: {0})", filter);
            }
        }
    }
}

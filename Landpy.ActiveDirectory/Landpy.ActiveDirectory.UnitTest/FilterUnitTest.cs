using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.CommonParam;
using Landpy.ActiveDirectory.Entity.Filter;

namespace Landpy.ActiveDirectory.UnitTest
{
    [TestClass]
    public class FilterUnitTest
    {
        private TestContext testContextInstance;
        private IFilter filter;
        private IADObjectReader adObjectReader;

        public FilterUnitTest()
        {
            OperatorSecurity operatorSecurity = new OperatorSecurity("LDAP://192.168.6.67", "Administrator", "liu-pxl821102");
            this.adObjectReader = new ADObjectReader(operatorSecurity);
        }

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

        [TestMethod]
        public void TestFilter()
        {
            filter = new UserFilter();
            filter = new IsFilterDecorator(filter, AttributeNames.CN, "pangxiaoliang");
            filter = new AndFilterDecorator(filter);
            System.DirectoryServices.SearchResult searchResutl = this.adObjectReader.ReadSearchResultByFilter(filter.BuildFilter());
            Assert.IsNotNull(searchResutl);

            filter = new UserFilter();
            Dictionary<string,string> dictionary = new Dictionary<string,string>();
            dictionary.Add(AttributeNames.CN, "pangxiaoliang");
            dictionary.Add(AttributeNames.CO, "China");
            filter = new IsFilterDecorator(filter, dictionary);
            filter = new AndFilterDecorator(filter);
            searchResutl = this.adObjectReader.ReadSearchResultByFilter(filter.BuildFilter());
            Assert.IsNotNull(searchResutl);
        }
    }
}

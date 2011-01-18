﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.CommonParam;
using Landpy.ActiveDirectory.Entity.Filter;
using Landpy.ActiveDirectory.Entity.Object;

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
        public void TestExpressionFilter()
        {
            filter = new UserExpression();
            filter = new IsExpressionDecorator(filter, AttributeNames.CN, "pangxiaoliang");
            filter = new AndExpressionDecorator(filter);
            System.DirectoryServices.SearchResult searchResult = this.adObjectReader.ReadSearchResultByFilter(filter.BuildFilter());
            Assert.IsNotNull(searchResult);

            filter = new UserExpression();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add(AttributeNames.CN, "pangxiaoliang");
            dictionary.Add(AttributeNames.CO, "China");
            filter = new IsExpressionDecorator(filter, dictionary);
            filter = new AndExpressionDecorator(filter);
            searchResult = this.adObjectReader.ReadSearchResultByFilter(filter.BuildFilter());
            Assert.IsNotNull(searchResult);

            filter = new UserExpression();
            filter = new IsNotExpressionDecorator(filter, AttributeNames.CN, "pangxiaoliang");
            filter = new AndExpressionDecorator(filter);
            System.DirectoryServices.SearchResultCollection searchResults = this.adObjectReader.ReadSearchResultsByFilter(filter.BuildFilter());

            foreach (System.DirectoryServices.SearchResult result in searchResults)
            {
                User user = new User(result);
                if (user.CN == "pangxiaoliang")
                {
                    Assert.Fail("The IsFilterDecorator has some issue.");
                }
            }
        }

        [TestMethod]
        public void TestCombinationFilter()
        {
            IFilter filter1 = new UserExpression();
            filter1 = new IsExpressionDecorator(filter1, AttributeNames.CN, "pangxiaoliang");
            filter1 = new IsNotExpressionDecorator(filter1, AttributeNames.CN, "Landpy");
            filter1 = new AndExpressionDecorator(filter1);

            IFilter filter2 = new AllExpression();
            filter2 = new IsExpressionDecorator(filter2, AttributeNames.CO, "China");
            filter2 = new IsExpressionDecorator(filter2, AttributeNames.CO, "England");
            filter2 = new OrExpressionDecorator(filter2);

            IFilter filter = new AndFilter();
            filter.Add(filter1);
            filter.Add(filter2);

            Assert.AreEqual<string>("(&(&(objectCategory=person)(cn=pangxiaoliang)(!cn=Landpy))(|(co=China)(co=England)))", filter.BuildFilter());
        }
    }
}
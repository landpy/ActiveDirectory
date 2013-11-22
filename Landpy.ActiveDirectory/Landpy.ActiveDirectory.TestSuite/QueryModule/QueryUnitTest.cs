﻿using System;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Attribute.Value;
using Landpy.TestFramwork.Configuration;
using NUnit.Framework;
using Landpy.ActiveDirectory.TestSuite.Common;
using Landpy.ActiveDirectory.Entity.Query;
using Landpy.ActiveDirectory.Entity.Object;
using Is = Landpy.ActiveDirectory.Core.Filter.Expression.Is;

namespace Landpy.ActiveDirectory.TestSuite.QueryModule
{
    class QueryUnitTest : BaseUnitTest
    {
        private string UserCn { get; set; }
        private Guid GroupGuid { get; set; }
        private string QueryRootOUName { get; set; }

        protected override void SetUp()
        {
            this.UserCn = TF.GetConfig().Properties["UserCn"];
            this.GroupGuid = new Guid(TF.GetConfig().Properties["GroupGuid"]);
            this.QueryRootOUName = TF.GetConfig().Properties["QueryRootOUName"];
        }

        [TestCase]
        public void TestQueryIsUser()
        {
            Assert.AreNotEqual(0, ADObjectQuery.List(this.ADOperator, new IsUser()).Count);
            foreach (var adObject in ADObjectQuery.List(this.ADOperator, new IsUser()))
            {
                using (adObject)
                {
                    Assert.AreEqual(ADObjectType.User, adObject.Type, adObject.Path);
                }
            }
        }

        [TestCase]
        public void TestQueryIsPerson()
        {
            Assert.AreNotEqual(0, ADObjectQuery.List(this.ADOperator, new IsUser()).Count);
            foreach (var adObject in ADObjectQuery.List(this.ADOperator, new IsPerson()))
            {
                using (adObject)
                {
                    Assert.IsTrue((adObject.Type == ADObjectType.User || adObject.Type == ADObjectType.Contact), adObject.Path);
                }
            }
        }

        [TestCase]
        public void TestQueryIsUserOrIsContact()
        {
            var persons = ADObjectQuery.List(this.ADOperator, new IsPerson());
            var userAndContacts = ADObjectQuery.List(this.ADOperator, new Or(new IsContact(), new IsUser()));
            Assert.AreNotEqual(0, persons.Count);
            Assert.AreNotEqual(0, userAndContacts.Count);
            Assert.AreEqual(persons.Count, userAndContacts.Count);
            foreach (var adObject in userAndContacts)
            {
                using (adObject)
                {
                    Assert.IsTrue((adObject.Type == ADObjectType.User || adObject.Type == ADObjectType.Contact), adObject.Path);
                }
            }
            foreach (var adObject in persons)
            {
                using (adObject)
                {
                    Assert.IsTrue((adObject.Type == ADObjectType.User || adObject.Type == ADObjectType.Contact), adObject.Path);
                }
            }
        }

        [TestCase]
        public void TestQueryOneUser()
        {
            var adObject = ADObjectQuery.SingleAndDefault(this.ADOperator, new And(new IsUser(), new Is(AttributeNames.CN, this.UserCn)));
            using (adObject)
            {
                Assert.IsNotNull(adObject);
                if (adObject.Type == ADObjectType.User)
                {
                    var user = adObject as UserObject;
                    Assert.IsNotNull(user);
                    Assert.AreEqual(this.UserCn, user.CN);
                }
            }
        }

        [TestCase]
        public void TestQueryIsComputer()
        {
            Assert.AreNotEqual(0, ADObjectQuery.List(this.ADOperator, new IsComputer()).Count);
            foreach (var adObject in ADObjectQuery.List(this.ADOperator, new IsComputer()))
            {
                using (adObject)
                {
                    Assert.AreEqual(ADObjectType.Computer, adObject.Type, adObject.Path);
                }
            }
        }

        [TestCase]
        public void TestQueryGuid()
        {
            var adObject = ADObjectQuery.SingleAndDefault(this.ADOperator, new Is(AttributeNames.ObjectGuid, Guid.Empty.ToString()));
            Assert.IsInstanceOf(typeof(UnknownObject), adObject);
            adObject = ADObjectQuery.SingleAndDefault(this.ADOperator, new Is(AttributeNames.ObjectGuid, this.GroupGuid.ToString()));
            using (adObject)
            {
                Assert.IsInstanceOf(typeof(GroupObject), adObject);
            }

            adObject = ADObjectQuery.SingleAndDefault(this.ADOperator, new Custom(String.Format(@"{0}={1}", AttributeNames.ObjectGuid, this.GroupGuid)));
            Assert.IsNotInstanceOf(typeof(UnknownObject), adObject);
            using (adObject)
            {
                Assert.IsInstanceOf(typeof(GroupObject), adObject);
            }

            adObject = ADObjectQuery.SingleAndDefault(this.ADOperator, new Custom(String.Format(@"(&({0}={1})({2}={3}))",
                AttributeNames.ObjectGuid, this.GroupGuid, AttributeNames.ObjectClass, GroupAttributeValues.Group)));
            Assert.IsNotInstanceOf(typeof(UnknownObject), adObject);
            using (adObject)
            {
                Assert.IsInstanceOf(typeof(GroupObject), adObject);
            }
        }

        [TestCase]
        public void TestLargeADObjectAmount()
        {
            var adObjects = ADObjectQuery.List(this.LargeAmountADOperator, new IsUser());
            Assert.Greater(adObjects.Count, 1000);
            foreach (var adObject in adObjects)
            {
                using (adObject)
                {
                }
            }
            Assert.Pass(String.Format(@"AD object amount is {0}", adObjects.Count));
        }

        [TestCase]
        public void TestQueryFromPath()
        {
            // The ou must be contains a tree structure children.
            using (var organizationalUnitObject = OrganizationalUnitObject.FindOneByOU(this.ADOperator, this.QueryRootOUName))
            {
                var userObjects = ADObjectQuery.List(this.ADOperator, new IsUser(), organizationalUnitObject.Path, QueryScopeType.OneLevel);
                Assert.Greater(userObjects.Count, 0);
                foreach (var userObject in userObjects)
                {
                    Assert.AreEqual(ADObjectType.User, userObject.Type);
                    Console.WriteLine(userObject.CN);
                }
                var allUserObjects = ADObjectQuery.List(this.ADOperator, new IsUser(), organizationalUnitObject.Path, QueryScopeType.Subtree);
                Assert.Greater(allUserObjects.Count, 0);
                foreach (var userObject in allUserObjects)
                {
                    Assert.AreEqual(ADObjectType.User, userObject.Type);
                    Console.WriteLine(userObject.CN);
                }
                Assert.Greater(allUserObjects.Count, userObjects.Count);
            }
        }
    }
}

using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
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

        protected override void SetUp()
        {
            this.UserCn = TF.GetConfig().Properties["UserCn"];
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


    }
}

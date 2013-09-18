using Landpy.ActiveDirectory.TestSuite.Common;
using NUnit.Framework;
using Landpy.TestFramwork.Configuration;
using Landpy.ActiveDirectory.Entity.Object;
using Is = Landpy.ActiveDirectory.Core.Filter.Expression.Is;
using Landpy.ActiveDirectory.Entity.Attribute.Name;

namespace Landpy.ActiveDirectory.TestSuite.ADObjectModule
{
    class ContactObjectUnitTest : BaseUnitTest
    {
        private string ContactCN { get; set; }
        private string ContactDescription { get; set; }

        protected override void SetUp()
        {
            this.ContactCN = TF.GetConfig().Properties["ContactCN"];
            this.ContactDescription = TF.GetConfig().Properties["ContactDescription"];
        }

        [TestCase]
        public void TestFindOneByCN()
        {
            using (var contactObject = ContactObject.FindOneByCN(this.ADOperator, this.ContactCN))
            {
                Assert.AreEqual(this.ContactDescription, contactObject.Description);
            }
        }

        [TestCase]
        public void TestFindAll()
        {
            var contactObjects = ContactObject.FindAll(this.ADOperator);
            Assert.Greater(contactObjects.Count, 0);
            foreach (var contactObject in contactObjects)
            {
                using (contactObject)
                {
                    Assert.AreEqual(ADObjectType.Contact, contactObject.Type);
                }
            }
        }

        [TestCase]
        public void TestFindAllWithFilter()
        {
            var contactObjects = ContactObject.FindAll(this.ADOperator, new Is(AttributeNames.CN, this.ContactCN));
            Assert.AreEqual(1, contactObjects.Count);
        }
    }
}

using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Object;
using Landpy.ActiveDirectory.TestSuite.Common;
using Landpy.TestFramwork.Configuration;
using NUnit.Framework;
using System;
using Contains = Landpy.ActiveDirectory.Core.Filter.Expression.Contains;
using Is = Landpy.ActiveDirectory.Core.Filter.Expression.Is;

namespace Landpy.ActiveDirectory.TestSuite.FilterModule
{
    class ComplexFilterUnitTest : BaseUnitTest
    {
        private string ComplexFilterString { get; set; }

        protected override void SetUp()
        {
            this.ComplexFilterString = TF.GetConfig().Properties["ComplexFilterString"];
        }

        [TestCase]
        public void TestComplexFilter()
        {
            // 1. CN end with "liu", Mail conatains "live" (Eg: mv@live.cn), job title is "Dev" and AD object type is user.
            // 2. CN start with "pang", Mail conatains "live" (Eg: mv@live.cn), job title is "Dev" and AD object type is user.
            IFilter filter =
                new And(
                    new IsUser(),
                    new Contains(PersonAttributeNames.Mail, "live"),
                    new Is(PersonAttributeNames.Title, "Dev"),
                    new Or(
                            new StartWith(AttributeNames.CN, "pang"),
                            new EndWith(AttributeNames.CN, "liu")
                        )
                    );
            Assert.AreEqual(this.ComplexFilterString, filter.BuildFilter());
            // Output the user object display name.
            foreach (var userObject in UserObject.FindAll(this.ADOperator, filter))
            {
                using (userObject)
                {
                    Console.WriteLine(@"{0}-{1}", userObject.DisplayName, userObject.Email);
                }
            }
        }
    }
}

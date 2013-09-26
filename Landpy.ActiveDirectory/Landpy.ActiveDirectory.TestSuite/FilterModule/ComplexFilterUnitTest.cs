using Landpy.ActiveDirectory.Core.Filter;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Object;
using Landpy.ActiveDirectory.TestSuite.Common;
using Landpy.TestFramwork.Configuration;
using NUnit.Framework;
using System;
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
            // Query condition:
            // 1. Belongs to "pangxiaoliangOU" OU,CN start with "pang", AD object type is user.
            // 2. Belongs to "pangxiaoliangOU" OU, CN end with "liu" and Mail is "mv@live.cn",  AD object type is user.
            IFilter filter =
                new And(
                    new IsUser(),
                    new Is(OrganizationalUnitAttributeNames.OU, "pangxiaoliangOU"),
                    new Or(
                            new StartWith(AttributeNames.CN, "pang"),
                            new And(
                                new EndWith(AttributeNames.CN, "liu"),
                                new Is(PersonAttributeNames.Mail, "mv@live.cn")
                                )
                        )
                    );
            Assert.AreEqual(this.ComplexFilterString, filter.BuildFilter());
            // Output the user object display name.
            foreach (var userObject in UserObject.FindAll(this.ADOperator, filter))
            {
                using (userObject)
                {
                    Console.WriteLine(userObject.DisplayName);
                }
            }
        }
    }
}

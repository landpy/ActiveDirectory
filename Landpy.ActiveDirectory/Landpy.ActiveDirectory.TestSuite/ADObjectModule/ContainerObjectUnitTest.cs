﻿using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Object;
using Landpy.ActiveDirectory.TestSuite.Common;
using Landpy.TestFramwork.Configuration;
using Is = Landpy.ActiveDirectory.Core.Filter.Expression.Is;
using NUnit.Framework;

namespace Landpy.ActiveDirectory.TestSuite.ADObjectModule
{
    class ContainerObjectUnitTest : BaseUnitTest
    {
        private string ContainerCN { get; set; }
        private string ContainerDescription { get; set; }

        protected override void SetUp()
        {
            this.ContainerCN = TF.GetConfig().Properties["ContainerCN"];
            this.ContainerDescription = TF.GetConfig().Properties["ContainerDescription"];
        }

        [TestCase]
        public void TestFindOneByCN()
        {
            using (var containerObject = ContainerObject.FindOneByCN(this.ADOperator, this.ContainerCN))
            {
                Assert.AreEqual(this.ContainerDescription, containerObject.Description);
            }
        }

        [TestCase]
        public void TestFindAll()
        {
            var containerObjects = ContainerObject.FindAll(this.ADOperator);
            Assert.Greater(containerObjects.Count, 0);
            foreach (var containerObject in containerObjects)
            {
                using (containerObject)
                {
                    Assert.AreEqual(ADObjectType.Container, containerObject.Type);
                }
            }
        }

        [TestCase]
        public void TestFindAllWithFilter()
        {
            var containerObjects = ContainerObject.FindAll(this.ADOperator, new Is(AttributeNames.CN, this.ContainerCN));
            Assert.AreEqual(1, containerObjects.Count);
        }
    }
}

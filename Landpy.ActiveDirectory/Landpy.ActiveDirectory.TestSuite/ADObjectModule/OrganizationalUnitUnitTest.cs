﻿using System;
using Landpy.ActiveDirectory.Entity.Attribute.Name;
using Landpy.ActiveDirectory.Entity.Object;
using Landpy.ActiveDirectory.TestSuite.Common;
using NUnit.Framework;
using Landpy.TestFramwork.Configuration;
using Is = Landpy.ActiveDirectory.Core.Filter.Expression.Is;

namespace Landpy.ActiveDirectory.TestSuite.ADObjectModule
{
    class OrganizationalUnitUnitTest : BaseUnitTest
    {
        private string OrganizaionalUnitOU { get; set; }
        private string OrganizaionalUnitStreet { get; set; }

        protected override void SetUp()
        {
            this.OrganizaionalUnitOU = TF.GetConfig().Properties["OrganizaionalUnitOU"];
            this.OrganizaionalUnitStreet = TF.GetConfig().Properties["OrganizaionalUnitStreet"];
        }

        [TestCase]
        public void TestOrganizationalUnitObjectFindAll()
        {
            var organizationalUnitObjects = OrganizationalUnitObject.FindAll(this.ADOperator);
            Assert.AreNotEqual(0, organizationalUnitObjects.Count);
            foreach (OrganizationalUnitObject organizationalUnitObject in organizationalUnitObjects)
            {
                using (organizationalUnitObject)
                {
                    Console.WriteLine(organizationalUnitObject.Path);
                }
            }
        }

        [TestCase]
        public void TestOrganizationalUnitObjectFindAllWithFilter()
        {
            var organizationalUnitObjects = OrganizationalUnitObject.FindAll(this.ADOperator, new Is(OrganizationalUnitAttributeNames.OU, this.OrganizaionalUnitOU));
            foreach (OrganizationalUnitObject organizationalUnitObject in organizationalUnitObjects)
            {
                using (organizationalUnitObject)
                {
                    Assert.AreEqual(this.OrganizaionalUnitOU, organizationalUnitObject.OU);
                }
            }
        }

        [TestCase]
        public void TestOrganizationalUnitObjectFindOne()
        {
            using (var organizationalUnitObject = OrganizationalUnitObject.FindOneByOU(this.ADOperator, this.OrganizaionalUnitOU))
            {
                foreach (UserObject userObject in organizationalUnitObject.Users)
                {
                    Console.WriteLine(userObject.Name);
                    Console.WriteLine(userObject.DistinguishedName);
                    Console.WriteLine(userObject.Type);
                }
                foreach (ContactObject contactObject in organizationalUnitObject.Contacts)
                {
                    Console.WriteLine(contactObject.Name);
                    Console.WriteLine(contactObject.DistinguishedName);
                    Console.WriteLine(contactObject.Type);
                }
                foreach (ComputerObject computerObject in organizationalUnitObject.Computers)
                {
                    Console.WriteLine(computerObject.Name);
                    Console.WriteLine(computerObject.DistinguishedName);
                    Console.WriteLine(computerObject.Type);
                }
                foreach (OrganizationalUnitObject childOrganizationalUnitObject in organizationalUnitObject.OrganizationalUnits)
                {
                    Console.WriteLine(childOrganizationalUnitObject.Name);
                    Console.WriteLine(childOrganizationalUnitObject.DistinguishedName);
                    Console.WriteLine(childOrganizationalUnitObject.Type);
                }
                Assert.AreEqual(this.OrganizaionalUnitStreet, organizationalUnitObject.Street);
            }
        }

        [TestCase]
        public void TestAddOrganizationalUnitObject()
        {
            using (var organizationalUnitObject = OrganizationalUnitObject.FindOneByOU(this.ADOperator, this.OrganizaionalUnitOU))
            {
                using (var addOrganizationalUnitObject = organizationalUnitObject.AddOrganizationalUnit("LandpyDemoOU"))
                {
                    addOrganizationalUnitObject.Delete();
                }
            }
        }

        [TestCase]
        public void TestAddGroupObject()
        {
            using (var organizationalUnitObject = OrganizationalUnitObject.FindOneByOU(this.ADOperator, this.OrganizaionalUnitOU))
            {
                using (var addGroupObject = organizationalUnitObject.AddGroup("LandpyDemoGroup"))
                {
                    addGroupObject.Delete();
                }
            }
        }

        [TestCase]
        public void TestAddUserObject()
        {
            using (var organizationalUnitObject = OrganizationalUnitObject.FindOneByOU(this.ADOperator, this.OrganizaionalUnitOU))
            {
                using (var addUserObject = organizationalUnitObject.AddUser("LandpyDemoUser"))
                {
                    addUserObject.Delete();
                }
            }
        }
    }
}

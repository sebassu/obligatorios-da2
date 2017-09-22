using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    public class LocationTests
    {
        private static Location testingLocation;

        [TestInitialize]
        public void TestSetup()
        {
            testingLocation = Location.InstanceForTestingPurposes();
        }

        //Location Name
        [TestMethod]
        public void LocationForTestingPurposesTest()
        {
            Assert.AreEqual("Location name", testingLocation.Name);
            Assert.AreEqual(LocationType.PORT, testingLocation.Type);
            Assert.AreEqual(0, testingLocation.Id);
        }

        [TestMethod]
        public void LocationSetValidNameTest()
        {
            testingLocation.Name = "Another name";
            Assert.AreEqual("Another name", testingLocation.Name);
        }

        [TestMethod]
        public void LocationSetValidNameCompoundTest()
        {
            testingLocation.Name = "  Some place ";
            Assert.AreEqual("Some place", testingLocation.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(LocationException))]
        public void LocationSetInvalidNameNumbersTest()
        {
            testingLocation.Name = "12345";
        }

        [TestMethod]
        [ExpectedException(typeof(LocationException))]
        public void LocationSetInvalidNameEmptyTest()
        {
            testingLocation.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(LocationException))]
        public void LocationSetInvalidNameOnlySpacesTest()
        {
            testingLocation.Name = "     ";
        }

        [TestMethod]
        [ExpectedException(typeof(LocationException))]
        public void LocationSetInvalidNameNullTest()
        {
            testingLocation.Name = null;
        }

        [TestMethod]
        [ExpectedException(typeof(LocationException))]
        public void LocationSetInvalidNamePunctuationTest()
        {
            testingLocation.Name = "!@$#%^";
        }

        //Vehicle id
        [TestMethod]
        public void LocationSetIdValidTest()
        {
            testingLocation.Id = 3;
            Assert.AreEqual(3, testingLocation.Id);
        }
    }
}

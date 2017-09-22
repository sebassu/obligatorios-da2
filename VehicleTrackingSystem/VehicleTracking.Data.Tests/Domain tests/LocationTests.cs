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
            testingLocation.Name = "Another place";
            Assert.AreEqual("Another place", testingLocation.Name);
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

        //Location id
        [TestMethod]
        public void LocationSetIdValidTest()
        {
            testingLocation.Id = 3;
            Assert.AreEqual(3, testingLocation.Id);
        }

        //Location Factory method
        [TestMethod]
        public void LocationParameterFactoryMethodValidTest()
        {
            testingLocation = Location.CreateNewLocation(LocationType.PORT, "Puerto de Punta del Este");
            Assert.AreEqual(0, testingLocation.Id);
            Assert.AreEqual(LocationType.PORT, testingLocation.Type);
            Assert.AreEqual("Puerto de Punta del Este", testingLocation.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(LocationException))]
        public void LocationParameterFactoryMethodInvalidNameTest()
        {
            testingLocation = Location.CreateNewLocation(LocationType.PORT, "!@#$%^");
        }
    }
}

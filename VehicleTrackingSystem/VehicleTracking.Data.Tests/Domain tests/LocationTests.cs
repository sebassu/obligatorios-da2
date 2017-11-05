using VehicleTracking_Data_Entities;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LocationTests
    {
        private static Location testingLocation;

        [TestInitialize]
        public void TestSetup()
        {
            testingLocation = Location.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void LocationInstanceForTestingPurposesTest()
        {
            Assert.AreEqual(0, testingLocation.Id);
            Assert.AreEqual("Lugar inválido", testingLocation.Name);
            Assert.AreEqual(LocationType.PORT, testingLocation.Type);
        }

        [TestMethod]
        public void LocationSetIdValidTest()
        {
            testingLocation.Id = 3;
            Assert.AreEqual(3, testingLocation.Id);
        }

        #region NameProperty tests
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
            testingLocation.Name = " \t\t \n\n\t   ";
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
        #endregion

        #region FactoryMethod tests
        [TestMethod]
        public void LocationParameterFactoryMethodValidTest()
        {
            testingLocation = Location.CreateNewLocation(LocationType.PORT, "Puerto de Punta del Este");
            Assert.AreEqual(0, testingLocation.Id);
            Assert.AreEqual(LocationType.PORT, testingLocation.Type);
            Assert.AreEqual("Puerto de Punta del Este", testingLocation.Name);
        }
        #endregion

        [TestMethod]
        [ExpectedException(typeof(LocationException))]
        public void LocationParameterFactoryMethodInvalidNameTest()
        {
            testingLocation = Location.CreateNewLocation(LocationType.PORT, "!@#$%^");
        }

        #region Equals tests
        [TestMethod]
        public void LocationEqualsNullTest()
        {
            Assert.AreNotEqual(testingLocation, null);
        }

        [TestMethod]
        public void LocationEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingLocation, someRandomObject);
        }

        [TestMethod]
        public void LocationEqualsReflexiveTest()
        {
            Assert.AreEqual(testingLocation, testingLocation);
        }

        [TestMethod]
        public void LocationEqualsSymmetricTest()
        {
            Location secondTestingLocation = Location.InstanceForTestingPurposes();
            Assert.AreEqual(testingLocation, secondTestingLocation);
            Assert.AreEqual(secondTestingLocation, testingLocation);
        }
        #endregion

        #region GetHashCode test
        [TestMethod]
        public void LocationGetHashCodeTest()
        {
            object testingLocationAsObject = testingLocation;
            Assert.AreEqual(testingLocationAsObject.GetHashCode(), testingLocation.GetHashCode());
        }
        #endregion

        #region ToString tests
        [TestMethod]
        public void LocationToStringTest1()
        {
            Assert.AreEqual("Lugar inválido.", testingLocation.ToString());
        }

        [TestMethod]
        public void LocationToStringTest2()
        {
            testingLocation.Name = "Puerto de Montevideo";
            Assert.AreEqual("Puerto de Montevideo.", testingLocation.ToString());
        }
        #endregion
    }
}
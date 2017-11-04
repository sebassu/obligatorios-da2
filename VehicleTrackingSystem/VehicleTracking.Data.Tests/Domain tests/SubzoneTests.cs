using Domain;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SubzoneTests
    {
        private static Zone testingZone;
        private static Subzone testingSubzone;
        private static readonly IReadOnlyList<Subzone> subzoneList =
            new List<Subzone> { testingSubzone }.AsReadOnly();

        [TestInitialize]
        public void TestSetup()
        {
            testingZone = Zone.InstanceForTestingPurposes();
            testingSubzone = Subzone.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void SubzoneForTestingPurposesTest()
        {
            Assert.AreEqual(0, testingSubzone.Id);
            Assert.AreEqual("Subzona inválida", testingSubzone.Name);
            Assert.AreEqual(3, testingSubzone.Capacity);
            Assert.AreEqual(testingZone, testingSubzone.Container);
        }

        [TestMethod]
        public void SubzoneSetIdValidTest()
        {
            testingSubzone.Id = 42;
            Assert.AreEqual(42, testingSubzone.Id);
        }

        [TestMethod]
        public void SubzoneSetValidNameTest()
        {
            testingSubzone.Name = "A subzone";
            Assert.AreEqual("A subzone", testingSubzone.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneSetInvalidNameOnlyNumbersTest()
        {
            testingSubzone.Name = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneSetInvalidNamePunctuationTest()
        {
            testingSubzone.Name = "!@.$#% *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneSetInvalidNameOnlySpacesTest()
        {
            testingSubzone.Name = " \n\n  \t\t \n\t  ";
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneSetInvalidNameEmptyTest()
        {
            testingSubzone.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void ZoneSetInvalidNameNullTest()
        {
            testingSubzone.Name = null;
        }

        [TestMethod]
        public void SubzoneSetValidCapacityTest()
        {
            testingSubzone.Capacity = 20;
            Assert.AreEqual(20, testingSubzone.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneSetInvalidCapacityLessThanMinimumTest()
        {
            testingSubzone.Capacity = 0;
        }

        [TestMethod]
        public void SubzoneSetValidContainerZoneTest()
        {
            Zone alternativeZone = Zone.CreateNewZone("Alternative zone", 3);
            testingSubzone.Container = alternativeZone;
            Assert.AreEqual(alternativeZone, testingSubzone.Container);
        }

        [TestMethod]
        public void SubzoneSetNullContainerValidTest()
        {
            testingSubzone.Container = null;
        }

        [TestMethod]
        public void SubzoneParameterFactoryMethodValidTest()
        {
            testingSubzone = Subzone.CreateNewSubzone("Some subzone", 26, testingZone);
            Assert.AreEqual(0, testingSubzone.Id);
            Assert.AreEqual("Some subzone", testingSubzone.Name);
            Assert.AreEqual(26, testingSubzone.Capacity);
            Assert.AreEqual(testingZone, testingSubzone.Container);
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneParameterFactoryMethodInvalidNameTest()
        {
            testingSubzone = Subzone.CreateNewSubzone("!@#$%", 23, testingZone);
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneParameterFactoryMethodInvalidCapacityTest()
        {
            testingSubzone = Subzone.CreateNewSubzone("Another subzone", 0, testingZone);
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SubzoneParameterFactoryMethodInvalidContainerZoneTest()
        {
            testingSubzone = Subzone.CreateNewSubzone("Another subzone", 23, null);
        }

        [TestMethod]
        public void SubzoneEqualsReflexiveTest()
        {
            Assert.AreEqual(testingSubzone, testingSubzone);
        }

        [TestMethod]
        public void SubzoneEqualsSymmetricTest()
        {
            Subzone secondTestingSubzone = Subzone.InstanceForTestingPurposes();
            Assert.AreEqual(testingSubzone, secondTestingSubzone);
            Assert.AreEqual(secondTestingSubzone, testingSubzone);
        }

        [TestMethod]
        public void SubzoneEqualsTransitiveTest()
        {
            Zone zone2 = Zone.InstanceForTestingPurposes();
            Zone zone3 = Zone.InstanceForTestingPurposes();
            testingSubzone = Subzone.CreateNewSubzone("Subzone1", 4, testingZone);
            Subzone secondTestingSubzone = Subzone.CreateNewSubzone("Subzone1", 4, zone2);
            Subzone thirdTestingSubzone = Subzone.CreateNewSubzone("Subzone1", 4, zone3);
            Assert.AreEqual(testingSubzone, secondTestingSubzone);
            Assert.AreEqual(secondTestingSubzone, thirdTestingSubzone);
            Assert.AreEqual(testingSubzone, thirdTestingSubzone);
        }

        [TestMethod]
        public void SubzoneEqualsDifferentSubzonesTest()
        {
            Zone zone2 = Zone.InstanceForTestingPurposes();
            testingSubzone = Subzone.CreateNewSubzone("Subzone1", 8, testingZone);
            testingSubzone.Id = 1;
            Subzone secondTestingSubzone = Subzone.CreateNewSubzone("Subzone1", 8, zone2);
            secondTestingSubzone.Id = 2;
            Assert.AreNotEqual(testingSubzone, secondTestingSubzone);
        }

        [TestMethod]
        public void SubzoneEqualsNullTest()
        {
            Assert.AreNotEqual(testingSubzone, null);
        }

        [TestMethod]
        public void SubzoneEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingSubzone, someRandomObject);
        }

        [TestMethod]
        public void SubzoneGetHashCodeTest()
        {
            object testingSubzoneAsObject = testingSubzone;
            Assert.AreEqual(testingSubzoneAsObject.GetHashCode(),
                testingSubzone.GetHashCode());
        }

        [TestMethod]
        public void SubzoneSetVehiclesValidTest()
        {
            var vehiclesToSet = new List<Vehicle>();
            testingSubzone.Vehicles = vehiclesToSet;
            Assert.AreSame(vehiclesToSet, testingSubzone.Vehicles);
        }

        [TestMethod]
        public void SubzoneToStringTest1()
        {
            Assert.AreEqual("Zona inválida/Subzona inválida",
                testingSubzone.ToString());
        }

        [TestMethod]
        public void SubzoneToStringTest2()
        {
            testingSubzone.Container.Name = "A";
            testingSubzone.Name = "B";
            Assert.AreEqual("A/B", testingSubzone.ToString());
        }

        [TestMethod]
        public void SubzoneCanAddValidTest()
        {
            Vehicle someVehicle = Vehicle.InstanceForTestingPurposes();
            Assert.IsTrue(testingSubzone.CanAdd(someVehicle));
        }

        [TestMethod]
        public void SubzoneCanAddRepeatedVehicleInvalidTest()
        {
            Vehicle someVehicle = Vehicle.InstanceForTestingPurposes();
            testingSubzone.Vehicles.Add(someVehicle);
            Assert.IsFalse(testingSubzone.CanAdd(someVehicle));
        }

        [TestMethod]
        public void SubzoneCanAddNullVehicleInvalidTest()
        {
            Assert.IsFalse(testingSubzone.CanAdd(null));
        }

        [TestMethod]
        public void SubzoneCanAddExceedingMaximumCapacityInvalidTest()
        {
            testingSubzone.Capacity = 1;
            Vehicle someVehicle = Vehicle.InstanceForTestingPurposes();
            testingSubzone.Vehicles.Add(someVehicle);
            Vehicle someOtherVehicle = Vehicle.InstanceForTestingPurposes();
            Assert.IsFalse(testingSubzone.CanAdd(someOtherVehicle));
        }
    }
}
using System.Linq;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ZoneTests
    {
        private static Zone testingZone;
        private static Subzone testingSubzone;

        [TestInitialize]
        public void TestSetup()
        {
            testingZone = Zone.InstanceForTestingPurposes();
            testingSubzone = Subzone.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void ZoneForTestingPurposesTest()
        {
            Assert.AreEqual(0, testingZone.Id);
            Assert.AreEqual("Zona inválida", testingZone.Name);
        }

        [TestMethod]
        public void SubzoneSetIdValidTest()
        {
            testingZone.Id = 42;
            Assert.AreEqual(42, testingZone.Id);
        }

        [TestMethod]
        public void SubzoneForTestingPurposesTest()
        {
            Assert.AreEqual("Subzona inválida", testingSubzone.Name);
            Assert.AreEqual(Zone.InstanceForTestingPurposes(),
                testingSubzone.Container);
        }

        [TestMethod]
        public void ZoneSetValidNameTest()
        {
            testingZone.Name = "A zone";
            Assert.AreEqual("A zone", testingZone.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneSetInvalidNameOnlyNumbersTest()
        {
            testingZone.Name = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneSetInvalidNamePunctuationTest()
        {
            testingZone.Name = "!@.$#% *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneSetInvalidNameOnlySpacesTest()
        {
            testingZone.Name = " \n\n  \t\t \n\t  ";
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneSetInvalidNameEmptyTest()
        {
            testingZone.Name = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneSetInvalidNameNullTest()
        {
            testingZone.Name = null;
        }

        [TestMethod]
        public void ZoneoneSetValidCapacityTest()
        {
            testingZone.Capacity = 23;
            Assert.AreEqual(23, testingZone.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneSetInvalidCapacityLessThanMinimumTest()
        {
            testingZone.Capacity = 0;
        }

        [TestMethod]
        public void ZoneParameterFactoryMethodValidTest()
        {
            testingZone = Zone.CreateNewZone("Zone 1", 5);
            Assert.AreEqual(0, testingZone.Id);
            Assert.AreEqual("Zone 1", testingZone.Name);
            Assert.AreEqual(5, testingZone.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneParameterFactoryMethodInvalidNameTest()
        {
            testingZone = Zone.CreateNewZone("!@#$%", 23);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneParameterFactoryMethodInvalidCapacityTest()
        {
            testingZone = Zone.CreateNewZone("Another subzone", 0);
        }

        [TestMethod]
        public void ZoneEqualsReflexiveTest()
        {
            Assert.AreEqual(testingZone, testingZone);
        }

        [TestMethod]
        public void ZoneEqualsSymmetricTest()
        {
            Zone secondTestingZone = Zone.InstanceForTestingPurposes();
            Assert.AreEqual(testingZone, secondTestingZone);
            Assert.AreEqual(secondTestingZone, testingZone);
        }

        [TestMethod]
        public void ZoneEqualsTransitiveTest()
        {
            testingZone = Zone.CreateNewZone("Zone2", 4);
            Zone secondTestingZone = Zone.CreateNewZone("Zone2", 4);
            Zone thirdTestingZone = Zone.CreateNewZone("Zone2", 4);
            Assert.AreEqual(testingZone, secondTestingZone);
            Assert.AreEqual(secondTestingZone, thirdTestingZone);
            Assert.AreEqual(testingZone, thirdTestingZone);
        }

        [TestMethod]
        public void ZoneEqualsDifferentSubzonesTest()
        {
            testingZone = Zone.CreateNewZone("Zone1", 8);
            testingZone.Id = 1;
            Zone secondTestingZone = Zone.CreateNewZone("Zone1", 8);
            secondTestingZone.Id = 2;
            Assert.AreNotEqual(testingZone, secondTestingZone);
        }

        [TestMethod]
        public void ZoneEqualsNullTest()
        {
            Assert.AreNotEqual(testingZone, null);
        }

        [TestMethod]
        public void ZoneEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingZone, someRandomObject);
        }

        [TestMethod]
        public void ZoneGetHashCodeTest()
        {
            object testingZoneAsObject = testingZone;
            Assert.AreEqual(testingZoneAsObject.GetHashCode(), testingZone.GetHashCode());
        }

        [TestMethod]
        public void ZoneSetSubzonesValidTest()
        {
            var subzonesToSet = new List<Subzone>();
            testingZone.Subzones = subzonesToSet;
            Assert.AreSame(subzonesToSet, testingZone.Subzones);
        }

        [TestMethod]
        public void ZoneToStringTest1()
        {
            Assert.AreEqual("Zona inválida", testingZone.ToString());
        }

        [TestMethod]
        public void ZoneToStringTest2()
        {
            var nameToSet = "In the zone";
            testingZone.Name = nameToSet;
            Assert.AreEqual(nameToSet, testingZone.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneAddSubzoneExceedingMaximumCapacityInvalidTest()
        {
            Zone testingZone = Zone.InstanceForTestingPurposes();
            testingZone.Capacity = 2;
            Subzone someSubzone = Subzone.InstanceForTestingPurposes();
            someSubzone.Capacity = 99;
            testingZone.AddSubzone(someSubzone);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneAddRepeatedSubzoneInvalidTest()
        {
            Zone testingZone = Zone.InstanceForTestingPurposes();
            Subzone someSubzone = Subzone.InstanceForTestingPurposes();
            testingZone.AddSubzone(someSubzone);
            testingZone.AddSubzone(someSubzone);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneAddNullSubzoneInvalidTest()
        {
            Zone testingZone = Zone.InstanceForTestingPurposes();
            testingZone.AddSubzone(null);
        }

        [TestMethod]
        public void ZoneRemoveSubzoneValidTest()
        {
            Zone testingZone = Zone.InstanceForTestingPurposes();
            Subzone someSubzone = Subzone.CreateNewSubzone("Subzone",
                3, testingZone);
            CollectionAssert.Contains(testingZone.Subzones.ToList(), someSubzone);
            testingZone.RemoveSubzone(someSubzone);
            CollectionAssert.DoesNotContain(testingZone.Subzones.ToList(), someSubzone);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneRemoveUnaddedSubzoneInvalidTest()
        {
            Zone testingZone = Zone.InstanceForTestingPurposes();
            testingZone.RemoveSubzone(Subzone.InstanceForTestingPurposes());
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZoneRemoveNullSubzoneInvalidTest()
        {
            Zone testingZone = Zone.InstanceForTestingPurposes();
            testingZone.RemoveSubzone(Subzone.InstanceForTestingPurposes());
        }
    }
}
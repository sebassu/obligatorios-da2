using Domain;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;

namespace Data.Tests.Persistence_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ZoneSubzoneRepositoryTests
    {

        private static ZoneSubzoneRepository testingZoneSubzoneRepository;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingZoneSubzoneRepository = new ZoneSubzoneRepository();
        }

        #region AddNewZone
        [TestMethod]
        public void ZRepositoryAddNewZoneValidTest()
        {
            Zone zoneToVerify = Zone.CreateNewZone("Test zone", 12);
            testingZoneSubzoneRepository.AddNewZone(zoneToVerify);
            CollectionAssert.Contains(testingZoneSubzoneRepository.ZoneElements.ToList(), zoneToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryAddRepeatedZoneInvalidTest()
        {
            Zone testingZone = Zone.CreateNewZone("Same name", 23);
            testingZoneSubzoneRepository.AddNewZone(testingZone);
            testingZoneSubzoneRepository.AddNewZone(testingZone);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryAddNewZoneRepeateNameInvalidTest()
        {
            Zone testingZone = Zone.CreateNewZone("Zone 1", 21);
            Zone secondTestingZone = Zone.CreateNewZone("Zone 1", 34);
            testingZoneSubzoneRepository.AddNewZone(testingZone);
            testingZoneSubzoneRepository.AddNewZone(secondTestingZone);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryAddNewZoneNullInvalidTest()
        {
            testingZoneSubzoneRepository.AddNewZone(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZRepositoryAddNewZoneInvalidNameTest()
        {
            Zone testingZone = Zone.CreateNewZone("!@#$%^", 11);
            testingZoneSubzoneRepository.AddNewZone(testingZone);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZRepositoryAddNewZoneInvalidCapacityTest()
        {
            Zone testingZone = Zone.CreateNewZone("Valid name", 0);
            testingZoneSubzoneRepository.AddNewZone(testingZone);
        }
        #endregion

        #region UpdateZone
        [TestMethod]
        public void ZRepositoryModifyZoneValidTest()
        {
            Zone zoneToVerify = Zone.CreateNewZone("Some zone", 11);
            testingZoneSubzoneRepository.AddNewZone(zoneToVerify);
            SetZoneData(zoneToVerify, "One zone", 33);
            testingZoneSubzoneRepository.UpdateZone(zoneToVerify);
            Assert.AreEqual("One zone", zoneToVerify.Name);
            Assert.AreEqual(33, zoneToVerify.Capacity);
        }

        private void SetZoneData(Zone zoneToVerify, string nameToSet, int capacityToSet)
        {
            zoneToVerify.Name = nameToSet;
            zoneToVerify.Capacity = capacityToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryModifyNullZoneInvalidTest()
        {
            testingZoneSubzoneRepository.UpdateZone(null);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryModifyNotAddedZoneInvalidTest()
        {
            Zone notAddedZone = Zone.CreateNewZone("New name", 2);
            testingZoneSubzoneRepository.UpdateZone(notAddedZone);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZRepositoryModifyZoneNameInvalidTest()
        {
            Zone zoneToModify = Zone.CreateNewZone("Zone 3", 5);
            testingZoneSubzoneRepository.AddNewZone(zoneToModify);
            zoneToModify.Name = "!@#$%";
            testingZoneSubzoneRepository.UpdateZone(zoneToModify);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZRepositoryModifyZoneCapacityInvalidTest()
        {
            Zone zoneToModify = Zone.CreateNewZone("Zone 0", 5);
            testingZoneSubzoneRepository.AddNewZone(zoneToModify);
            zoneToModify.Capacity = 0;
            testingZoneSubzoneRepository.UpdateZone(zoneToModify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryModifyZoneAlreadyExistingNameInvalidTest()
        {
            Zone zoneToModify = Zone.CreateNewZone("Zone 4", 5);
            testingZoneSubzoneRepository.AddNewZone(zoneToModify);
            zoneToModify.Name = "Zone 0";
            testingZoneSubzoneRepository.UpdateZone(zoneToModify);
        }
        #endregion

        #region AddNewSubzone
        [TestMethod]
        public void ZRepositoryAddNewSubzoneValidTest()
        {
            Zone zoneToAdd = Zone.CreateNewZone("Zone10", 12);
            testingZoneSubzoneRepository.AddNewZone(zoneToAdd);
            Subzone testingSubzone = Subzone.CreateNewSubzone("Some subzone", 11, zoneToAdd);
            testingZoneSubzoneRepository.AddNewSubzone(testingSubzone);
            CollectionAssert.Contains(testingZoneSubzoneRepository.SubzoneElements.ToList(), testingSubzone);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryAddSubzoneNotExistingZoneInvalidTest()
        {
            Zone testingZone = Zone.CreateNewZone("Zone11", 23);
            Subzone testingSubzone = Subzone.CreateNewSubzone("Subzone", 22, testingZone);
            testingZoneSubzoneRepository.AddNewSubzone(testingSubzone);

        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryAddSubzoneNullInvalidTest()
        {;
            testingZoneSubzoneRepository.AddNewSubzone(null);

        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void ZRepositoryAddSubzoneInvalidNameTest()
        {
            Zone testingZone = Zone.CreateNewZone("Zone11", 23);
            Subzone testingSubzone = Subzone.CreateNewSubzone("!@#$%^", 22, testingZone);
            testingZoneSubzoneRepository.AddNewSubzone(testingSubzone);

        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void ZRepositoryAddSubzoneInvalidCapacityTest()
        {
            Zone testingZone = Zone.CreateNewZone("Zone11", 23);
            Subzone testingSubzone = Subzone.CreateNewSubzone("Subzone", 0, testingZone);
            testingZoneSubzoneRepository.AddNewSubzone(testingSubzone);

        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void ZRepositoryAddSubzoneInvalidZoneTest()
        {
            Subzone testingSubzone = Subzone.CreateNewSubzone("Subzone", 2, null);
            testingZoneSubzoneRepository.AddNewSubzone(testingSubzone);

        }
        #endregion
    }
}

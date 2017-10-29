using Domain;
using System.Linq;
using Persistence;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SubzoneRepositoryTests
    {
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static ISubzoneRepository testingSubzoneRepository;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingSubzoneRepository = testingUnitOfWork.Subzones;
            Assert.IsNotNull(testingSubzoneRepository);
        }

        #region AddNewSubzone tests
        [TestMethod]
        public void SZRepositoryAddNewSubzoneValidTest()
        {
            Zone zoneToAdd = Zone.CreateNewZone("Zone10", 12);
            Subzone testingSubzone = Subzone.CreateNewSubzone("One subzone",
                11, zoneToAdd);
            AddNewSubzoneAndSaveChanges(testingSubzone);
            CollectionAssert.Contains(testingSubzoneRepository.Elements.ToList(),
                testingSubzone);
        }

        [TestMethod]
        public void SZRepositoryAddSubzoneNonExistingZoneValidTest()
        {
            Zone testingZone = Zone.CreateNewZone("Zonep", 23);
            Subzone testingSubzone = Subzone.CreateNewSubzone("Subzone", 22,
                testingZone);
            AddNewSubzoneAndSaveChanges(testingSubzone);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void SZRepositoryAddSubzoneNullInvalidTest()
        {
            AddNewSubzoneAndSaveChanges(null);
        }
        #endregion

        #region GetSubzoneWithId tests
        [TestMethod]
        public void SZRepositoryGetSubzoneWithIdValidTest()
        {
            var subzoneToVerify = Subzone.InstanceForTestingPurposes();
            AddNewSubzoneAndSaveChanges(subzoneToVerify);
            Subzone result = testingSubzoneRepository.GetSubzoneWithId(
                subzoneToVerify.Id);
            Assert.AreEqual(subzoneToVerify, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void SZRepositoryGetSubzoneWithUnaddedIdInvalidTest()
        {
            testingSubzoneRepository.GetSubzoneWithId(42);
        }
        #endregion

        #region UpdateSubzone tests
        [TestMethod]
        public void SZRepositoryModifySubzoneValidTest()
        {
            Zone testingZone = Zone.CreateNewZone("Testing zone", 11);
            Subzone subzoneToVerify = Subzone.CreateNewSubzone("A subzone", 2, testingZone);
            AddNewSubzoneAndSaveChanges(subzoneToVerify);
            SetSubzoneData(subzoneToVerify, "One subzone", 10, testingZone);
            Assert.AreEqual("One subzone", subzoneToVerify.Name);
            Assert.AreEqual(10, subzoneToVerify.Capacity);
            Assert.AreEqual(testingZone, subzoneToVerify.Container);
        }

        private void SetSubzoneData(Subzone subzoneToVerify,
            string nameToSet, int capacityToSet, Zone zoneToSet)
        {
            subzoneToVerify.Name = nameToSet;
            subzoneToVerify.Capacity = capacityToSet;
            subzoneToVerify.Container = zoneToSet;
            UpdateSubzoneAndSaveChanges(subzoneToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void SZRepositoryModifyNullSubzoneInvalidTest()
        {
            UpdateSubzoneAndSaveChanges(null);
        }
        #endregion

        #region RemoveSubzone tests
        [TestMethod]
        public void SZRepositoryRemoveSubzoneValidTest()
        {
            Zone testingZone = Zone.CreateNewZone("Some new zone1", 8);
            Subzone subzoneToVerify = Subzone.CreateNewSubzone("Delete subzone",
                6, testingZone);
            AddNewSubzoneAndSaveChanges(subzoneToVerify);
            RemoveSubzoneAndSaveChanges(subzoneToVerify);
            CollectionAssert.DoesNotContain(testingSubzoneRepository.Elements.ToList(),
                subzoneToVerify);
        }

        [TestMethod]
        public void ZRepositoryRemoveSubzoneWithVehiclesValidTest()
        {
            Zone testingZone = Zone.CreateNewZone("Zone21", 8);
            Subzone subzoneToVerify = Subzone.CreateNewSubzone("Delete subzone 2",
                6, testingZone);
            Vehicle vehicleToAdd = Vehicle.InstanceForTestingPurposes();
            subzoneToVerify.Vehicles.Add(vehicleToAdd);
            AddNewSubzoneAndSaveChanges(subzoneToVerify);
            RemoveSubzoneAndSaveChanges(subzoneToVerify);
        }
        #endregion

        private static void AddNewSubzoneAndSaveChanges(Subzone someSubzone)
        {
            testingSubzoneRepository.AddNewSubzone(someSubzone);
            testingUnitOfWork.SaveChanges();
        }

        private void UpdateSubzoneAndSaveChanges(Subzone subzoneToModify)
        {
            testingSubzoneRepository.UpdateSubzone(subzoneToModify);
            testingUnitOfWork.SaveChanges();
        }

        private void RemoveSubzoneAndSaveChanges(Subzone subzoneToRemove)
        {
            testingSubzoneRepository.RemoveSubzone(subzoneToRemove);
            testingUnitOfWork.SaveChanges();
        }
    }
}
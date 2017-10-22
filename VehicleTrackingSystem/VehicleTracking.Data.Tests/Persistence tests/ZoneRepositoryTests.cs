using Domain;
using System.Linq;
using Persistence;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests.Persistence_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ZoneRepositoryTests
    {
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static IZoneRepository testingZoneRepository;
        private const string unaddedName = "This is not a zone's name";

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingZoneRepository = testingUnitOfWork.Zones;
        }

        #region AddNewZone tests
        [TestMethod]
        public void ZRepositoryAddNewZoneValidTest()
        {
            Zone zoneToVerify = Zone.CreateNewZone("Test zone", 12);
            AddNewZoneAndSaveChanges(zoneToVerify);
            CollectionAssert.Contains(testingZoneRepository.Elements.ToList(),
                zoneToVerify);
        }

        [TestMethod]
        public void ZRepositoryAddRepeatedZoneValidTest()
        {
            Zone testingZone = Zone.CreateNewZone("Same name", 23);
            AddNewZoneAndSaveChanges(testingZone);
            AddNewZoneAndSaveChanges(testingZone);
        }

        [TestMethod]
        public void ZRepositoryAddNewZoneRepeateNameValidTest()
        {
            Zone testingZone = Zone.CreateNewZone("Zone 1", 21);
            Zone secondTestingZone = Zone.CreateNewZone("Zone 1", 34);
            AddNewZoneAndSaveChanges(testingZone);
            AddNewZoneAndSaveChanges(secondTestingZone);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryAddNewZoneNullInvalidTest()
        {
            AddNewZoneAndSaveChanges(null);
        }
        #endregion

        #region GetZoneWithName tests
        [TestMethod]
        public void ZRepositoryGetZoneWithNameValidTest()
        {
            var nameToLookup = "Very particular added name";
            var addedZone = Zone.CreateNewZone(nameToLookup, 42);
            AddNewZoneAndSaveChanges(addedZone);
            Zone result = testingZoneRepository.GetZoneWithName(nameToLookup);
            Assert.AreEqual(addedZone, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryGetZoneWithUnaddedNameInvalidTest()
        {
            testingZoneRepository.GetZoneWithName(unaddedName);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryGetZoneWithNullNameInvalidTest()
        {
            testingZoneRepository.GetZoneWithName(null);
        }
        #endregion

        #region ExistsZoneWithName tests
        [TestMethod]
        public void ZRepositoryExistsZoneWithNameValidTest()
        {
            var nameToLookup = "El habitual espacio";
            Zone zoneToVerify = Zone.CreateNewZone(nameToLookup, 6);
            AddNewZoneAndSaveChanges(zoneToVerify);
            bool result = testingZoneRepository.ExistsZoneWithName(nameToLookup);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ZRepositoryExistsZoneWithUnaddedNameValidTest()
        {
            bool result = testingZoneRepository.ExistsZoneWithName(unaddedName);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ZRepositoryNoZoneWithNullNameExists()
        {
            bool result = testingZoneRepository.ExistsZoneWithName(null);
            Assert.IsFalse(result);
        }
        #endregion

        #region UpdateZone tests
        [TestMethod]
        public void ZRepositoryModifyZoneValidTest()
        {
            Zone zoneToVerify = Zone.CreateNewZone("Some zone", 11);
            AddNewZoneAndSaveChanges(zoneToVerify);
            SetZoneData(zoneToVerify, "One zone", 33);
            Assert.AreEqual("One zone", zoneToVerify.Name);
            Assert.AreEqual(33, zoneToVerify.Capacity);
        }

        private void SetZoneData(Zone zoneToVerify,
            string nameToSet, int capacityToSet)
        {
            zoneToVerify.Name = nameToSet;
            zoneToVerify.Capacity = capacityToSet;
            UpdateZoneAndSaveChanges(zoneToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryModifyNullZoneInvalidTest()
        {
            UpdateZoneAndSaveChanges(null);
        }
        #endregion

        #region RemoveZone tests
        [TestMethod]
        public void ZRepositoryRemoveZoneValidTest()
        {
            Zone zoneToVerify = Zone.CreateNewZone("Delete zone", 6);
            AddNewZoneAndSaveChanges(zoneToVerify);
            RemoveZoneAndSaveChanges(zoneToVerify);
            CollectionAssert.DoesNotContain(testingZoneRepository.Elements.ToList(),
                zoneToVerify);
        }

        [TestMethod]
        public void ZRepositoryRemoveZoneWithEmptySubzonesValidTest()
        {
            Zone zoneToVerify = Zone.CreateNewZone("Some new zone", 8);
            Subzone subzoneToAdd = Subzone.InstanceForTestingPurposes();
            subzoneToAdd.Container = zoneToVerify;
            zoneToVerify.Subzones.Add(subzoneToAdd);
            AddNewZoneAndSaveChanges(zoneToVerify);
            RemoveZoneAndSaveChanges(zoneToVerify);
            CollectionAssert.DoesNotContain(testingZoneRepository.Elements.ToList(),
                zoneToVerify);
        }
        #endregion

        private static void AddNewZoneAndSaveChanges(Zone testingZone)
        {
            testingZoneRepository.AddNewZone(testingZone);
            testingUnitOfWork.SaveChanges();
        }

        private static void UpdateZoneAndSaveChanges(Zone zoneToModify)
        {
            testingZoneRepository.UpdateZone(zoneToModify);
            testingUnitOfWork.SaveChanges();
        }

        private static void RemoveZoneAndSaveChanges(Zone zoneToRemove)
        {
            testingZoneRepository.RemoveZone(zoneToRemove);
            testingUnitOfWork.SaveChanges();
        }
    }
}
using Domain;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;
using System;

namespace Data.Tests.Persistence_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ZoneRepositoryTests
    {
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static IZoneRepository testingZoneRepository;

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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ZRepositoryAddNewZoneNullInvalidTest()
        {
            AddNewZoneAndSaveChanges(null);
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
            RemoveZoneWithNameAndSaveChanges(zoneToVerify.Name);
            CollectionAssert.DoesNotContain(testingZoneRepository.Elements.ToList(),
                zoneToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryRemoveZoneNotInRepositoryInvalidTest()
        {
            Zone zoneToVerify = Zone.CreateNewZone("Some new zone", 8);
            RemoveZoneWithNameAndSaveChanges(zoneToVerify.Name);
        }

        [TestMethod]
        public void ZRepositoryRemoveZoneWithEmptySubzonesValidTest()
        {
            Zone zoneToVerify = Zone.CreateNewZone("Some new zone", 8);
            Subzone subzoneToAdd = Subzone.InstanceForTestingPurposes();
            subzoneToAdd.Container = zoneToVerify;
            zoneToVerify.Subzones.Add(subzoneToAdd);
            AddNewZoneAndSaveChanges(zoneToVerify);
            RemoveZoneWithNameAndSaveChanges(zoneToVerify.Name);
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

        private static void RemoveZoneWithNameAndSaveChanges(string nameToRemove)
        {
            testingZoneRepository.RemoveZoneWithName(nameToRemove);
            testingUnitOfWork.SaveChanges();
        }
    }
}
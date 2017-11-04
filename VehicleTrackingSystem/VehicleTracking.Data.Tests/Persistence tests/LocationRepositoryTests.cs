﻿using Domain;
using Persistence;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LocationRepositoryTests
    {
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static ILocationRepository testingLocationRepository;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingLocationRepository = testingUnitOfWork.Locations;
            Assert.IsNotNull(testingLocationRepository);
        }

        [TestMethod]
        public void LCRepositoryElementsAreDefaultLocationsValidTest()
        {
            var defaultLocations = VTSystemDatabaseInitializer
                .defaultSystemLocations.ToList();
            CollectionAssert.AreEqual(defaultLocations,
                testingLocationRepository.Elements.ToList());
        }

        #region GetLocationWithName tests
        [TestMethod]
        public void LCRepositoryGetLocationWithNameValidTest()
        {
            var expectedLocation = Location.CreateNewLocation(
                LocationType.PORT, "Puerto Ochenta Ochenta");
            Location result = testingLocationRepository.GetLocationWithName(
                "Puerto Ochenta Ochenta");
            Assert.AreEqual(expectedLocation, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void LCRepositoryGetLocationWithUnregisteredNameInvalidTest()
        {
            testingLocationRepository.GetLocationWithName("Nombre no registrado");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void LCRepositoryGetLocationWithRandomCharactersNameInvalidTest()
        {
            testingLocationRepository.GetLocationWithName("121^ *-* \t#&$");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void LCRepositoryGetLocationWithNullNameInvalidTest()
        {
            testingLocationRepository.GetLocationWithName(null);
        }
        #endregion

        #region Default ElementExistsInCollection tests
        [TestMethod]
        public void LRepositoryElementExistsInCollectionExistingElementTest()
        {
            var addedLocation = testingLocationRepository.Elements.First();
            var castRepostory = testingLocationRepository as GenericRepository<Location>;
            Assert.IsFalse(castRepostory.ElementExistsInCollection(addedLocation));
        }

        [TestMethod]
        public void LRepositoryElementExistsInCollectionUnaddedElementTest()
        {
            var unaddedLocation = Location.InstanceForTestingPurposes();
            var castRepostory = testingLocationRepository as GenericRepository<Location>;
            Assert.IsFalse(castRepostory.ElementExistsInCollection(unaddedLocation));
        }
        #endregion
    }
}
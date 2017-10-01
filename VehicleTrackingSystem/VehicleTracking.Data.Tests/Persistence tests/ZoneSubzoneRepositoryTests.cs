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
    }
}

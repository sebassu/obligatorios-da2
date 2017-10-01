using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Domain;

namespace Data.Tests.Persistence_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ZoneSubzoneRepository
    {
        [TestMethod]
        public void ZRepositoryAddNewZoneValidTest()
        {
            Zone zoneToVerify = Zone.CreateNewZone("Test zone", 12);
            ZoneRepository.AddNewZone("Test zone", 12);
            CollectionAssert.Contains(ZoneRepository.Elements.ToList(), zoneToVerify);
        }

        [TestMethod]
        public void ZRepositoryAddNewZoneReturnsAddedZoneValidTest()
        {
            Zone addedZone = ZoneRepository.AddNewZone("Another test zone", 3);
            CollectionAssert.Contains(ZoneRepository.Elements.ToList(), addedZone);
        }

        [TestMethod]
        public void ZRepositoryAddNewZoneOnlyNameMatchValidTest()
        {
            Zone zoneToVerify = Zone.InstanceForTestingPurposes();
            zoneToVerify.Name = "Some name";
            ZoneRepository.AddNewZone("Some name", 34);
            CollectionAssert.Contains(ZoneRepository.Elements.ToList(), zoneToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryAddRepeatedZoneInvalidTest()
        {
            ZoneRepository.AddNewZone("Same name", 23);
            ZoneRepository.AddNewZone("Same name", 23);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZRepositoryAddNewZoneRepeateNameInvalidTest()
        {
            ZoneRepository.AddNewZone("Zone 1", 21);
            ZoneRepository.AddNewZone("Zone 1", 34);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZRepositoryAddNewZoneInvalidNameTest()
        {
            ZoneRepository.AddNewZone("!@#$%^", 12);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZRepositoryAddNewZoneInvalidCapacityTest()
        {
            ZoneRepository.AddNewZone("Valid name", 0);
        }
    }
}

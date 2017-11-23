using Moq;
using System.Linq;
using API.Services;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.API.Services_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ZoneServicesTests
    {
        private static readonly ZoneServices testingZoneSubzoneServices = new ZoneServices();
        private static readonly Zone testingZone = Zone.CreateNewZone("Some zone", 21);
        private static readonly Subzone testingSubzone =
            Subzone.CreateNewSubzone("Subzone", 10, testingZone);
        private static readonly ZoneDTO testingZoneData = ZoneDTO.FromZone(testingZone);

        [TestMethod]
        public void ZServicesDefaultParameterlessConstructorTest()
        {
            Assert.IsNotNull(testingZoneSubzoneServices.Model);
            Assert.IsNotNull(testingZoneSubzoneServices.Zones);
        }

        #region AddNewZoneFromData tests
        [TestMethod]
        public void ZServicesAddNewZoneFromDataValidTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.AddNewZone(It.IsAny<Zone>()))
                .Verifiable();
            mockUnitOfWork.Setup(u => u.SaveChanges()).Verifiable();
            var zoneServices = new ZoneServices(mockUnitOfWork.Object);
            zoneServices.AddNewZoneFromData(testingZoneData);
            mockUnitOfWork.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void ZServicesAddNewZoneFromNullDataInvalidTest()
        {
            testingZoneSubzoneServices.AddNewZoneFromData(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZServicesAddNewZoneFromDataInvalidNameTest()
        {
            ZoneDTO testZoneData = ZoneDTO.FromData("*&@*12*-*//31", 365);
            RunAddNewZoneTestWithInvalidDataOnDTO(testZoneData);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZServicesAddNewZoneFromDataInvalidCapacityTest()
        {
            ZoneDTO testZoneData = ZoneDTO.FromData("Valid name", -99);
            RunAddNewZoneTestWithInvalidDataOnDTO(testZoneData);
        }

        private static void RunAddNewZoneTestWithInvalidDataOnDTO(ZoneDTO testZoneData)
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.ExistsZoneWithName(It.IsAny<string>()))
                .Returns(false);
            var zoneServices = new ZoneServices(mockUnitOfWork.Object);
            zoneServices.AddNewZoneFromData(testZoneData);
            mockUnitOfWork.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void ZServicesAddNewZoneWithRepeatedNameInvalidTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.ExistsZoneWithName(
                testingZoneData.Name)).Returns(true);
            var zoneServices = new ZoneServices(mockUnitOfWork.Object);
            zoneServices.AddNewZoneFromData(testingZoneData);
        }
        #endregion

        #region GetRegisteredZones tests
        [TestMethod]
        public void ZServicesGetRegisteredZonesWithDataTest()
        {
            var someZones = GetCollectionOfFakeZones();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.Elements).Returns(someZones).Verifiable();
            var zoneServices = new ZoneServices(mockUnitOfWork.Object);
            var result = zoneServices.GetRegisteredZones().ToList();
            mockUnitOfWork.Verify();
            CollectionAssert.AreEqual(GetCollectionOfFakeZoneDTOs(), result);
        }

        private IEnumerable<Zone> GetCollectionOfFakeZones()
        {
            return new List<Zone>
            {
                Zone.CreateNewZone("The Zone", 42),
                Zone.CreateNewZone("Phantom zone", 21)
            }.AsReadOnly();
        }

        private List<ZoneDTO> GetCollectionOfFakeZoneDTOs()
        {
            var result = new List<ZoneDTO>();
            foreach (var zone in GetCollectionOfFakeZones())
            {
                result.Add(ZoneDTO.FromZone(zone));
            }
            return result;
        }

        [TestMethod]
        public void ZServicesGetRegisteredZonesNoDataTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.Elements).Returns(new List<Zone>());
            var zoneServices = new ZoneServices(mockUnitOfWork.Object);
            CollectionAssert.AreEqual(new List<ZoneDTO>(),
                zoneServices.GetRegisteredZones().ToList());
        }
        #endregion

        #region GetZoneWithName tests
        [TestMethod]
        public void ZServicesGetZoneWithNameValidTest()
        {
            ZoneDTO expectedData = ZoneDTO.FromZone(testingZone);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.GetZoneWithName(testingZone.Name))
                .Returns(testingZone).Verifiable();
            var zoneServices = new ZoneServices(mockUnitOfWork.Object);
            var result = zoneServices.GetZoneWithName(testingZone.Name);
            mockUnitOfWork.Verify();
            Assert.AreEqual(expectedData, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZServicesGetZoneWithNameNotFoundInvalidTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.GetZoneWithName(It.IsAny<string>()))
                .Throws(new RepositoryException("Message."));
            var zoneServices = new ZoneServices(mockUnitOfWork.Object);
            zoneServices.GetZoneWithName(testingZone.Name);
        }
        #endregion

        #region ModifyZoneWithName tests
        [TestMethod]
        public void ZServicesModifyZoneWithNameValidTest()
        {
            Zone zoneToModify = Zone.CreateNewZone("The Zone", 42);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.GetZoneWithName(zoneToModify.Name))
                .Returns(zoneToModify).Verifiable();
            mockUnitOfWork.Setup(u => u.Zones.ExistsZoneWithName(testingZoneData.Name))
                .Returns(false).Verifiable();
            mockUnitOfWork.Setup(u => u.SaveChanges()).Verifiable();
            var zoneServices = new ZoneServices(mockUnitOfWork.Object);
            zoneServices.ModifyZoneWithName(zoneToModify.Name, testingZoneData);
            mockUnitOfWork.Verify();
            Assert.AreEqual(testingZone.Name, zoneToModify.Name);
            Assert.AreEqual(testingZone.Capacity, zoneToModify.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZServicesModifyZoneWithNameInvalidNameTest()
        {
            ZoneDTO someZoneData = ZoneDTO.FromData("127*!@#).ad!$%", 42);
            RunModifyZoneTestWithInvalidDataOnDTO(someZoneData);
        }

        [TestMethod]
        [ExpectedException(typeof(ZoneException))]
        public void ZServicesModifyZoneWithNameInvalidCapacityTest()
        {
            ZoneDTO someZoneData = ZoneDTO.FromData("The Zone", -2112);
            RunModifyZoneTestWithInvalidDataOnDTO(someZoneData);
        }

        private static void RunModifyZoneTestWithInvalidDataOnDTO(ZoneDTO someZoneData)
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.GetZoneWithName(testingZone.Name))
                .Returns(testingZone);
            var zoneServices = new ZoneServices(mockUnitOfWork.Object);
            zoneServices.ModifyZoneWithName(testingZone.Name, someZoneData);
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void ZServicesModifyZoneWithNameCausesRepeatedNameInvalidTest()
        {
            Zone zoneToModify = Zone.InstanceForTestingPurposes();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.GetZoneWithName(zoneToModify.Name))
                .Returns(zoneToModify);
            mockUnitOfWork.Setup(u => u.Zones.ExistsZoneWithName(testingZoneData.Name))
                .Returns(true);
            var zoneServices = new ZoneServices(mockUnitOfWork.Object);
            zoneServices.ModifyZoneWithName(zoneToModify.Name, testingZoneData);
        }
        #endregion

        #region RemoveZoneWithName tests
        [TestMethod]
        public void ZServicesRemoveEmptyZoneWithNameValidTest()
        {
            var zoneWithoutSubzones = Zone.InstanceForTestingPurposes();
            var nameToFind = zoneWithoutSubzones.Name;
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.GetZoneWithName(nameToFind))
                .Returns(zoneWithoutSubzones).Verifiable();
            mockUnitOfWork.Setup(u => u.Zones.RemoveZone(zoneWithoutSubzones))
                .Verifiable();
            mockUnitOfWork.Setup(u => u.SaveChanges()).Verifiable();
            var userServices = new ZoneServices(mockUnitOfWork.Object);
            userServices.RemoveZoneWithName(nameToFind);
            mockUnitOfWork.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void ZServicesRemoveNonSubzoneEmptyZoneWithNameInvalidTest()
        {
            var nameToFind = testingZone.Name;
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.GetZoneWithName(nameToFind))
                .Returns(testingZone);
            var userServices = new ZoneServices(mockUnitOfWork.Object);
            userServices.RemoveZoneWithName(nameToFind);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void ZServicesRemoveZoneWithUnregisteredNameInvalidTest()
        {
            var nameToFind = testingZone.Name;
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.GetZoneWithName(nameToFind))
                .Throws(new RepositoryException("Message."));
            var userServices = new ZoneServices(mockUnitOfWork.Object);
            userServices.RemoveZoneWithName(nameToFind);
        }
        #endregion

        [TestMethod]
        public void ZoneDTODefaultInternalConstructorTest()
        {
            var defaultZoneDTO = new ZoneDTO();
            Assert.IsNull(defaultZoneDTO.Name);
            Assert.AreEqual(0, defaultZoneDTO.Capacity);
            Assert.IsNull(defaultZoneDTO.SubzoneIds);
        }

        [TestMethod]
        public void ZoneDTOEqualsWithDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingZoneData, someRandomObject);
        }

        [TestMethod]
        public void ZoneDTOGetHashCodeTest()
        {
            object testingZoneDataAsObject = testingZoneData;
            Assert.AreEqual(testingZoneDataAsObject.GetHashCode(),
                testingZoneData.GetHashCode());
        }
    }
}
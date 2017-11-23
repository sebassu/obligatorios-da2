using Moq;
using System.Linq;
using API.Services;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.API.Tests.Services_Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SubzoneServicesTests
    {
        private static readonly SubzoneServices testingSubzoneServices = new SubzoneServices();
        private static readonly SubzoneDTO testingSubzoneData =
            SubzoneDTO.FromData("Some very unique name", 123);
        private static Zone testingZone;
        private static Subzone testingSubzone;

        [TestInitialize]
        public void TestSetup()
        {
            testingZone = Zone.CreateNewZone("Some zone", 2112);
            testingSubzone = Subzone.CreateNewSubzone("Random subzone name",
                123, testingZone);
        }

        [TestMethod]
        public void SZServicesDefaultParameterlessConstructorTest()
        {
            Assert.IsNotNull(testingSubzoneServices.Model);
            Assert.IsNotNull(testingSubzoneServices.Subzones);
        }

        #region AddNewSubzoneFromData tests
        [TestMethod]
        public void SZServicesAddNewSubzoneFromDataValidTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.GetZoneWithName(testingZone.Name))
                .Returns(testingZone).Verifiable();
            mockUnitOfWork.Setup(u => u.Subzones.AddNewSubzone(It.IsAny<Subzone>()))
                .Verifiable();
            mockUnitOfWork.Setup(u => u.SaveChanges()).Verifiable();
            var zoneServices = new SubzoneServices(mockUnitOfWork.Object);
            zoneServices.AddNewSubzoneFromData(testingZone.Name, testingSubzoneData);
            mockUnitOfWork.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void SZServicesAddNewSubzoneFromNullContainerNameInvalidTest()
        {
            testingSubzoneServices.AddNewSubzoneFromData(null, testingSubzoneData);
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void SZServicesAddNewSubzoneFromNullDataInvalidTest()
        {
            testingSubzoneServices.AddNewSubzoneFromData(testingZone.Name, null);
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SZServicesAddNewSubzoneFromDataInvalidNameTest()
        {
            SubzoneDTO testSubzoneData = SubzoneDTO.FromData("*&@*12*-*//31", 42);
            RunAddNewSubzoneTestWithInvalidDataOnDTO(testSubzoneData);
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SZServicesAddNewSubzoneFromDataInvalidCapacityTest()
        {
            SubzoneDTO testSubzoneData = SubzoneDTO.FromData("Valid name", -2112);
            RunAddNewSubzoneTestWithInvalidDataOnDTO(testSubzoneData);
        }

        private static void RunAddNewSubzoneTestWithInvalidDataOnDTO(SubzoneDTO testSubzoneData)
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.GetZoneWithName(testingZone.Name))
                .Returns(testingZone).Verifiable();
            var zoneServices = new SubzoneServices(mockUnitOfWork.Object);
            zoneServices.AddNewSubzoneFromData(testingZone.Name, testSubzoneData);
            mockUnitOfWork.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void SZServicesAddNewSubzoneFromDataZoneNameNotFoundInvalidTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zones.GetZoneWithName(testingZone.Name))
                .Throws(new RepositoryException("Message."));
            var zoneServices = new SubzoneServices(mockUnitOfWork.Object);
            zoneServices.AddNewSubzoneFromData(testingZone.Name, testingSubzoneData);
        }
        #endregion

        #region GetRegisteredSubzones tests
        [TestMethod]
        public void SZServicesGetRegisteredSubzonesWithDataTest()
        {
            var someSubzones = GetCollectionOfFakeSubzones();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Subzones.Elements).Returns(someSubzones).Verifiable();
            var zoneServices = new SubzoneServices(mockUnitOfWork.Object);
            var result = zoneServices.GetRegisteredSubzones().ToList();
            mockUnitOfWork.Verify();
            CollectionAssert.AreEqual(GetCollectionOfSubzoneDTOs(someSubzones), result);
        }

        private IEnumerable<Subzone> GetCollectionOfFakeSubzones()
        {
            return new List<Subzone>
            {
                Subzone.CreateNewSubzone("The Subzone", 42, testingZone),
                Subzone.CreateNewSubzone("Phantom zone", 21, testingZone)
            }.AsReadOnly();
        }

        private List<SubzoneDTO> GetCollectionOfSubzoneDTOs(IEnumerable<Subzone>
            subzones)
        {
            return subzones.Select(s => SubzoneDTO.FromSubzone(s)).ToList();
        }

        [TestMethod]
        public void SZServicesGetRegisteredSubzonesNoDataTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Subzones.Elements).Returns(new List<Subzone>());
            var zoneServices = new SubzoneServices(mockUnitOfWork.Object);
            CollectionAssert.AreEqual(new List<SubzoneDTO>(),
                zoneServices.GetRegisteredSubzones().ToList());
        }
        #endregion

        #region GetSubzoneWithId tests
        [TestMethod]
        public void SZServicesGetSubzoneWithIdValidTest()
        {
            SubzoneDTO expectedData = SubzoneDTO.FromSubzone(testingSubzone);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Subzones.GetSubzoneWithId(testingSubzone.Id))
                .Returns(testingSubzone).Verifiable();
            var zoneServices = new SubzoneServices(mockUnitOfWork.Object);
            var result = zoneServices.GetSubzoneWithId(testingSubzone.Id);
            mockUnitOfWork.Verify();
            Assert.AreEqual(expectedData, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void SZServicesGetSubzoneWithIdNotFoundInvalidTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Subzones.GetSubzoneWithId(It.IsAny<int>()))
                .Throws(new RepositoryException("Message."));
            var zoneServices = new SubzoneServices(mockUnitOfWork.Object);
            zoneServices.GetSubzoneWithId(testingSubzone.Id);
        }
        #endregion

        #region ModifySubzoneWithId tests
        [TestMethod]
        public void SZServicesModifySubzoneWithIdValidTest()
        {
            Subzone subzoneToModify = Subzone.CreateNewSubzone("The Subzone",
                42, testingZone);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Subzones.GetSubzoneWithId(subzoneToModify.Id))
                .Returns(subzoneToModify).Verifiable();
            mockUnitOfWork.Setup(u => u.SaveChanges()).Verifiable();
            var zoneServices = new SubzoneServices(mockUnitOfWork.Object);
            zoneServices.ModifySubzoneWithId(subzoneToModify.Id, testingSubzoneData);
            mockUnitOfWork.Verify();
            Assert.AreEqual(testingSubzoneData.Name, subzoneToModify.Name);
            Assert.AreEqual(testingSubzoneData.Capacity, subzoneToModify.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SZServicesModifySubzoneWithIdInvalidNameTest()
        {
            SubzoneDTO someSubzoneData = SubzoneDTO.FromData("127*!@#).ad!$%", 42);
            RunModifySubzoneTestWithInvalidDataOnDTO(someSubzoneData);
        }

        [TestMethod]
        [ExpectedException(typeof(SubzoneException))]
        public void SZServicesModifySubzoneWithIdInvalidCapacityTest()
        {
            SubzoneDTO someSubzoneData = SubzoneDTO.FromData("The Subzone", -2112);
            RunModifySubzoneTestWithInvalidDataOnDTO(someSubzoneData);
        }

        private static void RunModifySubzoneTestWithInvalidDataOnDTO(SubzoneDTO someSubzoneData)
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Subzones.GetSubzoneWithId(testingSubzone.Id))
                .Returns(testingSubzone);
            var zoneServices = new SubzoneServices(mockUnitOfWork.Object);
            zoneServices.ModifySubzoneWithId(testingSubzone.Id, someSubzoneData);
        }
        #endregion

        #region RemoveSubzoneWithId tests
        [TestMethod]
        public void SZServicesRemoveEmptySubzoneWithIdValidTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Subzones.GetSubzoneWithId(testingSubzone.Id))
                .Returns(testingSubzone).Verifiable();
            mockUnitOfWork.Setup(u => u.Movements.SubzoneParticipatesInSomeMovement(testingSubzone))
                .Returns(false).Verifiable();
            mockUnitOfWork.Setup(u => u.Subzones.RemoveSubzone(testingSubzone))
                .Verifiable();
            mockUnitOfWork.Setup(u => u.SaveChanges()).Verifiable();
            var userServices = new SubzoneServices(mockUnitOfWork.Object);
            userServices.RemoveSubzoneWithId(testingSubzone.Id);
            mockUnitOfWork.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void SZServicesRemoveMovementParticipatingSubzoneWithIdInvalidTest()
        {
            Subzone nonRemovableSubzone = Subzone.InstanceForTestingPurposes();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Subzones.GetSubzoneWithId(nonRemovableSubzone.Id))
                .Returns(nonRemovableSubzone);
            mockUnitOfWork.Setup(u => u.Movements.SubzoneParticipatesInSomeMovement(
                nonRemovableSubzone)).Returns(true);
            var userServices = new SubzoneServices(mockUnitOfWork.Object);
            userServices.RemoveSubzoneWithId(nonRemovableSubzone.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void SZServicesRemoveSubzoneWithUnregisteredIdInvalidTest()
        {
            var unregisteredId = 42;
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Subzones.GetSubzoneWithId(unregisteredId))
                .Throws(new RepositoryException("Message."));
            var userServices = new SubzoneServices(mockUnitOfWork.Object);
            userServices.RemoveSubzoneWithId(unregisteredId);
        }
        #endregion

        [TestMethod]
        public void SubzoneDTODefaultInternalConstructorTest()
        {
            var defaultSubzoneDTO = new SubzoneDTO();
            Assert.IsNull(defaultSubzoneDTO.Name);
            Assert.AreEqual(0, defaultSubzoneDTO.Capacity);
            Assert.IsNull(defaultSubzoneDTO.VehicleVINs);
            Assert.IsNull(defaultSubzoneDTO.ContainerName);
        }

        [TestMethod]
        public void SubzoneDTOEqualsWithDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingSubzoneData, someRandomObject);
        }

        [TestMethod]
        public void SubzoneDTOGetHashCodeTest()
        {
            object testingSubzoneDataAsObject = testingSubzoneData;
            Assert.AreEqual(testingSubzoneDataAsObject.GetHashCode(),
                testingSubzoneData.GetHashCode());
        }
    }
}
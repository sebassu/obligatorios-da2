using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Services.Business_Logic;
using Domain;
using API.Services;
using Persistence;
using Moq;

namespace Web.API.Tests.Services_Tests
{
    [TestClass]
    public class ZoneSubzoneServicesTests
    {
        public class VehicleServicesTests
        {
            private static readonly ZoneSubzoneServices testingZoneSubzoneServices = new ZoneSubzoneServices();
            private static readonly Zone testingZone = Zone.CreateNewZone("The zone", 21);
            private static readonly Subzone testingSubzone = Subzone.CreateNewSubzone("Subzone", 10, testingZone);
            private static readonly ZoneDTO testingZoneData = ZoneDTO.FromZone(testingZone);
            private static readonly SubzoneDTO testingSubzoneData = SubzoneDTO.FromSubzone(testingSubzone);

            [TestMethod]
            public void VServicesDefaultParameterlessConstructorTest()
            {
                Assert.IsNotNull(testingZoneSubzoneServices.Model);
                Assert.IsNotNull(testingZoneSubzoneServices.Zones);
                Assert.IsNotNull(testingZoneSubzoneServices.Subzones);
            }

            #region AddNewZoneFromData tests
            [TestMethod]
            public void SZServicesAddNewZoneFromDataValidTest()
            {
                var mockUnitOfWork = new Mock<IUnitOfWork>();
                mockUnitOfWork.Setup(u => u.Zones.AddNewZone(It.IsAny<Zone>()))
                    .Verifiable();
                var userServices = new ZoneSubzoneServices(mockUnitOfWork.Object);
                userServices.AddNewZoneFromData(testingZoneData);
                mockUnitOfWork.Verify();
            }

            [TestMethod]
            [ExpectedException(typeof(ServiceException))]
            public void SZServicesAddNewZoneFromNullDataInvalidTest()
            {
                testingZoneSubzoneServices.AddNewZoneFromData(null);
            }

            [TestMethod]
            [ExpectedException(typeof(ZoneException))]
            public void SZServicesAddNewZoneFromDataInvalidFirstNameTest()
            {
                ZoneDTO testZoneData = ZoneDTO.FromData("*&@*12*-*//31", 365);
                RunAddNewZoneTestWithInvalidDataOnDTO(testZoneData);
            }

            [TestMethod]
            [ExpectedException(typeof(ZoneException))]
            public void SZServicesAddNewZoneFromDataInvalidLastNameTest()
            {
                ZoneDTO testZoneData = ZoneDTO.FromData("Valid name", -99);
                RunAddNewZoneTestWithInvalidDataOnDTO(testZoneData);
            }

            private static void RunAddNewZoneTestWithInvalidDataOnDTO(ZoneDTO testZoneData)
            {
                var mockUnitOfWork = new Mock<IUnitOfWork>();
                mockUnitOfWork.Setup(u => u.Zones.ExistsZoneWithName(It.IsAny<string>()))
                    .Returns(false);
                var userServices = new ZoneSubzoneServices(mockUnitOfWork.Object);
                userServices.AddNewZoneFromData(testZoneData);
                mockUnitOfWork.VerifyAll();
            }

            [TestMethod]
            [ExpectedException(typeof(RepositoryException))]
            public void SZServicesAddNewZoneWithRepeatedNameInvalidTest()
            {
                var mockUnitOfWork = new Mock<IUnitOfWork>();
                mockUnitOfWork.Setup(u => u.Zones.ExistsZoneWithName(
                    testingZoneData.Name)).Returns(true);
                var userServices = new ZoneSubzoneServices(mockUnitOfWork.Object);
                userServices.AddNewZoneFromData(testingZoneData);
            }
            #endregion

        }
    }
}
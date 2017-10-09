using Moq;
using Domain;
using Persistence;
using API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Web.API.Services_Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ZoneServicesTests
    {
        public class VehicleServicesTests
        {
            private static readonly ZoneServices testingZoneSubzoneServices = new ZoneServices();
            private static readonly Zone testingZone = Zone.CreateNewZone("The zone", 21);
            private static readonly Subzone testingSubzone = Subzone.CreateNewSubzone("Subzone", 10, testingZone);
            private static readonly ZoneDTO testingZoneData = ZoneDTO.FromZone(testingZone);
            private static readonly SubzoneDTO testingSubzoneData = SubzoneDTO.FromSubzone(testingSubzone);

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
                var userServices = new ZoneServices(mockUnitOfWork.Object);
                userServices.AddNewZoneFromData(testingZoneData);
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
            public void ZServicesAddNewZoneFromDataInvalidFirstNameTest()
            {
                ZoneDTO testZoneData = ZoneDTO.FromData("*&@*12*-*//31", 365);
                RunAddNewZoneTestWithInvalidDataOnDTO(testZoneData);
            }

            [TestMethod]
            [ExpectedException(typeof(ZoneException))]
            public void ZServicesAddNewZoneFromDataInvalidLastNameTest()
            {
                ZoneDTO testZoneData = ZoneDTO.FromData("Valid name", -99);
                RunAddNewZoneTestWithInvalidDataOnDTO(testZoneData);
            }

            private static void RunAddNewZoneTestWithInvalidDataOnDTO(ZoneDTO testZoneData)
            {
                var mockUnitOfWork = new Mock<IUnitOfWork>();
                mockUnitOfWork.Setup(u => u.Zones.ExistsZoneWithName(It.IsAny<string>()))
                    .Returns(false);
                var userServices = new ZoneServices(mockUnitOfWork.Object);
                userServices.AddNewZoneFromData(testZoneData);
                mockUnitOfWork.VerifyAll();
            }

            [TestMethod]
            [ExpectedException(typeof(RepositoryException))]
            public void ZServicesAddNewZoneWithRepeatedNameInvalidTest()
            {
                var mockUnitOfWork = new Mock<IUnitOfWork>();
                mockUnitOfWork.Setup(u => u.Zones.ExistsZoneWithName(
                    testingZoneData.Name)).Returns(true);
                var userServices = new ZoneServices(mockUnitOfWork.Object);
                userServices.AddNewZoneFromData(testingZoneData);
            }
            #endregion
        }
    }
}
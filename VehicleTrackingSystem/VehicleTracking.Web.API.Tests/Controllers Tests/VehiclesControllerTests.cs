using Moq;
using Domain;
using API.Services;
using System.Web.Http;
using Web.API.Controllers;
using System.Web.Http.Results;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System;
using Web.API.Tests;

namespace Web.API.Controllers_Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class VehiclesControllerTests
    {
        private static VehicleDTO fakeVehicleData = VehicleDTO.FromData(VehicleType.CAR,
            "Ferrari", "Barchetta", 1985, "Red", "RUSH2112MVNGPICRS");

        #region AddNewVehicleFromData tests
        [TestMethod]
        public void VControllerAddNewVehicleFromDataValidTest()
        {
            int idToVerify = 42;
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.AddNewVehicleFromData(fakeVehicleData)).Returns(idToVerify); ;
            var controller = new VehiclesController(mockVehicleServices.Object);
            IHttpActionResult obtainedResult = controller.AddNewVehicleFromData(fakeVehicleData);
            var result = obtainedResult as CreatedAtRouteNegotiatedContentResult<VehicleDTO>;
            mockVehicleServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual("VTSystemAPI", result.RouteName);
            Assert.AreEqual(idToVerify, result.RouteValues["id"]);
            Assert.AreEqual(fakeVehicleData, result.Content);
        }

        [TestMethod]
        public void VControllerAddNewVehicleFromNullDataInvalidTest()
        {
            var expectedErrorMessage = "Some error message";
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.AddNewVehicleFromData(null)).Throws(
                new VehicleTrackingException(expectedErrorMessage));
            var controller = new VehiclesController(mockVehicleServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsBadRequestResponse(delegate
            { return controller.AddNewVehicleFromData(null); },
                mockVehicleServices, expectedErrorMessage);
        }

        [TestMethod]
        public void VControllerAddNewVehicleFromDataUnexpectedErrorInvalidTest()
        {
            SystemException expectedException = new SystemException();
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(u => u.AddNewVehicleFromData(fakeVehicleData)).Throws(expectedException);
            var controller = new VehiclesController(mockVehicleServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsServerErrorResponse(delegate
            { return controller.AddNewVehicleFromData(fakeVehicleData); }, mockVehicleServices,
            expectedException);
        }
        #endregion

        #region GetRegisteredVehicles tests
        [TestMethod]
        public void VControllerGetRegisteredVehiclesWithDataValidTest()
        {
            var expectedVehicles = GetCollectionOfFakeVehicles();
            VerifyMethodReturnsExpectedVehicles(expectedVehicles);
        }

        private IEnumerable<VehicleDTO> GetCollectionOfFakeVehicles()
        {
            return new List<VehicleDTO>
            {
                VehicleDTO.FromData(VehicleType.SUV, "Chevrolet", "Onix",
                    2016, "Green", "QWERTYUIO12345678"),
                VehicleDTO.FromData(VehicleType.MINI_VAN, "Renault",
                    "Megane", 1996, "DarkGray", "AJSNDQ122345MANSD"),
            }.AsReadOnly();
        }

        [TestMethod]
        public void VControllerGetRegisteredVehiclesNoDataValidTest()
        {
            var expectedVehicles = new List<VehicleDTO>().AsReadOnly();
            VerifyMethodReturnsExpectedVehicles(expectedVehicles);
        }

        private static void VerifyMethodReturnsExpectedVehicles(
            IEnumerable<VehicleDTO> expectedVehicles)
        {
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.GetRegisteredVehicles()).Returns(expectedVehicles);
            var controller = new VehiclesController(mockVehicleServices.Object);
            IHttpActionResult obtainedResult = controller.GetRegisteredVehicles();
            var contentResult = obtainedResult as
                OkNegotiatedContentResult<IEnumerable<VehicleDTO>>;
            mockVehicleServices.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            CollectionAssert.AreEqual(expectedVehicles.ToList(),
                contentResult.Content.ToList());
        }

        [TestMethod]
        public void VControllerGetRegisteredVehiclesNullResponseInvalidTest()
        {
            IEnumerable<VehicleDTO> unexpectedVehicles = null;
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.GetRegisteredVehicles()).Returns(unexpectedVehicles);
            var controller = new VehiclesController(mockVehicleServices.Object);
            IHttpActionResult obtainedResult = controller.GetRegisteredVehicles();
            mockVehicleServices.VerifyAll();
            Assert.IsNotNull(obtainedResult);
            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void VControllerGetRegisteredVehiclesUnexpectedErrorInvalidTest()
        {
            SystemException expectedException = new SystemException();
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.GetRegisteredVehicles()).Throws(expectedException);
            var controller = new VehiclesController(mockVehicleServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsServerErrorResponse(delegate { return controller.GetRegisteredVehicles(); },
                mockVehicleServices, expectedException);
        }
        #endregion

        #region GetVehicleWithVIN tests
        [TestMethod]
        public void VContollerGetVehicleWithVINValidTest()
        {
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.GetVehicleWithVIN("REGISTEREDVIN1245")).Returns(fakeVehicleData);
            var controller = new VehiclesController(mockVehicleServices.Object);
            IHttpActionResult obtainedResult = controller.GetVehicleWithVIN("REGISTEREDVIN1245");
            var result = obtainedResult as OkNegotiatedContentResult<VehicleDTO>;
            mockVehicleServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(fakeVehicleData, result.Content);
        }

        [TestMethod]
        public void VControllerGetVehicleWithUnregisteredVINInvalidTest()
        {
            string expectedErrorMessage = "Some fourth exception message";
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.GetVehicleWithVIN(It.IsAny<string>())).Throws(
                new VehicleTrackingException(expectedErrorMessage));
            var controller = new VehiclesController(mockVehicleServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsBadRequestResponse(delegate
            { return controller.GetVehicleWithVIN("SOMEUNRGSTEREDVIN"); },
                mockVehicleServices, expectedErrorMessage);
        }

        [TestMethod]
        public void VControllerGetVehicleWithVINUnexpectedErrorInvalidTest()
        {
            SystemException expectedException = new SystemException();
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.GetVehicleWithVIN(It.IsAny<string>()))
                .Throws(expectedException);
            var controller = new VehiclesController(mockVehicleServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsServerErrorResponse(delegate
            { return controller.GetVehicleWithVIN("SOMEREGISTEREDVIN"); },
            mockVehicleServices, expectedException);
        }
        #endregion

        #region ModifyVehicleWithVIN tests
        [TestMethod]
        public void VControllerModifyVehicleWithVINValidTest()
        {
            var fakeVehicleDataToSet = VehicleDTO.FromData(VehicleType.MINI_VAN, "Renault", "Megane",
                1996, "DarkGray", "AJSNDQ122345MANSD");
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.ModifyVehicleWithVIN(fakeVehicleData.VIN, It.IsAny<VehicleDTO>()));
            var controller = new VehiclesController(mockVehicleServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsOkResponse(delegate
            { return controller.ModifyVehicleWithVIN("RUSH2112MVNGPICRS", fakeVehicleDataToSet); },
                mockVehicleServices);
        }

        [TestMethod]
        public void VControllerModifyVehicleWithVINNullDataInvalidTest()
        {
            var expectedErrorMessage = "A third error message.";
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.ModifyVehicleWithVIN(fakeVehicleData.VIN, null)).Throws(
                new VehicleTrackingException(expectedErrorMessage));
            var controller = new VehiclesController(mockVehicleServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsBadRequestResponse(
                delegate { return controller.ModifyVehicleWithVIN("RUSH2112MVNGPICRS", null); }, mockVehicleServices,
                expectedErrorMessage);
        }

        [TestMethod]
        public void VControllerModifyVehicleWithUnregisteredVINInvalidTest()
        {
            var expectedErrorMessage = "Fourth error message.";
            var fakeVehicleDataToSet = VehicleDTO.FromData(VehicleType.TRUCK, "Mercedes Benz",
                "MV 123", 1980, "Black", "POIMAS123IKS91345");
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.ModifyVehicleWithVIN(It.IsAny<string>(),
                It.IsAny<VehicleDTO>())).Throws(new VehicleTrackingException(expectedErrorMessage));
            var controller = new VehiclesController(mockVehicleServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsBadRequestResponse(delegate
            { return controller.ModifyVehicleWithVIN("POIMAS123IKS91345", fakeVehicleDataToSet); },
                mockVehicleServices, expectedErrorMessage);
        }

        [TestMethod]
        public void VControllerModifyVehicleWithVINUnexpectedErrorInvalidTest()
        {
            SystemException expectedException = new SystemException();
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.ModifyVehicleWithVIN(It.IsAny<string>(),
                It.IsAny<VehicleDTO>())).Throws(expectedException);
            var controller = new VehiclesController(mockVehicleServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsServerErrorResponse(delegate
            { return controller.ModifyVehicleWithVIN("SOMEREGISTEREDVIN", new VehicleDTO()); },
            mockVehicleServices, expectedException);
        }
        #endregion

        #region RemoveVehicleWithVIN tests
        [TestMethod]
        public void VControllerRemoveVehicleWithVINValidTest()
        {
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.RemoveVehicleWithVIN(It.IsAny<string>()));
            var controller = new VehiclesController(mockVehicleServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsOkResponse(delegate
            { return controller.RemoveVehicleWithVIN("SOMEREGISTEREDVIN"); },
                mockVehicleServices);
        }

        [TestMethod]
        public void VControllerRemoveVehicleWithUnregisteredVINInvalidTest()
        {
            var expectedErrorMessage = "Some other error message";
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.RemoveVehicleWithVIN(It.IsAny<string>())).Throws(
                new VehicleTrackingException(expectedErrorMessage));
            var controller = new VehiclesController(mockVehicleServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsBadRequestResponse(delegate
            { return controller.RemoveVehicleWithVIN("SOMEUNRGSTEREDVIN"); },
                mockVehicleServices, expectedErrorMessage);
        }

        [TestMethod]
        public void VControllerRemoveVehicleWithVINUnexpectedErrorInvalidTest()
        {
            SystemException expectedException = new SystemException();
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.RemoveVehicleWithVIN(It.IsAny<string>()))
                .Throws(expectedException);
            var controller = new VehiclesController(mockVehicleServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsServerErrorResponse(delegate
            { return controller.RemoveVehicleWithVIN("SOMEREGISTEREDVIN"); }, mockVehicleServices,
            expectedException);
        }
        #endregion
    }
}
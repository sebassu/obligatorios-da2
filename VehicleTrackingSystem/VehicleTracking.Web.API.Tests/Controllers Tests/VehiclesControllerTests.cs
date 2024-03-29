﻿using Moq;
using System;
using API.Services;
using Web.API.Tests;
using System.Web.Http;
using Web.API.Controllers;
using System.Web.Http.Results;
using VehicleTracking_Data_Entities;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.API.Controllers_tests
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
            mockVehicleServices.Setup(v => v.AddNewVehicleFromData(fakeVehicleData)).Returns(idToVerify);
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

        #region GetVehicleWithVIN tests
        [TestMethod]
        public void VContollerGetVehicleWithVINValidTest()
        {
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.GetVehicleWithVIN("REGISTEREDVIN1245"))
                .Returns(fakeVehicleData);
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

        #region RemoveVehicleWithVIN test
        [TestMethod]
        public void VControllerRemoveVehicleReturnsBadRequestInvalidTest()
        {
            var expectedMessage = "Actualmente no se permite eliminar vehículos" +
                " del sistema.";
            var mockVehicleServices = new Mock<IVehicleServices>();
            var controller = new VehiclesController(mockVehicleServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsBadRequestResponse(delegate
            { return controller.RemoveVehicleWithVIN("SOMEREGISTEREDVIN"); }, mockVehicleServices,
            expectedMessage);
        }
        #endregion
    }
}
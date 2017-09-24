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

namespace Web.API.Controllers_Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class VehiclesControllerTests
    {
        private static VehicleDTO fakeVehicle = VehicleDTO.FromVehicle(Vehicle.CreateNewVehicle(
            VehicleType.CAR, "Ferrari", "Barchetta", 1985, "Red", "RUSH2112MVNGPICRS"));

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
                VehicleDTO.FromVehicle(
                    Vehicle.CreateNewVehicle(VehicleType.SUV, "Chevrolet", "Onix",
                    2016, "Green", "QWERTYUIO12345678")),
                VehicleDTO.FromVehicle(
                    Vehicle.CreateNewVehicle(VehicleType.MINI_VAN, "Renault", "Megane",
                    1996, "DarkGray", "AJSNDQ122345MANSD")),
            }.AsReadOnly();
        }

        [TestMethod]
        public void VControllerGetRegisteredVehiclesNoDataValidTest()
        {
            var expectedVehicles = new List<VehicleDTO>().AsReadOnly();
            VerifyMethodReturnsExpectedVehicles(expectedVehicles);
        }

        private static void VerifyMethodReturnsExpectedVehicles(IEnumerable<VehicleDTO> expectedVehicles)
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
        #endregion

        #region AddNewVehicleFromData tests
        [TestMethod]
        public void VControllerAddNewVehicleFromDataValidTest()
        {
            int idToVerify = 42;
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.AddNewVehicleFromData(fakeVehicle)).Returns(idToVerify); ;
            var controller = new VehiclesController(mockVehicleServices.Object);
            IHttpActionResult obtainedResult = controller.AddNewVehicleFromData(fakeVehicle);
            var result = obtainedResult as CreatedAtRouteNegotiatedContentResult<VehicleDTO>;
            mockVehicleServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual("DefaultApi", result.RouteName);
            Assert.AreEqual(idToVerify, result.RouteValues["id"]);
            Assert.AreEqual(fakeVehicle, result.Content);
        }

        [TestMethod]
        public void VControllerAddNewVehicleFromNullDataInvalidTest()
        {
            var expectedErrorMessage = "Some error message";
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.AddNewVehicleFromData(null)).Throws(
                new VTSystemException(expectedErrorMessage));
            var controller = new VehiclesController(mockVehicleServices.Object);
            VerifyMethodReturnsBadRequestResponse(delegate { return controller.AddNewVehicleFromData(null); },
                mockVehicleServices, expectedErrorMessage);
        }
        #endregion

        #region RemoveVehicleWithVIN tests
        [TestMethod]
        public void VControllerRemoveVehicleWithVINValidTest()
        {
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.RemoveVehicleWithVIN(It.IsAny<string>()));
            var controller = new VehiclesController(mockVehicleServices.Object);
            VerifyMethodReturnsOkResponse(delegate { return controller.RemoveVehicleWithVIN("SOMEUNRGSTEREDVIN"); },
                mockVehicleServices);
        }

        [TestMethod]
        public void VControllerRemoveVehicleWithUnregisteredVINInvalidTest()
        {
            var expectedErrorMessage = "Some other error message";
            var mockVehicleServices = new Mock<IVehicleServices>();
            mockVehicleServices.Setup(v => v.RemoveVehicleWithVIN(It.IsAny<string>())).Throws(
                new VTSystemException(expectedErrorMessage));
            var controller = new VehiclesController(mockVehicleServices.Object);
            VerifyMethodReturnsBadRequestResponse(delegate { return controller.RemoveVehicleWithVIN("SOMEUNRGSTEREDVIN"); },
                mockVehicleServices, expectedErrorMessage);
        }
        #endregion

        private static void VerifyMethodReturnsOkResponse(Func<IHttpActionResult> methodToTest,
            Mock<IVehicleServices> mockVehicleServices)
        {
            IHttpActionResult result = methodToTest.Invoke();
            mockVehicleServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        private static void VerifyMethodReturnsBadRequestResponse(Func<IHttpActionResult> methodToTest,
            Mock<IVehicleServices> mockVehicleServices, string expectedErrorMessage)
        {
            IHttpActionResult obtainedResult = methodToTest.Invoke();
            var result = obtainedResult as BadRequestErrorMessageResult;
            mockVehicleServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedErrorMessage, result.Message);
        }
    }
}
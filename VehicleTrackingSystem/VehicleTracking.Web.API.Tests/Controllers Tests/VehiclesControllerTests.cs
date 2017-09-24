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
    }
}
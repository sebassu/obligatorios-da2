using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Services;
using Domain;
using System.Collections.Generic;
using Persistence;
using System.Linq;
using Moq;

namespace Web.API.Tests.Services_Tests
{
    [TestClass]
    public class VehicleServicesTests
    {
        private static VehicleServices testingVehicleServices = new VehicleServices();
        private static Vehicle testingVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR,
            "Ferrari", "Barchetta", 1985, "Red", "RUSH2112MVNGPICRS");
        private static VehicleDTO testingVehicleData = VehicleDTO.FromVehicle(testingVehicle);

        #region GetRegisteredVehicles tests
        [TestMethod]
        public void VServicesGetRegisteredVehiclesWithDataTest()
        {
            var someVehicles = GetCollectionOfFakeVehicles();
            var mockVehicleRepository = new Mock<IVehicleRepository>();
            mockVehicleRepository.Setup(v => v.Elements).Returns(someVehicles);
            var vehicleServices = new VehicleServices(mockVehicleRepository.Object);
            var result = vehicleServices.GetRegisteredVehicles().ToList();
            mockVehicleRepository.VerifyAll();
            CollectionAssert.AreEqual(GetCollectionOfFakeVehicleDTOs(), result);
        }

        private IEnumerable<Vehicle> GetCollectionOfFakeVehicles()
        {
            return new List<Vehicle>
            {
                Vehicle.CreateNewVehicle(VehicleType.SUV, "Chevrolet", "Onix",
                    2016, "Green", "QWERTYUIO12345678"),
                Vehicle.CreateNewVehicle(VehicleType.MINI_VAN, "Renault",
                    "Megane", 1996, "DarkGray", "AJSNDQ122345MANSD")
            }.AsReadOnly();
        }

        private List<VehicleDTO> GetCollectionOfFakeVehicleDTOs()
        {
            var result = new List<VehicleDTO>();
            foreach (var vehicle in GetCollectionOfFakeVehicles())
            {
                result.Add(VehicleDTO.FromVehicle(vehicle));
            }
            return result;
        }

        [TestMethod]
        public void VServicesGetRegisteredVehiclesNoDataTest()
        {
            var mockVehicleRepository = new Mock<IVehicleRepository>();
            mockVehicleRepository.Setup(v => v.Elements).Returns(new List<Vehicle>());
            var vehicleServices = new VehicleServices(mockVehicleRepository.Object);
            CollectionAssert.AreEqual(new List<VehicleDTO>(),
                vehicleServices.GetRegisteredVehicles().ToList());
        }
        #endregion

        #region GetVehicleWithVIN tests
        [TestMethod]
        public void VServicesGetVehicleWithVINValidTest()
        {
            VehicleDTO expectedData = VehicleDTO.FromVehicle(testingVehicle);
            var mockVehicleRepository = new Mock<IVehicleRepository>();
            mockVehicleRepository.Setup(v => v.GetVehicleByVIN(testingVehicle.VIN)).Returns(testingVehicle);
            var vehicleServices = new VehicleServices(mockVehicleRepository.Object);
            var result = vehicleServices.GetVehicleWithVIN(testingVehicle.VIN);
            mockVehicleRepository.VerifyAll();
            Assert.AreEqual(expectedData, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VServicesGetVehicleWithVINNotFoundInvalidTest()
        {
            var mockVehicleRepository = new Mock<IVehicleRepository>();
            mockVehicleRepository.Setup(v => v.GetVehicleByVIN(It.IsAny<string>()))
                .Throws(new RepositoryException(""));
            var vehicleServices = new VehicleServices(mockVehicleRepository.Object);
            vehicleServices.GetVehicleWithVIN(testingVehicle.VIN);
        }
        #endregion
    }
}

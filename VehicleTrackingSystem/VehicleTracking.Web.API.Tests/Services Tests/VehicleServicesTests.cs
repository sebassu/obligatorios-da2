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
            mockVehicleRepository.Setup(u => u.Elements).Returns(someVehicles);
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
        public void UServicesGetRegisteredUsersNoDataTest()
        {
            var mockVehicleRepository = new Mock<IVehicleRepository>();
            mockVehicleRepository.Setup(u => u.Elements).Returns(new List<Vehicle>());
            var vehicleServices = new VehicleServices(mockVehicleRepository.Object);
            CollectionAssert.AreEqual(new List<VehicleDTO>(),
                vehicleServices.GetRegisteredVehicles().ToList());
        }
        #endregion
    }
}

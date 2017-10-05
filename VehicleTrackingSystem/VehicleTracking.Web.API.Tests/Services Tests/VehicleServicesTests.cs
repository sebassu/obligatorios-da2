﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Services;
using Domain;
using System.Collections.Generic;
using Persistence;
using System.Linq;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace Web.API.Tests.Services_Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class VehicleServicesTests
    {
        private static VehicleServices testingVehicleServices = new VehicleServices();
        private static Vehicle testingVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR,
            "Ferrari", "Barchetta", 1985, "Red", "RUSH2112MVNGPICRS");
        private static VehicleDTO testingVehicleData = VehicleDTO.FromVehicle(testingVehicle);

        #region AddNewVehicleFromData tests
        [TestMethod]
        public void VServicesAddNewVehicleFromDataValidTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(v => v.Vehicles.AddNewVehicle(It.IsAny<Vehicle>()))
                .Verifiable();
            var vehicleServices = new VehicleServices(mockUnitOfWork.Object);
            vehicleServices.AddNewVehicleFromData(testingVehicleData);
            mockUnitOfWork.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void VServicesAddNewVehicleFromDataAlreadyRegisteredVINInvalidTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Vehicles.ExistsVehicleWithVIN(
                testingVehicleData.VIN)).Returns(true);
            var vehicleServices = new VehicleServices(mockUnitOfWork.Object);
            vehicleServices.AddNewVehicleFromData(testingVehicleData);
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void VServicesAddNewVehicleFromNullDataInvalidTest()
        {
            testingVehicleServices.AddNewVehicleFromData(null);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VServicesAddNewVehicleFromDataInvalidBrandTest()
        {
            VehicleDTO testVehicleData = VehicleDTO.FromData(VehicleType.CAR,
                "12 #% --*.@%", "Barchetta", 1985, "Red", "RUSH2112MVNGPICRS");
            RunAddNewVehicleTestWithInvalidDataOnDTO(testVehicleData);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VServicesAddNewVehicleFromDataInvalidModelTest()
        {
            VehicleDTO testVehicleData = VehicleDTO.FromData(VehicleType.CAR, "Ferrari",
                "!! 12.@%#%. -", 1985, "Red", "RUSH2112MVNGPICRS");
            RunAddNewVehicleTestWithInvalidDataOnDTO(testVehicleData);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VServicesAddNewVehicleFromDataInvalidYearTest()
        {
            VehicleDTO testVehicleData = VehicleDTO.FromData(VehicleType.CAR,
                "Ferrari", "Barchetta", 2112, "Red", "RUSH2112MVNGPICRS");
            RunAddNewVehicleTestWithInvalidDataOnDTO(testVehicleData);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VServicesAddNewVehicleFromDataInvalidColorTest()
        {
            VehicleDTO testVehicleData = VehicleDTO.FromData(VehicleType.CAR,
                "Ferrari", "Barchetta", 1985, "13# ;%!)($%", "RUSH2112MVNGPICRS");
            RunAddNewVehicleTestWithInvalidDataOnDTO(testVehicleData);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VServicesAddNewVehicleFromDataInvalidVINTest()
        {
            VehicleDTO testVehicleData = VehicleDTO.FromData(VehicleType.CAR,
                "Ferrari", "Barchetta", 1985, "Red", "");
            RunAddNewVehicleTestWithInvalidDataOnDTO(testVehicleData);
        }

        private static void RunAddNewVehicleTestWithInvalidDataOnDTO(VehicleDTO testVehicleData)
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(v => v.Vehicles.ExistsVehicleWithVIN(
                It.IsAny<string>())).Returns(false);
            var vehicleServices = new VehicleServices(mockUnitOfWork.Object);
            vehicleServices.AddNewVehicleFromData(testVehicleData);
            mockUnitOfWork.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VServicesAddNewVehicleWithRepeatedVINInvalidTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(v => v.Vehicles.AddNewVehicle(It.IsAny<Vehicle>())).
                Throws(new RepositoryException(""));
            var vehicleServices = new VehicleServices(mockUnitOfWork.Object);
            vehicleServices.AddNewVehicleFromData(testingVehicleData);
        }
        #endregion

        #region GetRegisteredVehicles tests
        [TestMethod]
        public void VServicesGetRegisteredVehiclesWithDataTest()
        {
            var someVehicles = GetCollectionOfFakeVehicles();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(v => v.Vehicles.Elements).Returns(someVehicles)
                .Verifiable();
            var vehicleServices = new VehicleServices(mockUnitOfWork.Object);
            var result = vehicleServices.GetRegisteredVehicles().ToList();
            mockUnitOfWork.Verify();
            CollectionAssert.AreEqual(GetCollectionOfFakeVehicleDTOs(), result);
        }

        private IEnumerable<Vehicle> GetCollectionOfFakeVehicles()
        {
            return new List<Vehicle>
            {
                Vehicle.CreateNewVehicle(VehicleType.SUV, "Chevrolet", "Onix",
                    2016, "Green", "QWERTYUIO12345678"),
                Vehicle.CreateNewVehicle(VehicleType.CAR, "Renault",
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
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(v => v.Vehicles.Elements).Returns(new List<Vehicle>());
            var vehicleServices = new VehicleServices(mockUnitOfWork.Object);
            CollectionAssert.AreEqual(new List<VehicleDTO>(),
                vehicleServices.GetRegisteredVehicles().ToList());
        }
        #endregion

        #region GetVehicleWithVIN tests
        [TestMethod]
        public void VServicesGetVehicleWithVINValidTest()
        {
            VehicleDTO expectedData = VehicleDTO.FromVehicle(testingVehicle);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(v => v.Vehicles.GetVehicleWithVIN(testingVehicle.VIN))
                .Returns(testingVehicle).Verifiable();
            var vehicleServices = new VehicleServices(mockUnitOfWork.Object);
            var result = vehicleServices.GetVehicleWithVIN(testingVehicle.VIN);
            mockUnitOfWork.Verify();
            Assert.AreEqual(expectedData, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VServicesGetVehicleWithVINNotFoundInvalidTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(v => v.Vehicles.GetVehicleWithVIN(It.IsAny<string>()))
                .Throws(new RepositoryException(""));
            var vehicleServices = new VehicleServices(mockUnitOfWork.Object);
            vehicleServices.GetVehicleWithVIN(testingVehicle.VIN);
        }
        #endregion

        #region ModifyVehicleWithVIN tests
        [TestMethod]
        public void VServicesModifyVehicleWithVINValidTest()
        {
            Vehicle vehicleToModify = Vehicle.CreateNewVehicle(VehicleType.SUV, "Chevrolet",
                "Onix", 2016, "Green", "QWERTYUIO12345678");
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(v => v.Vehicles.GetVehicleWithVIN(vehicleToModify.VIN))
                .Returns(vehicleToModify).Verifiable();
            var userServices = new VehicleServices(mockUnitOfWork.Object);
            userServices.ModifyVehicleWithVIN(vehicleToModify.VIN, testingVehicleData);
            mockUnitOfWork.Verify();
            Assert.AreEqual(testingVehicleData.VIN, vehicleToModify.VIN);
            Assert.AreEqual(testingVehicleData.Type, vehicleToModify.Type);
            Assert.AreEqual(testingVehicleData.Model, vehicleToModify.Model);
            Assert.AreEqual(testingVehicleData.Brand, vehicleToModify.Brand);
            Assert.AreEqual(testingVehicleData.Year, vehicleToModify.Year);
            Assert.AreEqual(testingVehicleData.Color, vehicleToModify.Color);
        }

        [TestMethod]
        public void VServicesModifyVehicleWithVINSetSameVINValidTest()
        {
            Vehicle vehicleToModify = Vehicle.CreateNewVehicle(VehicleType.SUV, "Chevrolet",
                "Onix", 2016, "Green", "QWERTYUIO12345678");
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(v => v.Vehicles.GetVehicleWithVIN(vehicleToModify.VIN))
                .Returns(vehicleToModify).Verifiable();
            var userServices = new VehicleServices(mockUnitOfWork.Object);
            var dataToSet = VehicleDTO.FromVehicle(testingVehicle);
            dataToSet.VIN = vehicleToModify.VIN;
            userServices.ModifyVehicleWithVIN(vehicleToModify.VIN, dataToSet);
            mockUnitOfWork.Verify();
            Assert.AreEqual(dataToSet.VIN, vehicleToModify.VIN);
        }

        [TestMethod]
        public void VServicesModifyVehicleWithVINSetRepeatedVINInvalidTest()
        {
            Vehicle vehicleToModify = Vehicle.CreateNewVehicle(VehicleType.SUV, "Chevrolet",
                "Onix", 2016, "Green", "QWERTYUIO12345678");
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var dataToSet = VehicleDTO.FromVehicle(testingVehicle);
            mockUnitOfWork.Setup(v => v.Vehicles.GetVehicleWithVIN(vehicleToModify.VIN))
                .Returns(vehicleToModify).Verifiable();
            var userServices = new VehicleServices(mockUnitOfWork.Object);
            dataToSet.VIN = vehicleToModify.VIN;
            userServices.ModifyVehicleWithVIN(vehicleToModify.VIN, dataToSet);
            mockUnitOfWork.Verify();
            Assert.AreEqual(dataToSet.VIN, vehicleToModify.VIN);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VServicesModifyVehicleWithVINInvalidModelTest()
        {
            VehicleDTO someVehicleData = VehicleDTO.FromData(VehicleType.CAR, "2# -!@#-#3",
                "Megane", 1996, "DarkGray", "AJSNDQ122345MANSD");
            RunModifyVehicleTestWithInvalidDataOnDTO(someVehicleData);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VServicesModifyVehicleWithVINInvalidBrandTest()
        {
            VehicleDTO someVehicleData = VehicleDTO.FromData(VehicleType.CAR, "Renault",
                "&*(( ,...?89", 1996, "DarkGray", "AJSNDQ122345MANSD");
            RunModifyVehicleTestWithInvalidDataOnDTO(someVehicleData);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VServicesModifyVehicleWithVINInvalidTearTest()
        {
            VehicleDTO someVehicleData = VehicleDTO.FromData(VehicleType.CAR, "Renault",
                "Megane", 2112, "DarkGray", "AJSNDQ122345MANSD");
            RunModifyVehicleTestWithInvalidDataOnDTO(someVehicleData);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VServicesModifyVehicleWithVINInvalidColorTest()
        {
            VehicleDTO someVehicleData = VehicleDTO.FromData(VehicleType.CAR, "Renault",
                "Megane", 1996, "!@#$%^&*++", "AJSNDQ122345MANSD");
            RunModifyVehicleTestWithInvalidDataOnDTO(someVehicleData);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VServicesModifyVehicleWithVINInvalidVINTest()
        {
            VehicleDTO someVehicleData = VehicleDTO.FromData(VehicleType.CAR, "Renault",
                "Megane", 1996, "DarkGray", "Maybe(Typ->Top->Maybe Trop)");
            RunModifyVehicleTestWithInvalidDataOnDTO(someVehicleData);
        }

        private static void RunModifyVehicleTestWithInvalidDataOnDTO(VehicleDTO vehicleData)
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(v => v.Vehicles.GetVehicleWithVIN(testingVehicle.VIN)).Returns(testingVehicle);
            var vehicleServices = new VehicleServices(mockUnitOfWork.Object);
            vehicleServices.ModifyVehicleWithVIN(testingVehicle.VIN, vehicleData);
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void VServicesModifyVehicleWithVINCausesRepeatedVINInvalidTest()
        {
            Vehicle vehicleToModify = Vehicle.CreateNewVehicle(VehicleType.SUV, "Chevrolet",
                "Onix", 2016, "Green", "QWERTYUIO12345678");
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(v => v.Vehicles.ExistsVehicleWithVIN(testingVehicleData.VIN)).Returns(true);
            var userServices = new VehicleServices(mockUnitOfWork.Object);
            userServices.ModifyVehicleWithVIN(vehicleToModify.VIN, testingVehicleData);
        }
        #endregion

        #region RemoveVehicleWithVIN tests
        [TestMethod]
        public void VServicesRemoveVehicleWithVINValidTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(v => v.Vehicles.RemoveVehicleWithVIN(It.IsAny<string>()))
                .Verifiable();
            var vehicleServices = new VehicleServices(mockUnitOfWork.Object);
            vehicleServices.RemoveVehicleWithVIN("AJSNDQ122345MANSD");
            mockUnitOfWork.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VServicesRemoveVehicleWithUnregisteredVINInvalidTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(v => v.Vehicles.RemoveVehicleWithVIN(It.IsAny<string>()))
                .Throws(new RepositoryException("Message."));
            var vehicleServices = new VehicleServices(mockUnitOfWork.Object);
            vehicleServices.RemoveVehicleWithVIN(null);
        }
        #endregion

        [TestMethod]
        public void VehicleDTODefaultInternalConstructorTest()
        {
            var defaultVehicleDTO = new VehicleDTO();
            Assert.IsNull(defaultVehicleDTO.VIN);
            Assert.IsNull(defaultVehicleDTO.Model);
            Assert.IsNull(defaultVehicleDTO.Color);
            Assert.IsNull(defaultVehicleDTO.Brand);
            Assert.AreEqual(0, defaultVehicleDTO.Year);
            Assert.AreEqual(VehicleType.CAR, defaultVehicleDTO.Type);
        }

        [TestMethod]
        public void VehicleDTOEqualsWithDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingVehicleData, someRandomObject);
        }
    }
}
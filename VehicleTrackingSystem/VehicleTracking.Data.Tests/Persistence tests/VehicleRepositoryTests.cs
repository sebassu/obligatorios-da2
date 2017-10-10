using Domain;
using Persistence;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Data.Persistence_Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class VehicleRepositoryTests
    {
        private string unaddedVIN = "Wolololololololoo";
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static IVehicleRepository testingVehicleRepository;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingVehicleRepository = testingUnitOfWork.Vehicles;
        }

        [TestMethod]
        public void VRepositoryAddNewVehicleValidTest()
        {
            Vehicle vehicleToAdd = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR1");
            AddNewVehicleAndSave(vehicleToAdd);
            CollectionAssert.Contains(testingVehicleRepository.Elements.ToList(), vehicleToAdd);
        }

        [TestMethod]
        public void VRepositoryAddNewVehicleOnlyVINsMatchValidTest()
        {
            Vehicle addedVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR2");
            Vehicle vehicleToVerify = Vehicle.InstanceForTestingPurposes();
            vehicleToVerify.VIN = "RUSH2112MVNGPICR2";
            AddNewVehicleAndSave(addedVehicle);
            CollectionAssert.Contains(testingVehicleRepository.Elements.ToList(), vehicleToVerify);
        }

        [TestMethod]
        public void VRepositoryAddRepeatedVehicleValidTest()
        {
            Vehicle addedVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR3");
            AddNewVehicleAndSave(addedVehicle);
            AddNewVehicleAndSave(addedVehicle);
            CollectionAssert.Contains(testingVehicleRepository.Elements.ToList(), addedVehicle);
        }

        [TestMethod]
        public void VRepositoryAddNewVehicleRepeatedVINValidTest()
        {
            Vehicle someVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR4");
            Vehicle someOtherVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV, "BMW",
                "Modelname", 2001, "Purple", "RUSH2112MVNGPICR4");
            AddNewVehicleAndSave(someVehicle);
            AddNewVehicleAndSave(someOtherVehicle);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryAddNullVehicleInvalidTest()
        {
            AddNewVehicleAndSave(null);
        }

        [TestMethod]
        public void VRepositoryRemoveVehicleValidTest()
        {
            Vehicle vehicleToVerify = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR5");
            AddNewVehicleAndSave(vehicleToVerify);
            RemoveVehicleWithVINAndSave(vehicleToVerify.VIN);
            CollectionAssert.DoesNotContain(testingVehicleRepository.Elements.ToList(), vehicleToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryRemoveVehicleNotInRepositoryInvalidTest()
        {
            Vehicle vehicleToVerify = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR6");
            RemoveVehicleWithVINAndSave(vehicleToVerify.VIN);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryRemoveVehicleNullVINInvalidTest()
        {
            RemoveVehicleWithVINAndSave(null);
        }

        [TestMethod]
        public void VRepositoryModifyVehicleValidTest()
        {
            Vehicle vehicleToModify = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR7");
            AddNewVehicleAndSave(vehicleToModify);
            SetVehicleData(vehicleToModify, VehicleType.SUV, "Chevrolet", "Onix",
                2016, "Green", "QWERTYUIO12345678");
            UpdateVehicleAndSave(vehicleToModify);
            Assert.AreEqual(VehicleType.SUV, vehicleToModify.Type);
            Assert.AreEqual("Chevrolet", vehicleToModify.Brand);
            Assert.AreEqual("Onix", vehicleToModify.Model);
            Assert.AreEqual(2016, vehicleToModify.Year);
            Assert.AreEqual("Green", vehicleToModify.Color);
            Assert.AreEqual("QWERTYUIO12345678", vehicleToModify.VIN);
        }

        [TestMethod]
        public void VRepositoryModifyVehicleSetSameDataValidTest()
        {
            Vehicle vehicleToModify = testingVehicleRepository.Elements.First();
            var previousType = vehicleToModify.Type;
            var previousModel = vehicleToModify.Model;
            var previousBrand = vehicleToModify.Brand;
            var previousYear = vehicleToModify.Year;
            var previousColor = vehicleToModify.Color;
            var previousVIN = vehicleToModify.VIN;
            SetVehicleData(vehicleToModify, previousType, previousBrand, previousModel,
                previousYear, previousColor, previousVIN);
            Assert.AreEqual(previousType, vehicleToModify.Type);
            Assert.AreEqual(previousBrand, vehicleToModify.Brand);
            Assert.AreEqual(previousModel, vehicleToModify.Model);
            Assert.AreEqual(previousYear, vehicleToModify.Year);
            Assert.AreEqual(previousColor, vehicleToModify.Color);
            Assert.AreEqual(previousVIN, vehicleToModify.VIN);
        }

        private void SetVehicleData(Vehicle vehicleToModify, VehicleType typeToSet, string brandToSet,
            string modelToSet, short yearToSet, string colorToSet, string vinToSet)
        {
            vehicleToModify.Type = typeToSet;
            vehicleToModify.Brand = brandToSet;
            vehicleToModify.Model = modelToSet;
            vehicleToModify.Year = yearToSet;
            vehicleToModify.Color = colorToSet;
            vehicleToModify.VIN = vinToSet;
            UpdateVehicleAndSave(vehicleToModify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryModifyNullVehicleInvalidTest()
        {
            UpdateVehicleAndSave(null);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryModifyNotAddedVehicleInvalidTest()
        {
            Vehicle notAddedVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICRS");
            UpdateVehicleAndSave(notAddedVehicle);
        }

        [TestMethod]
        public void VRepositoryGetVehicleByVINValidTest()
        {
            Vehicle addedVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR9");
            AddNewVehicleAndSave(addedVehicle);
            Vehicle result = testingVehicleRepository.GetVehicleWithVIN("RUSH2112MVNGPICR9");
            Assert.AreEqual(addedVehicle, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryGetVehicleByUnaddedVINInvalidTest()
        {
            testingVehicleRepository.GetVehicleWithVIN(unaddedVIN);
        }

        [TestMethod]
        public void VRepositoryExistsVehicleWithVINAddedTest()
        {
            Vehicle userToVerify = testingVehicleRepository.Elements.First();
            bool result = testingVehicleRepository.ExistsVehicleWithVIN(userToVerify.VIN);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void VRepositoryExistsVehicleWithVINUnaddedTest()
        {
            bool result = testingVehicleRepository.ExistsVehicleWithVIN(
                unaddedVIN);
            Assert.IsFalse(result);
        }

        private static void AddNewVehicleAndSave(Vehicle vehicleToAdd)
        {
            testingVehicleRepository.AddNewVehicle(vehicleToAdd);
            testingUnitOfWork.SaveChanges();
        }

        private void UpdateVehicleAndSave(Vehicle vehicleToModify)
        {
            testingVehicleRepository.UpdateVehicle(vehicleToModify);
            testingUnitOfWork.SaveChanges();
        }

        private void RemoveVehicleWithVINAndSave(string vin)
        {
            testingVehicleRepository.RemoveVehicleWithVIN(vin);
            testingUnitOfWork.SaveChanges();
        }
    }
}
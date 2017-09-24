using Domain;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;

namespace Data.Persistence_Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class VehicleRepositoryTests
    {
        [TestMethod]
        public void VRepositoryAddNewVehicleValidTest()
        {
            Vehicle vehicleToVerify = Vehicle.CreateNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "ASDFGHJKL12345678");
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "ASDFGHJKL12345678");
            CollectionAssert.Contains(VehicleRepository.Elements.ToList(), vehicleToVerify);
        }

        [TestMethod]
        public void VRepositoryAddNewVehicleReturnsAddedVehicleValidTest()
        {
            Vehicle addedVehicle = VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "12345678ASDFGHJKL");
            CollectionAssert.Contains(VehicleRepository.Elements.ToList(), addedVehicle);
        }

        [TestMethod]
        public void VRepositoryAddNewVehicleOnlyVINMatchValidTest()
        {
            Vehicle vehicleToVerify = Vehicle.InstanceForTestingPurposes();
            vehicleToVerify.VIN = "ZXCVBNM1234567890";
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "ZXCVBNM1234567890");
            CollectionAssert.Contains(VehicleRepository.Elements.ToList(), vehicleToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryAddRepeatedVehicleInvalidTest()
        {
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "QWERTYUIOP1234567");
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "QWERTYUIOP1234567");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryAddNewVehicleRepeatedVINInvalidTest()
        {
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "123456789QWERTYUI");
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Audi", "A1",
                2017, "Black", "123456789QWERTYUI");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryAddNewVehicleInvalidBrandTest()
        {
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "¡Chevrolet123!", "Onix",
                2015, "Red", "1Q2W3E4R5T6Y7U8I9");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryAddNewVehicleInvalidModelTest()
        {
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix#",
                2015, "Red", "Q1W2E3R4T5Y6U7I8O");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryAddNewVehicleInvalidYearTest()
        {
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2030, "Red", "QW12ER34TY56UI78O");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryAddNewVehicleInvalidColorTest()
        {
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "!@#", "QWERTYUIOPASDFGHJ");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryAddNewVehicleInvalidVINTest()
        {
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "ZXCVBNM");
        }

        [TestMethod]
        public void VRepositoryRemoveVehicleValidTest()
        {
            Vehicle vehicleToVerify = VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "1A2S3D4F5G6H7J8K9");
            VehicleRepository.Remove(vehicleToVerify);
            CollectionAssert.DoesNotContain(VehicleRepository.Elements.ToList(), vehicleToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryRemoveVehicleNotInRepositoryInvalidTest()
        {
            Vehicle vehicleToVerify = Vehicle.CreateNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "1234567890ZAXSCDV");
            VehicleRepository.Remove(vehicleToVerify);
        }

        /*[TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryRemoveNullVehicleInvalidTest()
        {
            VehicleRepository.Remove(null);
        }*/

        [TestMethod]
        public void VRepositoryModifyVehicleValidTest()
        {
            Vehicle vehicleToModify = VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "1234567890AQSWDEF");
            VehicleRepository.ModifyVehicle(vehicleToModify, VehicleType.SUV, "Suzuki", "Vitara",
                2016, "Grey", "0987654321POIUYTR");
            Assert.AreEqual(VehicleType.SUV, vehicleToModify.Type);
            Assert.AreEqual("Suzuki", vehicleToModify.Brand);
            Assert.AreEqual("Vitara", vehicleToModify.Model);
            Assert.AreEqual(2016, vehicleToModify.Year);
            Assert.AreEqual("Grey", vehicleToModify.Color);
            Assert.AreEqual("0987654321POIUYTR", vehicleToModify.VIN);
        }

        [TestMethod]
        public void VRepositoryModifyVehicleSetSameDataValidTest()
        {
            Vehicle vehicleToVerify = VehicleRepository.Elements.First();
            var prevoiusType = vehicleToVerify.Type;
            var previousBrand = vehicleToVerify.Brand;
            var previousModel = vehicleToVerify.Model;
            var prevoiusYear = vehicleToVerify.Year;
            var previousColor = vehicleToVerify.Color;
            var previousVIN = vehicleToVerify.VIN;
            VehicleRepository.ModifyVehicle(vehicleToVerify, prevoiusType, previousBrand,
                previousModel, prevoiusYear, previousColor, previousVIN);
            Assert.AreEqual(prevoiusType, vehicleToVerify.Type);
            Assert.AreEqual(previousBrand, vehicleToVerify.Brand);
            Assert.AreEqual(previousModel, vehicleToVerify.Model);
            Assert.AreEqual(prevoiusYear, vehicleToVerify.Year);
            Assert.AreEqual(previousColor, vehicleToVerify.Color);
            Assert.AreEqual(previousVIN, vehicleToVerify.VIN);

        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryModifyNullVehicleInvalidTest()
        {
            VehicleRepository.ModifyVehicle(null, VehicleType.SUV, "Suzuki", "Vitara",
                2016, "Grey", "0987654321POIUYTR");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryModifyNotAddedVehicleInvalidTest()
        {
            Vehicle notAddedVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV, "Suzuki", "Vitara",
                2016, "Grey", "P0O9I8U76T5R4E3W2");
            VehicleRepository.ModifyVehicle(notAddedVehicle, VehicleType.SUV, "Suzuki", "Vitara",
                2016, "Grey", "0987654321POIUYTR");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryModifyVehicleInvalidBrandTest()
        {
            Vehicle addedVehicle = VehicleRepository.Elements.FirstOrDefault();
            VehicleRepository.ModifyVehicle(addedVehicle, addedVehicle.Type, "12345#", addedVehicle.Model,
                addedVehicle.Year, addedVehicle.Color, addedVehicle.VIN);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryModifyVehicleInvalidModelTest()
        {
            Vehicle addedVehicle = VehicleRepository.Elements.FirstOrDefault();
            VehicleRepository.ModifyVehicle(addedVehicle, addedVehicle.Type, addedVehicle.Brand, "!@#$%",
                addedVehicle.Year, addedVehicle.Color, addedVehicle.VIN);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryModifyVehicleInvalidYearTest()
        {
            Vehicle addedVehicle = VehicleRepository.Elements.FirstOrDefault();
            VehicleRepository.ModifyVehicle(addedVehicle, addedVehicle.Type, addedVehicle.Brand,
                addedVehicle.Model, 2222, addedVehicle.Color, addedVehicle.VIN);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryModifyVehicleInvalidColorTest()
        {
            Vehicle addedVehicle = VehicleRepository.Elements.FirstOrDefault();
            VehicleRepository.ModifyVehicle(addedVehicle, addedVehicle.Type, addedVehicle.Brand,
                addedVehicle.Model, addedVehicle.Year, "!@#$%", addedVehicle.VIN);
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryModifyVehicleInvalidVINTest()
        {
            Vehicle addedVehicle = VehicleRepository.Elements.FirstOrDefault();
            VehicleRepository.ModifyVehicle(addedVehicle, addedVehicle.Type, addedVehicle.Brand,
                addedVehicle.Model, addedVehicle.Year, addedVehicle.Color, "1234567");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryModifyVehicleCausesRepeatedVINInvalidTest()
        {
            Vehicle vehicleToModify = VehicleRepository.AddNewVehicle(VehicleType.SUV, "Suzuki", "Vitara",
                2016, "Grey", "0987654321POIUBNM");
            VehicleRepository.AddNewVehicle(VehicleType.SUV, "Audi", "A1",
                2016, "Red", "0987654321POIÑLKJ");
            VehicleRepository.ModifyVehicle(vehicleToModify, VehicleType.SUV, "Suzuki", "Vitara",
                2016, "Grey", "0987654321POIÑLKJ");
        }
    }
}
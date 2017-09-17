using Domain;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;

namespace Data.Persistence.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class VehicleRepositoryTests
    {
   
        //AddNewVehicle
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
        public void VRepositoryAddNewVehicleOnlyVinMatchValidTest()
        {
            Vehicle vehicleToVerify = Vehicle.InstanceForTestingPurposes();
            vehicleToVerify.Vin = "ZXCVBNM1234567890";
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
        public void VRepositoryAddNewVehicleRepeatedVinInvalidTest()
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
        public void VRepositoryAddNewVehicleInvalidVinTest()
        {
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "ZXCVBNM");
        }

        //RemoveVehicle
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

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryRemoveNullVehicleInvalidTest()
        {
            VehicleRepository.Remove(null);
        }
    }
}
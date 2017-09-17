using Domain;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;

namespace Data.Tests.Repository_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class VehicleRepositoryTests
    {
        [AssemblyInitialize]
        public static void AssemblySetup(TestContext context)
        {
            DeleteAllDatabaseData();
        }

        [AssemblyCleanup]
        public static void AssemblySetup()
        {
            DeleteAllDatabaseData();
        }

        private static void DeleteAllDatabaseData()
        {
            using (var context = new VTSystemContext())
            {
                context.DeleteAllData();
            }
        }

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
        public void VRepositoryAddNewVehcleReturnsAddedVehicleValidTest()
        {
            Vehicle addedVehicle = VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "ASDFGHJKL12345678");
            CollectionAssert.Contains(VehicleReposiory.Elements.ToList(), addedVehicle);
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
                2015, "Red", "ZXCVBNM1234567890");
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "ZXCVBNM1234567890");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryAddNewVehicleRepeatedVinInvalidTest()
        {
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "ZXCVBNM1234567890");
            VehicleRepository.AddNewUser(VehicleType.CAR, "Audi", "A1",
                2017, "Black", "ZXCVBNM1234567890");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryAddNewVehicleInvalidBrandTest()
        {
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "¡Chevrolet!", "Onix",
                2015, "Red", "ZXCVBNM1234567890");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryAddNewVehicleInvalidModelTest()
        {
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix#",
                2015, "Red", "ZXCVBNM1234567890");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryAddNewVehicleInvalidYearTest()
        {
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2030, "Red", "ZXCVBNM1234567890");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryAddNewVehicleInvalidColorTest()
        {
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "!@#", "ZXCVBNM1234567890");
        }

        [TestMethod]
        [ExpectedException(typeof(VehicleException))]
        public void VRepositoryAddNewVehicleInvalidVinTest()
        {
            VehicleRepository.AddNewVehicle(VehicleType.CAR, "Chevrolet", "Onix",
                2015, "Red", "ZXCVBNM");
        }

    }
}
using Domain;
using Persistence;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence_tests
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
            Assert.IsNotNull(testingVehicleRepository);
        }

        #region AddNewVehicle tests
        [TestMethod]
        public void VRepositoryAddNewVehicleValidTest()
        {
            Vehicle vehicleToAdd = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR1");
            AddNewVehicleAndSaveChanges(vehicleToAdd);
            CollectionAssert.Contains(testingVehicleRepository.Elements.ToList(), vehicleToAdd);
        }

        [TestMethod]
        public void VRepositoryAddNewVehicleOnlyVINsMatchValidTest()
        {
            Vehicle addedVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR2");
            Vehicle vehicleToVerify = Vehicle.InstanceForTestingPurposes();
            vehicleToVerify.VIN = "RUSH2112MVNGPICR2";
            AddNewVehicleAndSaveChanges(addedVehicle);
            CollectionAssert.Contains(testingVehicleRepository.Elements.ToList(), vehicleToVerify);
        }

        [TestMethod]
        public void VRepositoryAddRepeatedVehicleValidTest()
        {
            Vehicle addedVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR3");
            AddNewVehicleAndSaveChanges(addedVehicle);
            AddNewVehicleAndSaveChanges(addedVehicle);
            CollectionAssert.Contains(testingVehicleRepository.Elements.ToList(), addedVehicle);
        }

        [TestMethod]
        public void VRepositoryAddNewVehicleRepeatedVINValidTest()
        {
            Vehicle someVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR4");
            Vehicle someOtherVehicle = Vehicle.CreateNewVehicle(VehicleType.SUV, "BMW",
                "Modelname", 2001, "Purple", "RUSH2112MVNGPICR4");
            AddNewVehicleAndSaveChanges(someVehicle);
            AddNewVehicleAndSaveChanges(someOtherVehicle);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryAddNullVehicleInvalidTest()
        {
            AddNewVehicleAndSaveChanges(null);
        }
        #endregion

        #region GetVehicleWithVIN tests
        [TestMethod]
        public void VRepositoryGetVehicleWithVINValidTest()
        {
            Vehicle addedVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR9");
            AddNewVehicleAndSaveChanges(addedVehicle);
            Vehicle result = testingVehicleRepository.GetVehicleWithVIN("RUSH2112MVNGPICR9");
            Assert.AreEqual(addedVehicle, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryGetVehicleWithUnaddedVINInvalidTest()
        {
            testingVehicleRepository.GetVehicleWithVIN(unaddedVIN);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryGetVehicleWithNullVINInvalidTest()
        {
            testingVehicleRepository.GetVehicleWithVIN(null);
        }
        #endregion

        #region ExistsVehicleWithVIN tests
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

        [TestMethod]
        public void VRepositoryNoVehicleWithNullVINExistsTest()
        {
            bool result = testingVehicleRepository.ExistsVehicleWithVIN(null);
            Assert.IsFalse(result);
        }
        #endregion

        #region ModifyVehicle tests
        [TestMethod]
        public void VRepositoryModifyVehicleValidTest()
        {
            Vehicle vehicleToModify = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR7");
            AddNewVehicleAndSaveChanges(vehicleToModify);
            SetVehicleData(vehicleToModify, VehicleType.SUV, "Chevrolet", "Onix",
                2016, "Green", "QWERTYUIO12345678");
            UpdateVehicleAndSaveChanges(vehicleToModify);
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
            UpdateVehicleAndSaveChanges(vehicleToModify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryModifyNullVehicleInvalidTest()
        {
            UpdateVehicleAndSaveChanges(null);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryModifyUnaddedVehicleInvalidTest()
        {
            Vehicle notAddedVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICRS");
            UpdateVehicleAndSaveChanges(notAddedVehicle);
        }
        #endregion

        #region RemoveVehicle tests
        [TestMethod]
        public void VRepositoryRemoveVehicleValidTest()
        {
            Vehicle vehicleToVerify = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR5");
            AddNewVehicleAndSaveChanges(vehicleToVerify);
            RemoveVehicleWithVINAndSaveChanges(vehicleToVerify.VIN);
            CollectionAssert.DoesNotContain(testingVehicleRepository.Elements.ToList(), vehicleToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryRemoveVehicleNotInRepositoryInvalidTest()
        {
            Vehicle vehicleToVerify = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR6");
            RemoveVehicleWithVINAndSaveChanges(vehicleToVerify.VIN);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void VRepositoryRemoveVehicleNullVINInvalidTest()
        {
            RemoveVehicleWithVINAndSaveChanges(null);
        }
        #endregion

        [TestMethod]
        public void GRepositoryPerformAttachTest()
        {
            using (var secondUnitOfWork = new UnitOfWork())
            {
                Vehicle vehicleToAttach = Vehicle.InstanceForTestingPurposes();
                AddNewVehicleAndSaveChanges(vehicleToAttach);
                var secondVehicles = secondUnitOfWork.Vehicles;
                var castRepostory = secondVehicles as GenericRepository<Vehicle>;
                castRepostory.PerformAttachIfCorresponds(vehicleToAttach);
                Assert.IsTrue(secondUnitOfWork.context.Entry(vehicleToAttach).State
                    == System.Data.Entity.EntityState.Unchanged);
            }
        }

        private static void AddNewVehicleAndSaveChanges(Vehicle vehicleToAdd)
        {
            testingVehicleRepository.AddNewVehicle(vehicleToAdd);
            testingUnitOfWork.SaveChanges();
        }

        private void UpdateVehicleAndSaveChanges(Vehicle vehicleToModify)
        {
            testingVehicleRepository.UpdateVehicle(vehicleToModify);
            testingUnitOfWork.SaveChanges();
        }

        private void RemoveVehicleWithVINAndSaveChanges(string vin)
        {
            testingVehicleRepository.RemoveVehicleWithVIN(vin);
            testingUnitOfWork.SaveChanges();
        }
    }
}
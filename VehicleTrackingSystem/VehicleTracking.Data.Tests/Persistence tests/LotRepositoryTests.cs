using Domain;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Persistence;

namespace Data.Tests.Persistence_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LotRepositoryTests
    {
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static ILotRepository testingLotRepository;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingLotRepository = testingUnitOfWork.Lots;
        }

        [TestMethod]
        public void LRepositoryAddNewLotValidTest()
        {
            User userToAdd = User.CreateNewUser(UserRoles.ADMINISTRATOR,
                "Mario", "Santos", "mSantos1", "DisculpeFuegoTiene", "099424242");
            Vehicle vehicleToAdd1 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR1");
            Vehicle vehicleToAdd2 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR2");
            ICollection<Vehicle> list = new List<Vehicle>();
            list.Add(vehicleToAdd1);
            list.Add(vehicleToAdd2);
            Lot lotToVerify = Lot.CreatorNameDescriptionVehicles(userToAdd, "Lot 1", "Only Ferrari lot.", list);
            AddNewLotAndSaveChanges(lotToVerify);
            CollectionAssert.Contains(testingLotRepository.Elements.ToList(), lotToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void LRepositoryAddNullLotInvalidTest()
        {
            AddNewLotAndSaveChanges(null);
        }

        [TestMethod]
        public void LRepositoryRemoveLotValidTest()
        {
            User userToAdd = User.CreateNewUser(UserRoles.ADMINISTRATOR,
                "Mario", "Santos", "mSantos1", "DisculpeFuegoTiene", "099424242");
            Vehicle vehicleToAdd1 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR3");
            Vehicle vehicleToAdd2 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR4");
            ICollection<Vehicle> list = new List<Vehicle>();
            list.Add(vehicleToAdd1);
            list.Add(vehicleToAdd2);
            Lot lotToVerify = Lot.CreatorNameDescriptionVehicles(userToAdd, "Lot 2", "Only Ferrari lot.", list);
            AddNewLotAndSaveChanges(lotToVerify);
            RemoveLotWithIdAndSaveChanges(lotToVerify.Name);
            CollectionAssert.DoesNotContain(testingLotRepository.Elements.ToList(), lotToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void LRepositoryRemoveLotNotInRepositoryInvalidTest()
        {
            User userToAdd = User.CreateNewUser(UserRoles.ADMINISTRATOR,
                "Mario", "Santos", "mSantos1", "DisculpeFuegoTiene", "099424242");
            Vehicle vehicleToAdd1 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR3");
            Vehicle vehicleToAdd2 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR4");
            ICollection<Vehicle> list = new List<Vehicle>();
            list.Add(vehicleToAdd1);
            list.Add(vehicleToAdd2);
            Lot lotToVerify = Lot.CreatorNameDescriptionVehicles(userToAdd, "Lot 3", "Only Ferrari lot.", list);
            RemoveLotWithIdAndSaveChanges(lotToVerify.Name);
        }

        [TestMethod]
        public void LRepositoryModifyLotValidTest()
        {
            User userToAdd = User.CreateNewUser(UserRoles.ADMINISTRATOR,
                "Mario", "Santos", "mSantos1", "DisculpeFuegoTiene", "099424242");
            Vehicle vehicleToAdd1 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR5");
            Vehicle vehicleToAdd2 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR6");
            ICollection<Vehicle> list = new List<Vehicle>();
            list.Add(vehicleToAdd1);
            list.Add(vehicleToAdd2);
            Lot lotToVerify = Lot.CreatorNameDescriptionVehicles(userToAdd, "Lot 4", "Only Ferrari lot.", list);
            AddNewLotAndSaveChanges(lotToVerify);
            list.Remove(vehicleToAdd1);
            SetLotData(lotToVerify, "Modified lot", "Some new description", list);
            Assert.AreEqual(userToAdd, lotToVerify.Creator);
            Assert.AreEqual("Modified lot", lotToVerify.Name);
            Assert.AreEqual("Some new description", lotToVerify.Description);
            Assert.IsTrue(list.SequenceEqual(lotToVerify.Vehicles));
        }

        private void SetLotData(Lot lotToModify, string nameToSet, 
            string descriptionToSet, ICollection<Vehicle> listToSet)
        {
            lotToModify.Name = nameToSet;
            lotToModify.Description = descriptionToSet;
            lotToModify.Vehicles = listToSet;
            UpdateLotAndSaveChanges(lotToModify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void LRepositoryModifyNullLotInvalidTest()
        {
            UpdateLotAndSaveChanges(null);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void LRepositoryModifyNotAddedLotInvalidTest()
        {
            User userToAdd = User.CreateNewUser(UserRoles.ADMINISTRATOR,
                "Mario", "Santos", "mSantos1", "DisculpeFuegoTiene", "099424242");
            Vehicle vehicleToAdd1 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR2");
            Vehicle vehicleToAdd2 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR1");
            ICollection<Vehicle> list = new List<Vehicle>();
            list.Add(vehicleToAdd1);
            list.Add(vehicleToAdd2);
            Lot notAddedLot = Lot.CreatorNameDescriptionVehicles(userToAdd, "Lot 5", "Only Ferrari lot.", list);
            UpdateLotAndSaveChanges(notAddedLot);
        }

        [TestMethod]
        public void LRepositoryGetLotByNameValidTest()
        {
            User userToAdd = User.CreateNewUser(UserRoles.ADMINISTRATOR,
                "Mario", "Santos", "mSantos1", "DisculpeFuegoTiene", "099424242");
            Vehicle vehicleToAdd1 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR2");
            Vehicle vehicleToAdd2 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR1");
            ICollection<Vehicle> list = new List<Vehicle>();
            list.Add(vehicleToAdd1);
            list.Add(vehicleToAdd2);
            Lot lotToVerify = Lot.CreatorNameDescriptionVehicles(userToAdd, "Lot 5", "Only Ferrari lot.", list);
            AddNewLotAndSaveChanges(lotToVerify);
            Lot result = testingLotRepository.GetLotByName(lotToVerify.Name);
            Assert.AreEqual(lotToVerify, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void LRepositoryGetLotByNameUnaddedNameInvalidTest()
        {
            testingLotRepository.GetLotByName("Not existing zone");
        }

        [TestMethod]
        public void LRepositoryExistsLotWithNameAddedTest()
        {
            User userToAdd = User.CreateNewUser(UserRoles.ADMINISTRATOR,
               "Mario", "Santos", "mSantos1", "DisculpeFuegoTiene", "099424242");
            Vehicle vehicleToAdd1 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR5");
            Vehicle vehicleToAdd2 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR6");
            ICollection<Vehicle> list = new List<Vehicle>();
            list.Add(vehicleToAdd1);
            list.Add(vehicleToAdd2);
            Lot lotToVerify = Lot.CreatorNameDescriptionVehicles(userToAdd, "Lot 5", "Only Ferrari lot.", list);
            AddNewLotAndSaveChanges(lotToVerify);
            bool result = testingLotRepository.ExistsLotWithName(
                lotToVerify.Name);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LRepositoryExistsLotWithNameUnaddedTest()
        {
            bool result = testingLotRepository.ExistsLotWithName(
                "This is a new name");
            Assert.IsFalse(result);
        }
        private static void AddNewLotAndSaveChanges(Lot lotToAdd)
        {
            testingLotRepository.AddNewLot(lotToAdd);
            testingUnitOfWork.SaveChanges();
        }

        private static void RemoveLotWithIdAndSaveChanges(string nameToRemove)
        {
            testingLotRepository.RemoveLotWithName(nameToRemove);
            testingUnitOfWork.SaveChanges();
        }

        private static void UpdateLotAndSaveChanges(Lot lotToModify)
        {
            testingLotRepository.UpdateLot(lotToModify);
            testingUnitOfWork.SaveChanges();
        }
    }
}

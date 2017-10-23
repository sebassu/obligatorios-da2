using Domain;
using System.Linq;
using Persistence;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LotRepositoryTests
    {
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static ILotRepository testingLotRepository;
        private static readonly User testingCreator = User.CreateNewUser(UserRoles.ADMINISTRATOR,
            "Mario", "Santos", "mSantos", "DisculpeFuegoTiene", "099424242");

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingLotRepository = testingUnitOfWork.Lots;
        }

        #region AddNewLot tests
        [TestMethod]
        public void LRepositoryAddNewLotValidTest()
        {
            Lot lotToVerify = GetNewValidTestingLotWithName("Lot 1");
            AddNewLotAndSaveChanges(lotToVerify);
            CollectionAssert.Contains(testingLotRepository.Elements.ToList(), lotToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void LRepositoryAddNullLotInvalidTest()
        {
            AddNewLotAndSaveChanges(null);
        }
        #endregion

        #region UpdateLotWithId tests
        [TestMethod]
        public void LRepositoryModifyLotValidTest()
        {
            Lot lotToVerify = GetNewValidTestingLotWithName("Lot 4");
            AddNewLotAndSaveChanges(lotToVerify);
            var newVehicleList = new List<Vehicle>() {
                Vehicle.InstanceForTestingPurposes() };
            SetLotData(lotToVerify, "Modified lot", "Some new description", newVehicleList);
            Assert.AreEqual(testingCreator, lotToVerify.Creator);
            Assert.AreEqual("Modified lot", lotToVerify.Name);
            Assert.AreEqual("Some new description", lotToVerify.Description);
            CollectionAssert.AreEqual(newVehicleList, lotToVerify.Vehicles.ToList());
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
            Lot notAddedLot = GetNewValidTestingLotWithName("Lot 5");
            UpdateLotAndSaveChanges(notAddedLot);
        }
        #endregion

        #region GetLotWithName tests
        [TestMethod]
        public void LRepositoryGetLotWithNameValidTest()
        {
            Lot lotToVerify = GetNewValidTestingLotWithName("Lot 6");
            AddNewLotAndSaveChanges(lotToVerify);
            Lot result = testingLotRepository.GetLotWithName(lotToVerify.Name);
            Assert.AreEqual(lotToVerify, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void LRepositoryGetLotWithUnaddedNameInvalidTest()
        {
            testingLotRepository.GetLotWithName("Non-existing lot");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void LRepositoryGetLotWithNullNameInvalidTest()
        {
            testingLotRepository.GetLotWithName(null);
        }
        #endregion

        #region ExistsLotWithName tests
        [TestMethod]
        public void LRepositoryExistsLotWithNameAddedTest()
        {
            Lot lotToVerify = GetNewValidTestingLotWithName("Lot 7");
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

        [TestMethod]
        public void LRepositoryNoLotWithNullNameExistsTest()
        {
            bool result = testingLotRepository.ExistsLotWithName(null);
            Assert.IsFalse(result);
        }
        #endregion

        #region RemoveLotWithId tests
        [TestMethod]
        public void LRepositoryRemoveLotWithIdValidTest()
        {
            Lot lotToVerify = GetNewValidTestingLotWithName("Lot 2");
            AddNewLotAndSaveChanges(lotToVerify);
            RemoveLotWithIdAndSaveChanges(lotToVerify.Name);
            CollectionAssert.DoesNotContain(testingLotRepository.Elements.ToList(), lotToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void LRepositoryRemoveLotWithIdNotInRepositoryInvalidTest()
        {
            Lot lotToVerify = GetNewValidTestingLotWithName("Lot 3");
            RemoveLotWithIdAndSaveChanges(lotToVerify.Name);
        }
        #endregion

        private static Lot GetNewValidTestingLotWithName(string nameToSet)
        {
            Vehicle vehicleToAdd1 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR1");
            Vehicle vehicleToAdd2 = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICR2");
            ICollection<Vehicle> list = new List<Vehicle>
            {
                vehicleToAdd1,
                vehicleToAdd2
            };
            Lot lotToVerify = Lot.CreatorNameDescriptionVehicles(testingCreator,
                nameToSet, "Only Ferrari lot.", list);
            return lotToVerify;
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
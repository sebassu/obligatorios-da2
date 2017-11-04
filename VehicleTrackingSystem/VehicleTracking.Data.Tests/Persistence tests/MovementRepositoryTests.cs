using System;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;
using System.Linq;
using System.Collections.Generic;

namespace Data.Persistence_tests
{
    [TestClass]
    public class MovementRepositoryTests
    {
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static IMovementRepository testingMovementRepository;
        private static readonly User testingPortOperator = User.CreateNewUser(UserRoles.PORT_OPERATOR,
            "Gabriel David", "Medina", "gdMedina", "MusicaSuperDivertida", "09996896");
        private static readonly User testingYardOperator = User.CreateNewUser(UserRoles.YARD_OPERATOR,
            "Emilio", "Ravenna", "eRavenna", "HablarUnasPalabritas", "099212121");

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingMovementRepository = testingUnitOfWork.Movements;
            Assert.IsNotNull(testingMovementRepository);
        }

        #region AddNewMovement tests
        [TestMethod]
        public void MRepositoryAddNewMovementValidTest()
        {
            var movementToAdd = GetNewValidTestingMovement();
            AddNewMovementAndSaveChanges(movementToAdd);
            CollectionAssert.Contains(testingMovementRepository
                .Elements.ToList(), movementToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void MRepositoryAddNullMovementInvalidTest()
        {
            AddNewMovementAndSaveChanges(null);
        }
        #endregion

        #region SubzoneParticipatesInSomeMovement tests
        [TestMethod]
        public void MRepositoryDepartureSubzoneParticipatesInSomeMovementTest()
        {
            var movementToAdd = GetNewValidTestingMovement();
            AddNewMovementAndSaveChanges(movementToAdd);
            Assert.IsTrue(testingMovementRepository
                .SubzoneParticipatesInSomeMovement(movementToAdd.Departure));
        }

        [TestMethod]
        public void MRepositoryArrivalSubzoneParticipatesInSomeMovementTest()
        {
            var movementToAdd = GetNewValidTestingMovement();
            AddNewMovementAndSaveChanges(movementToAdd);
            Assert.IsTrue(testingMovementRepository
                .SubzoneParticipatesInSomeMovement(movementToAdd.Arrival));
        }

        [TestMethod]
        public void MRepositoryUnadddedSubzoneDoesNotParticipateInAnyMovementTest()
        {
            var someRandomSubzone = Subzone.InstanceForTestingPurposes();
            Assert.IsFalse(testingMovementRepository
                .SubzoneParticipatesInSomeMovement(someRandomSubzone));
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void MRepositoryNullSubzoneParticipatesInAnyMovementInvalidTest()
        {
            testingMovementRepository.SubzoneParticipatesInSomeMovement(null);
        }
        #endregion

        #region Default ElementExistsInCollection tests
        [TestMethod]
        public void MRepositoryElementExistsInCollectionExistingElementTest()
        {
            var addedMovement = GetNewValidTestingMovement();
            AddNewMovementAndSaveChanges(addedMovement);
            var castRepostory = testingMovementRepository as GenericRepository<Movement>;
            Assert.IsFalse(castRepostory.ElementExistsInCollection(addedMovement));
        }

        [TestMethod]
        public void MRepositoryElementExistsInCollectionUnaddedElementTest()
        {
            var unaddedMovement = Movement.InstanceForTestingPurposes();
            var castRepostory = testingMovementRepository as GenericRepository<Movement>;
            Assert.IsFalse(castRepostory.ElementExistsInCollection(unaddedMovement));
        }
        #endregion

        private static Movement GetNewValidTestingMovement()
        {
            Vehicle testingVehicle = GetNewValidVehicleForMovement();
            Zone testingZone = Zone.InstanceForTestingPurposes();
            Zone someOtherZone = Zone.CreateNewZone("Other zone", 42);
            Subzone departure = Subzone.CreateNewSubzone("Subzone A", 10,
                testingZone);
            Subzone arrival = Subzone.CreateNewSubzone("Subzone B", 20,
                someOtherZone);
            testingUnitOfWork.Subzones.AddNewSubzone(arrival);
            testingUnitOfWork.SaveChanges();
            testingVehicle.RegisterNewMovementToSubzone(testingYardOperator,
                DateTime.Today, departure);
            return testingVehicle.RegisterNewMovementToSubzone(testingYardOperator,
                DateTime.Now, arrival);
        }

        private static Vehicle GetNewValidVehicleForMovement()
        {
            var portLocation = testingUnitOfWork.Locations.Elements.First(
                l => l.Type == LocationType.PORT);
            var yardLocation = testingUnitOfWork.Locations.Elements.First(
                l => l.Type == LocationType.YARD);
            var testingVehicle = Vehicle.CreateNewVehicle(VehicleType.CAR, "Ferrari",
                "Barchetta", 1985, "Red", "RUSH2112MVNGPICRS");
            testingVehicle.PortInspection = Inspection.CreateNewInspection(testingPortOperator,
                portLocation, DateTime.Today, new List<Damage>(), testingVehicle);
            testingVehicle.StagesData.CurrentStage = ProcessStages.YARD;
            testingVehicle.YardInspection = Inspection.CreateNewInspection(testingYardOperator,
                yardLocation, DateTime.Now, new List<Damage>(), testingVehicle);
            testingUnitOfWork.Vehicles.AddNewVehicle(testingVehicle);
            return testingVehicle;
        }

        private static void AddNewMovementAndSaveChanges(Movement movementToAdd)
        {
            testingMovementRepository.AddNewMovement(movementToAdd);
            testingUnitOfWork.SaveChanges();
        }
    }
}
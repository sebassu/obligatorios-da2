using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    public class ProcessDataTests
    {
        private static ProcessData testingData;
        private static readonly Lot lotToSet = Lot.InstanceForTestingPurposes();
        private static readonly Inspection portInspectionToSet = Inspection.InstanceForTestingPurposes();
        private static Inspection yardInspectionToSet;
        private static readonly User movementValidResponsible = User.InstanceForTestingPurposes();
        private static readonly Subzone firstDestination = Subzone.InstanceForTestingPurposes();
        private static Subzone secondDestination;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            var testImageList = new List<Damage> { Damage.InstanceForTestingPurposes() };
            Location alternativeLocation = Location.CreateNewLocation(LocationType.YARD, "Patio");
            yardInspectionToSet = Inspection.CreateNewInspection(User.InstanceForTestingPurposes(),
                alternativeLocation, DateTime.Today, testImageList, Vehicle.InstanceForTestingPurposes());
            secondDestination = Subzone.CreateNewSubzone("Another subzone", 100,
                Zone.InstanceForTestingPurposes());
        }

        [TestInitialize]
        public void TestSetup()
        {
            testingData = new ProcessData();
        }

        [TestMethod]
        public void ProcessDataRegisterPortLotValidTest()
        {
            Assert.AreEqual(ProcessStages.PORT, testingData.CurrentStage);
            testingData.RegisterPortLot(lotToSet);
            Assert.AreSame(lotToSet, testingData.PortLot);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataSetNullPortLotInvalidTest()
        {
            testingData.RegisterPortLot(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterPortLotOnTransportStageInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.TRANSPORT;
            testingData.RegisterPortLot(lotToSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterPortLotOnYardStageInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.YARD;
            testingData.RegisterPortLot(lotToSet);
        }

        [TestMethod]
        public void ProcessDataRegisterPortInspectionValidTest()
        {
            Assert.AreEqual(ProcessStages.PORT, testingData.CurrentStage);
            testingData.RegisterPortInspection(portInspectionToSet);
            Assert.AreSame(portInspectionToSet, testingData.PortInspection);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataSetNullPortInspectionInvalidTest()
        {
            testingData.RegisterPortInspection(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterPortInspectionInvalidPlaceTest()
        {
            testingData.RegisterPortInspection(yardInspectionToSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterPortInspectionOnTransportStageInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.TRANSPORT;
            testingData.RegisterPortInspection(portInspectionToSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterPortInspectionOnYardStageInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.YARD;
            testingData.RegisterPortInspection(portInspectionToSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterPortInspectionAlreadySetInvalidTest()
        {
            testingData.RegisterPortInspection(portInspectionToSet);
            testingData.RegisterPortInspection(portInspectionToSet);
        }

        [TestMethod]
        public void ProcessDataSetTransportStartDataValidTest()
        {
            User transporter = User.InstanceForTestingPurposes();
            testingData.SetTransportStartData(transporter);
            Assert.AreEqual(ProcessStages.TRANSPORT, testingData.CurrentStage);
            Assert.AreSame(transporter, testingData.Transporter);
            Assert.AreEqual(DateTime.Today, testingData.TransportStart.Date);
        }

        [TestMethod]
        public void ProcessDataSetTransportStartDataUnauthorizedTransporterValidTest()
        {
            User transporter = User.InstanceForTestingPurposes();
            transporter.Role = UserRoles.YARD_OPERATOR;
            testingData.SetTransportStartData(transporter);
            Assert.AreSame(transporter, testingData.Transporter);
        }

        [TestMethod]
        public void ProcessDataSetTransportStartDataNullTransporterValidTest()
        {
            testingData.SetTransportStartData(null);
            Assert.IsNull(testingData.Transporter);
        }

        [TestMethod]
        public void ProcessDataSetTransportEndDataValidTest()
        {
            testingData.SetTransportEndData();
            Assert.AreEqual(ProcessStages.YARD, testingData.CurrentStage);
            Assert.AreEqual(DateTime.Today, testingData.TransportEnd.Date);
        }

        [TestMethod]
        public void ProcessDataRegisterYardInspectionValidTest()
        {
            testingData.CurrentStage = ProcessStages.YARD;
            Assert.AreEqual(ProcessStages.YARD, testingData.CurrentStage);
            testingData.RegisterYardInspection(yardInspectionToSet);
            Assert.AreSame(yardInspectionToSet, testingData.YardInspection);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataSetNullYardInspectionInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.YARD;
            testingData.RegisterYardInspection(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterYardInspectionInvalidPlaceTest()
        {
            testingData.CurrentStage = ProcessStages.YARD;
            testingData.RegisterYardInspection(portInspectionToSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterYardInspectionOnPortStageInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.PORT;
            testingData.RegisterYardInspection(yardInspectionToSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterYardInspectionOnTransportStageInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.TRANSPORT;
            testingData.RegisterYardInspection(yardInspectionToSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterYardInspectionAlreadySetInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.YARD;
            testingData.RegisterYardInspection(yardInspectionToSet);
            testingData.RegisterYardInspection(yardInspectionToSet);
        }

        [TestMethod]
        public void ProcessDataRegisterInitialMovementToSubzoneValidTest()
        {
            var someDateTime = DateTime.Now;
            Assert.AreEqual(UserRoles.ADMINISTRATOR, movementValidResponsible.Role);
            testingData.CurrentStage = ProcessStages.YARD;
            var result = testingData.RegisterNewMovementToSubzone(movementValidResponsible,
               someDateTime, firstDestination);
            Assert.AreSame(movementValidResponsible, result.ResponsibleUser);
            Assert.AreEqual(someDateTime, result.DateTime);
            Assert.IsNull(result.Departure);
            Assert.AreSame(firstDestination, result.Arrival);
            Assert.AreSame(firstDestination, testingData.YardCurrentLocation);
            CollectionAssert.Contains(testingData.YardMovements.ToList(), result);
        }

        [TestMethod]
        public void ProcessDataRegisterSecondMovementToSubzoneValidTest()
        {
            testingData.CurrentStage = ProcessStages.YARD;
            var firstResult = testingData.RegisterNewMovementToSubzone(movementValidResponsible,
                DateTime.Today, firstDestination);
            var secondResult = testingData.RegisterNewMovementToSubzone(movementValidResponsible,
                DateTime.Now, secondDestination);
            Assert.AreSame(secondDestination, testingData.YardCurrentLocation);
            Assert.AreSame(firstResult.Arrival, secondResult.Departure);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterNewMovementToSubzoneDateBeforeOtherMovementsInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.YARD;
            testingData.RegisterNewMovementToSubzone(movementValidResponsible, DateTime.Now,
                firstDestination);
            testingData.RegisterNewMovementToSubzone(movementValidResponsible, new DateTime(1995, 10, 27),
                secondDestination);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterNewMovementToSubzoneOnPortStageInvalidTest()
        {
            Assert.AreEqual(ProcessStages.PORT, testingData.CurrentStage);
            testingData.RegisterNewMovementToSubzone(movementValidResponsible, DateTime.Now,
                firstDestination);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterNewMovementToSubzoneOnTransportStageInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.TRANSPORT;
            testingData.RegisterNewMovementToSubzone(movementValidResponsible, DateTime.Now,
                firstDestination);
        }
    }
}
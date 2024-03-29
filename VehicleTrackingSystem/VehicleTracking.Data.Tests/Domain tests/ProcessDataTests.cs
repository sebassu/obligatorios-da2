﻿using System;
using System.Linq;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ProcessDataTests
    {
        private static ProcessData testingData;
        private static readonly Lot lotToSet = Lot.InstanceForTestingPurposes();
        private static readonly Inspection portInspectionToSet = Inspection.InstanceForTestingPurposes();
        private static Inspection yardInspectionToSet;
        private static readonly User movementValidResponsible = User.InstanceForTestingPurposes();
        private static readonly Subzone firstDestination = Subzone.InstanceForTestingPurposes();
        private static Subzone secondDestination;
        private static readonly Transport testingTransport = Transport.InstanceForTestingPurposes();

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            var testImageList = new List<Damage> { Damage.InstanceForTestingPurposes() };
            Location alternativeLocation = Location.CreateNewLocation(LocationType.YARD, "Patio");
            yardInspectionToSet = Inspection.CreateNewInspection(User.InstanceForTestingPurposes(),
                alternativeLocation, DateTime.Today, testImageList, Vehicle.InstanceForTestingPurposes());
            secondDestination = Subzone.CreateNewSubzone("Another subzone", 100,
                Zone.InstanceForTestingPurposes());
            secondDestination.Id = 42;
        }

        [TestInitialize]
        public void TestSetup()
        {
            testingData = new ProcessData();
        }

        [TestMethod]
        public void ProcessDataSetIdValidTest()
        {
            testingData.Id = 42;
            Assert.AreEqual(42, testingData.Id);
        }

        [TestMethod]
        public void ProcessDataRegisterPortLotValidTest()
        {
            Assert.AreEqual(ProcessStages.PORT, testingData.CurrentStage);
            testingData.RegisterPortLot(lotToSet);
            Assert.AreSame(lotToSet, testingData.PortLot);
        }

        [TestMethod]
        public void ProcessDataSetNullPortLotValidTest()
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
            Assert.AreEqual(ProcessStages.PORT, testingData.CurrentStage);
            Lot testingLot = Lot.InstanceForTestingPurposes();
            Transport transportToSet = Transport.InstanceForTestingPurposes();
            transportToSet.LotsTransported.Add(testingLot);
            testingData.PortLot = testingLot;
            testingData.SetTransportStartData(transportToSet);
            Assert.AreEqual(ProcessStages.TRANSPORT, testingData.CurrentStage);
            Assert.AreSame(transportToSet, testingData.TransportData);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataSetNullTransportStartDataInvalidTest()
        {
            testingData.SetTransportStartData(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataSetTransportStartDataWithoutPortLotInvalidTest()
        {
            testingData.SetTransportStartData(testingTransport);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataSetTransportStartDataOnTransportStageInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.TRANSPORT;
            testingData.SetTransportStartData(testingTransport);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataSetTransportStartDataOnYardStageInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.TRANSPORT;
            testingData.SetTransportStartData(testingTransport);
        }

        [TestMethod]
        public void ProcessDataSetTransportEndDataValidTest()
        {
            var dateToSet = DateTime.Now;
            Transport fakeTransport = Transport.InstanceForTestingPurposes();
            fakeTransport.StartDateTime = DateTime.Today;
            fakeTransport.EndDateTime = dateToSet;
            testingData.TransportData = fakeTransport;
            testingData.CurrentStage = ProcessStages.TRANSPORT;
            testingData.SetTransportEndData();
            Assert.AreEqual(ProcessStages.YARD, testingData.CurrentStage);
            Assert.AreEqual(fakeTransport.EndDateTime, testingData.LastDateTimeToValidate);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataSetTransportEndDataOnPortStageInvalidTest()
        {
            Assert.AreEqual(ProcessStages.PORT, testingData.CurrentStage);
            testingData.SetTransportEndData();
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataSetTransportEndDataOnYardStageInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.YARD;
            testingData.SetTransportEndData();
        }

        [TestMethod]
        public void ProcessDataRegisterYardInspectionValidTest()
        {
            PromoteTestingDataToYardStage();
            Assert.AreEqual(ProcessStages.YARD, testingData.CurrentStage);
            testingData.RegisterYardInspection(yardInspectionToSet);
            Assert.AreEqual(yardInspectionToSet, testingData.YardInspection);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataSetNullYardInspectionInvalidTest()
        {
            PromoteTestingDataToYardStage();
            testingData.RegisterYardInspection(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterYardInspectionInvalidPlaceTest()
        {
            PromoteTestingDataToYardStage();
            testingData.RegisterYardInspection(portInspectionToSet);
        }

        private static void PromoteTestingDataToYardStage()
        {
            testingData.RegisterPortInspection(portInspectionToSet);
            testingData.CurrentStage = ProcessStages.YARD;
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
            var dateTimeToSet = DateTime.Now;
            Assert.AreEqual(UserRoles.ADMINISTRATOR, movementValidResponsible.Role);
            testingData.RegisterPortInspection(portInspectionToSet);
            testingData.CurrentStage = ProcessStages.YARD;
            testingData.RegisterYardInspection(yardInspectionToSet);
            var result = testingData.RegisterNewMovementToSubzone(movementValidResponsible,
               dateTimeToSet, firstDestination);
            Assert.AreSame(movementValidResponsible, result.Responsible);
            Assert.AreEqual(dateTimeToSet, result.DateTime);
            Assert.IsNull(result.Departure);
            Assert.AreSame(firstDestination, result.Arrival);
            Assert.AreSame(firstDestination, testingData.YardCurrentLocation);
            Assert.AreEqual(dateTimeToSet, testingData.LastDateTimeToValidate);
            CollectionAssert.Contains(testingData.YardMovements.ToList(), result);
        }

        [TestMethod]
        public void ProcessDataRegisterSecondMovementToSubzoneValidTest()
        {
            var dateTimeToSet = DateTime.Now;
            testingData.RegisterPortInspection(portInspectionToSet);
            testingData.CurrentStage = ProcessStages.YARD;
            testingData.RegisterYardInspection(yardInspectionToSet);
            var firstResult = testingData.RegisterNewMovementToSubzone(movementValidResponsible,
                DateTime.Today, firstDestination);
            var secondResult = testingData.RegisterNewMovementToSubzone(movementValidResponsible,
                dateTimeToSet, secondDestination);
            Assert.AreSame(secondDestination, testingData.YardCurrentLocation);
            Assert.AreSame(firstResult.Arrival, secondResult.Departure);
            Assert.AreEqual(dateTimeToSet, testingData.LastDateTimeToValidate);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterNewMovementToSubzoneDateBeforeOtherMovementsInvalidTest()
        {
            PromoteTestingDataToYardStage();
            testingData.RegisterYardInspection(yardInspectionToSet);
            testingData.RegisterNewMovementToSubzone(movementValidResponsible,
                DateTime.Now, firstDestination);
            testingData.RegisterNewMovementToSubzone(movementValidResponsible,
                new DateTime(1995, 10, 27), secondDestination);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterNewMovementToSubzoneWithoutYardInspectionInvalidTest()
        {
            PromoteTestingDataToYardStage();
            testingData.RegisterNewMovementToSubzone(movementValidResponsible,
                DateTime.Now, Subzone.InstanceForTestingPurposes());
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

        [TestMethod]
        public void ProcessDataSetYardMovementsValidTest()
        {
            var movementsToSet = new List<Movement>();
            testingData.YardMovements = movementsToSet;
            Assert.AreSame(movementsToSet, testingData.YardMovements);
        }

        [TestMethod]
        public void ProcessDataIsReadyForTransportPastPortStageValidTest()
        {
            testingData.CurrentStage = ProcessStages.YARD;
            Assert.IsFalse(testingData.IsReadyForTransport());
        }

        [TestMethod]
        public void ProcessDataSetInspectionsSingleValidTest()
        {
            var inspectionCollectionToSet = new List<Inspection>() {
                Inspection.InstanceForTestingPurposes() };
            testingData.Inspections = inspectionCollectionToSet;
            CollectionAssert.AreEqual(inspectionCollectionToSet,
                testingData.Inspections.ToList());
        }

        [TestMethod]
        public void ProcessDataSetMultipleInspectionsValidTest()
        {
            var someInspection = Inspection.InstanceForTestingPurposes();
            var someLaterInspection = Inspection.InstanceForTestingPurposes();
            someLaterInspection.DateTime = DateTime.Now;
            var inspectionCollectionToSet = new List<Inspection>() {
                someInspection, someLaterInspection };
            testingData.Inspections = inspectionCollectionToSet;
            var expectedSortedInspectionCollection =
                inspectionCollectionToSet.OrderBy(i => i.DateTime).ToList();
            CollectionAssert.AreEqual(expectedSortedInspectionCollection,
                testingData.Inspections.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataSetNullInspectionsInvalidTest()
        {
            testingData.Inspections = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterVehicleSaleWhenAlreadySetInvalidTest()
        {
            testingData.SaleRecord = Sale.InstanceForTestingPurposes();
            testingData.RegisterVehicleSale(Sale.InstanceForTestingPurposes());
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterNullVehicleSaleInvalidTest()
        {
            testingData.RegisterVehicleSale(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterVehicleSaleOnInvalidStagePortTest()
        {
            testingData.CurrentStage = ProcessStages.PORT;
            testingData.RegisterVehicleSale(Sale.InstanceForTestingPurposes());
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterVehicleSaleOnInvalidStageTransportTest()
        {
            testingData.CurrentStage = ProcessStages.TRANSPORT;
            testingData.RegisterVehicleSale(Sale.InstanceForTestingPurposes());
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterVehicleSaleOnInvalidStageYardTest()
        {
            testingData.CurrentStage = ProcessStages.YARD;
            testingData.RegisterVehicleSale(Sale.InstanceForTestingPurposes());
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterVehicleSaleOnInvalidStageStuckInProcessTest()
        {
            testingData.CurrentStage = ProcessStages.STUCK_IN_PROCESS;
            testingData.RegisterVehicleSale(Sale.InstanceForTestingPurposes());
        }
    }
}
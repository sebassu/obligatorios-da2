using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    public class ProcessDataTests
    {
        private static ProcessData testingData;
        private static readonly Lot lotToSet = Lot.InstanceForTestingPurposes();
        private static readonly Inspection inspectionToSet = Inspection.InstanceForTestingPurposes();

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
            Assert.AreEqual(lotToSet, testingData.PortLot);
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
            testingData.RegisterPortInspection(inspectionToSet);
            Assert.AreEqual(inspectionToSet, testingData.PortInspection);
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
            var testImageList = new List<Damage> { Damage.InstanceForTestingPurposes() };
            Location alternativeLocation = Location.CreateNewLocation(LocationType.YARD, "Patio");
            var invalidYardInspectionToSet = Inspection.CreateNewInspection(User.InstanceForTestingPurposes(),
                alternativeLocation, DateTime.Today, testImageList, Vehicle.InstanceForTestingPurposes());
            testingData.RegisterPortInspection(invalidYardInspectionToSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterPortInspectionOnTransportStageInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.TRANSPORT;
            testingData.RegisterPortInspection(inspectionToSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterPortInspectionOnYardStageInvalidTest()
        {
            testingData.CurrentStage = ProcessStages.YARD;
            testingData.RegisterPortInspection(inspectionToSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterPortInspectionAlreadySetInvalidTest()
        {
            testingData.RegisterPortInspection(inspectionToSet);
            testingData.RegisterPortInspection(inspectionToSet);
        }
    }
}
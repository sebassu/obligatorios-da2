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
        private static readonly Inspection portInspectionToSet =
            Inspection.InstanceForTestingPurposes();
        private static Inspection yardInspectionToSet;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            var testImageList = new List<Damage> { Damage.InstanceForTestingPurposes() };
            Location alternativeLocation = Location.CreateNewLocation(LocationType.YARD, "Patio");
            yardInspectionToSet = Inspection.CreateNewInspection(User.InstanceForTestingPurposes(),
                alternativeLocation, DateTime.Today, testImageList, Vehicle.InstanceForTestingPurposes());
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
            testingData.RegisterPortInspection(portInspectionToSet);
            Assert.AreEqual(portInspectionToSet, testingData.PortInspection);
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
            Assert.AreEqual(transporter, testingData.Transporter);
            Assert.AreEqual(DateTime.Today, testingData.TransportStart.Date);
        }

        [TestMethod]
        public void ProcessDataSetTransportStartDataUnauthorizedTransporterValidTest()
        {
            User transporter = User.InstanceForTestingPurposes();
            transporter.Role = UserRoles.YARD_OPERATOR;
            testingData.SetTransportStartData(transporter);
            Assert.AreEqual(transporter, testingData.Transporter);
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
            Assert.AreEqual(yardInspectionToSet, testingData.YardInspection);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataSetNullYardInspectionInvalidTest()
        {
            testingData.RegisterYardInspection(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ProcessException))]
        public void ProcessDataRegisterYardInspectionInvalidPlaceTest()
        {
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
            testingData.RegisterYardInspection(yardInspectionToSet);
            testingData.RegisterYardInspection(yardInspectionToSet);
        }
    }
}
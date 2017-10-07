using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TransportTests
    {
        private static Transport testingTransport;
        private static readonly User testingUser = User.InstanceForTestingPurposes();
        private static Lot lot1;
        private static Lot lot2;
        private static Lot lot3;
        private static Vehicle vehicleInLot3;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            InitializeFirstTestingLot();
            InitializeSecondTestingLot();
            InitializeThirdTestingLot();
        }

        private static void InitializeFirstTestingLot()
        {
            var lot1Vehicle1PortInspection = Inspection.InstanceForTestingPurposes();
            lot1Vehicle1PortInspection.DateTime = new DateTime(2008, 9, 9);
            var lot1Vehicle2PortInspection = Inspection.InstanceForTestingPurposes();
            lot1Vehicle2PortInspection.DateTime = new DateTime(2011, 10, 11);
            var lot1Vehicle1 = Vehicle.InstanceForTestingPurposes();
            var lot1Vehicle2 = Vehicle.InstanceForTestingPurposes();
            lot1Vehicle1.CurrentState.PortInspection = lot1Vehicle1PortInspection;
            lot1Vehicle2.CurrentState.PortInspection = lot1Vehicle2PortInspection;
            lot1 = Lot.InstanceForTestingPurposes();
            lot1.Vehicles = new List<Vehicle> { lot1Vehicle1, lot1Vehicle2 };
        }

        private static void InitializeSecondTestingLot()
        {
            var vehicleInspection = Inspection.InstanceForTestingPurposes();
            vehicleInspection.DateTime = new DateTime(2013, 9, 9);
            var testingVehicle = Vehicle.InstanceForTestingPurposes();
            testingVehicle.CurrentState.PortInspection = vehicleInspection;
            lot2 = Lot.InstanceForTestingPurposes();
            lot2.Id = 42;
            lot2.Vehicles = new List<Vehicle> { testingVehicle };
        }

        private static void InitializeThirdTestingLot()
        {
            var vehicleInspection = Inspection.InstanceForTestingPurposes();
            vehicleInspection.DateTime = new DateTime(2011, 9, 9);
            vehicleInLot3 = Vehicle.InstanceForTestingPurposes();
            vehicleInLot3.CurrentState.PortInspection = vehicleInspection;
            lot3 = Lot.InstanceForTestingPurposes();
            lot3.Vehicles = new List<Vehicle> { vehicleInLot3 };
        }

        [TestInitialize]
        public void TestSetup()
        {
            testingTransport = Transport.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void TransportSetIdValidTest()
        {
            testingTransport.Id = 42;
            Assert.AreEqual(42, testingTransport.Id);
        }

        [TestMethod]
        public void TransportInstanceForTestingPurposesTest()
        {
            Assert.AreEqual(0, testingTransport.Id);
            Assert.AreEqual(User.InstanceForTestingPurposes(),
                testingTransport.Transporter);
            Assert.IsNotNull(testingTransport.LotsTransported);
            Assert.AreEqual(0, testingTransport.LotsTransported.Count);
        }

        [TestMethod]
        public void TransportSetLotsTransportedValidTest()
        {
            var lotsToSet = new List<Lot>();
            testingTransport.LotsTransported = lotsToSet;
            Assert.AreSame(lotsToSet, testingTransport.LotsTransported);
        }

        [TestMethod]
        public void TransportSetNullLotsTransportedValidTest()
        {
            testingTransport.LotsTransported = null;
            Assert.IsNull(testingTransport.LotsTransported);
        }

        [TestMethod]
        public void TransportSetAdministratorTransporterValidTest()
        {
            Assert.AreEqual(UserRoles.ADMINISTRATOR, testingUser.Role);
            testingTransport.Transporter = testingUser;
            Assert.AreSame(testingUser, testingTransport.Transporter);
        }

        [TestMethod]
        public void TransportSetTranporterTransporterValidTest()
        {
            var transporterToSet = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo",
                "Lamponne", "pLamponne", "NoHaceFaltaSaleSolo", "099212121");
            testingTransport.Transporter = transporterToSet;
            Assert.AreSame(transporterToSet, testingTransport.Transporter);
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetPortOperatorTransporterInvalidTest()
        {
            var transporterToSet = User.CreateNewUser(UserRoles.PORT_OPERATOR, "Emilio",
                "Ravenna", "eRavenna", "HablarUnasPalabritas", "099699669");
            testingTransport.Transporter = transporterToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetYardOperatorTransporterInvalidTest()
        {
            var transporterToSet = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Emilio",
                "Ravenna", "eRavenna", "HablarUnasPalabritas", "099699669");
            testingTransport.Transporter = transporterToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetNullTransporterInvalidTest()
        {
            testingTransport.Transporter = null;
        }

        [TestMethod]
        public void TransportSetTransportStartDateTimeValidTest()
        {
            var dateTimeToSet = DateTime.Now;
            testingTransport.StartDateTime = dateTimeToSet;
            Assert.AreEqual(dateTimeToSet, testingTransport.StartDateTime);
        }

        [TestMethod]
        public void TransportSetTransportStartDateTimeOneLotValidTest()
        {
            var dateTimeToSet = DateTime.Now;
            testingTransport.LotsTransported = new List<Lot> { lot1 };
            testingTransport.StartDateTime = dateTimeToSet;
            Assert.AreEqual(dateTimeToSet, testingTransport.StartDateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetTransportStartDateTimeOneLotInvalidTest()
        {
            var dateTimeToSet = new DateTime(2010, 2, 6);
            testingTransport.LotsTransported = new List<Lot> { lot1 };
            testingTransport.StartDateTime = dateTimeToSet;
        }

        [TestMethod]
        public void TransportSetTransportStartDateTimeMultipleLotsValidTest()
        {
            var dateTimeToSet = DateTime.Now;
            testingTransport.LotsTransported = new List<Lot> { lot1, lot2 };
            testingTransport.StartDateTime = dateTimeToSet;
            Assert.AreEqual(dateTimeToSet, testingTransport.StartDateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetTransportStartDateTimeMultipleLotsInvalidForBothTest()
        {
            var dateTimeToSet = new DateTime(1912, 2, 6);
            testingTransport.LotsTransported = new List<Lot> { lot1, lot2 };
            testingTransport.StartDateTime = dateTimeToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetTransportStartDateTimeMultipleLotsInvalidForOneTest()
        {
            var dateTimeToSet = new DateTime(2012, 2, 6);
            testingTransport.LotsTransported = new List<Lot> { lot1, lot2 };
            testingTransport.StartDateTime = dateTimeToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetNullTransportStartDateTimeInvalidTest()
        {
            testingTransport.StartDateTime = null;
        }

        [TestMethod]
        public void TransportSetTransportEndDateTimeValidTest()
        {
            var dateTimeToSet = new DateTime(2012, 2, 1);
            testingTransport.StartDateTime = new DateTime(1999, 2, 1);
            testingTransport.EndDateTime = dateTimeToSet;
            Assert.AreEqual(dateTimeToSet, testingTransport.EndDateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetTransportEndDateTimeBeforeStartInvalidTest()
        {
            var dateTimeToSet = new DateTime(1990, 2, 1);
            testingTransport.StartDateTime = new DateTime(1999, 2, 1);
            testingTransport.EndDateTime = dateTimeToSet;
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetTransportEndDateTimeUnsetStartInvalidTest()
        {
            testingTransport.EndDateTime = new DateTime(1999, 2, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetNullTransportEndDateTimeInvalidTest()
        {
            testingTransport.StartDateTime = new DateTime(1990, 2, 1);
            testingTransport.EndDateTime = null;
        }

        [TestMethod]
        public void TransportParameterFactoryMethodValidTest()
        {
            var dateTimeToSet = DateTime.Now;
            var lotsToSet = new List<Lot> { lot1, lot2 };
            var createdTransport = Transport.FromTransporterDateTimeLots(testingUser,
                dateTimeToSet, lotsToSet);
            Assert.AreSame(testingUser, createdTransport.Transporter);
            Assert.AreEqual(dateTimeToSet, createdTransport.StartDateTime);
            CollectionAssert.AreEqual(lotsToSet,
                createdTransport.LotsTransported.ToList());
            Assert.IsNull(createdTransport.EndDateTime);
            Assert.IsTrue(lot1.WasTransported);
            Assert.IsTrue(lot2.WasTransported);
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportParameterFactoryMethodInvalidUserTest()
        {
            var transporterToSet = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Emilio",
                "Ravenna", "eRavenna", "HablarUnasPalabritas", "099699669"); ;
            Transport.FromTransporterDateTimeLots(transporterToSet,
                DateTime.Now, new List<Lot> { lot1, lot2 });
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportParameterFactoryMethodNullUserInvalidTest()
        {
            Transport.FromTransporterDateTimeLots(null,
                DateTime.Now, new List<Lot> { lot1, lot2 });
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportParameterFactoryMethodInvalidDateTimeTest()
        {
            Transport.FromTransporterDateTimeLots(testingUser,
                new DateTime(1975, 1, 1), new List<Lot> { lot1, lot2 });
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportParameterFactoryMethodEmptyLotCollectionInvalidTest()
        {
            var createdTransport = Transport.FromTransporterDateTimeLots(testingUser,
               DateTime.Now, new List<Lot>());
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportParameterFactoryMethodNullLotCollectionInvalidTest()
        {
            var createdTransport = Transport.FromTransporterDateTimeLots(testingUser,
               DateTime.Now, null);
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportParameterFactoryMethodLotCollectionWithDuplicatesInvalidTest()
        {
            var createdTransport = Transport.FromTransporterDateTimeLots(testingUser,
               DateTime.Now, new List<Lot> { lot1, lot1 });
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportParameterFactoryMethodLotCollectionWithTransportedLotsInvalidTest()
        {
            Lot testingLot = Lot.InstanceForTestingPurposes();
            testingLot.WasTransported = true;
            var createdTransport = Transport.FromTransporterDateTimeLots(testingUser,
               DateTime.Now, new List<Lot> { testingLot });
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportParameterFactoryMethodLotCollectionWithNonInspectedVehiclesInvalidTest()
        {
            Lot testingLot = Lot.InstanceForTestingPurposes();
            testingLot.Vehicles = new List<Vehicle> { Vehicle.InstanceForTestingPurposes() };
            var createdTransport = Transport.FromTransporterDateTimeLots(testingUser,
               DateTime.Now, new List<Lot> { testingLot });
        }

        [TestMethod]
        public void TransportFinishTransportValidTest()
        {
            var endDateTimeToSet = DateTime.Now;
            var lotsToSet = new List<Lot> { lot3 };
            var createdTransport = Transport.FromTransporterDateTimeLots(testingUser,
                new DateTime(2015, 3, 3), lotsToSet);
            createdTransport.FinalizeTransportOnDate(endDateTimeToSet);
            Assert.AreSame(createdTransport, vehicleInLot3.CurrentState.TransportData);
            Assert.AreEqual(endDateTimeToSet, createdTransport.EndDateTime);
            Assert.AreEqual(ProcessStages.YARD, vehicleInLot3.CurrentStage);
        }
    }
}
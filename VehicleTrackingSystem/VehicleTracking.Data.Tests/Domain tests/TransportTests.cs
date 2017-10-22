using Domain;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TransportTests
    {
        private static Transport testingTransport;
        private static readonly User testingUser =
            User.InstanceForTestingPurposes();
        private static Lot testingLot1;
        private static Lot testingLot2;
        private static Lot testingLot3;
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
            lot1Vehicle1.PortInspection = lot1Vehicle1PortInspection;
            lot1Vehicle2.PortInspection = lot1Vehicle2PortInspection;
            testingLot1 = Lot.InstanceForTestingPurposes();
            testingLot1.Vehicles = new List<Vehicle> { lot1Vehicle1, lot1Vehicle2 };
        }

        private static void InitializeSecondTestingLot()
        {
            var vehicleInspection = Inspection.InstanceForTestingPurposes();
            vehicleInspection.DateTime = new DateTime(2013, 9, 9);
            var testingVehicle = Vehicle.InstanceForTestingPurposes();
            testingVehicle.PortInspection = vehicleInspection;
            testingLot2 = Lot.InstanceForTestingPurposes();
            testingLot2.Id = Guid.NewGuid();
            testingLot2.Vehicles = new List<Vehicle> { testingVehicle };
        }

        private static void InitializeThirdTestingLot()
        {
            var vehicleInspection = Inspection.InstanceForTestingPurposes();
            vehicleInspection.DateTime = new DateTime(2011, 9, 9);
            vehicleInLot3 = Vehicle.InstanceForTestingPurposes();
            vehicleInLot3.PortInspection = vehicleInspection;
            testingLot3 = Lot.InstanceForTestingPurposes();
            testingLot3.Vehicles = new List<Vehicle> { vehicleInLot3 };
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
            testingTransport.LotsTransported = new List<Lot> { testingLot1 };
            testingTransport.StartDateTime = dateTimeToSet;
            Assert.AreEqual(dateTimeToSet, testingTransport.StartDateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetTransportStartDateTimeOneLotInvalidTest()
        {
            testingTransport.LotsTransported = new List<Lot> { testingLot1 };
            testingTransport.StartDateTime = new DateTime(2010, 2, 6);
        }

        [TestMethod]
        public void TransportSetTransportStartDateTimeMultipleLotsValidTest()
        {
            var dateTimeToSet = DateTime.Now;
            testingTransport.LotsTransported = new List<Lot> { testingLot1, testingLot2 };
            testingTransport.StartDateTime = dateTimeToSet;
            Assert.AreEqual(dateTimeToSet, testingTransport.StartDateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetTransportStartDateTimeMultipleLotsInvalidForBothTest()
        {
            testingTransport.LotsTransported = new List<Lot> { testingLot1, testingLot2 };
            testingTransport.StartDateTime = new DateTime(1912, 2, 6);
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetTransportStartDateTimeMultipleLotsInvalidForOneTest()
        {
            testingTransport.LotsTransported = new List<Lot> { testingLot1, testingLot2 };
            testingTransport.StartDateTime = new DateTime(2012, 2, 6);
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
            testingTransport.StartDateTime = new DateTime(1999, 2, 1);
            testingTransport.EndDateTime = new DateTime(1990, 2, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetInvalidTransportEndDateTimeTest()
        {
            testingTransport.StartDateTime = new DateTime(1999, 2, 1);
            testingTransport.EndDateTime = new DateTime(1812, 12, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportSetTransportEndDateTimeUnsetStartInvalidTest()
        {
            testingTransport.EndDateTime = new DateTime(1999, 2, 1);
        }

        [TestMethod]
        public void TransportSetNullTransportEndDateTimeValidTest()
        {
            testingTransport.EndDateTime = null;
            Assert.IsNull(testingTransport.EndDateTime);
        }

        [TestMethod]
        public void TransportParameterFactoryMethodValidTest()
        {
            var dateTimeToSet = DateTime.Now;
            var lotsToSet = new List<Lot> { testingLot1, testingLot2 };
            var createdTransport = Transport.FromTransporterDateTimeLots(testingUser,
                dateTimeToSet, lotsToSet);
            Assert.AreSame(testingUser, createdTransport.Transporter);
            Assert.AreEqual(dateTimeToSet, createdTransport.StartDateTime);
            CollectionAssert.AreEqual(lotsToSet,
                createdTransport.LotsTransported.ToList());
            Assert.IsNull(createdTransport.EndDateTime);
            Assert.IsTrue(testingLot1.WasTransported);
            Assert.IsTrue(testingLot2.WasTransported);
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportParameterFactoryMethodInvalidUserTest()
        {
            var transporterToSet = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Emilio",
                "Ravenna", "eRavenna", "HablarUnasPalabritas", "099699669"); ;
            Transport.FromTransporterDateTimeLots(transporterToSet,
                DateTime.Now, new List<Lot> { testingLot1, testingLot2 });
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportParameterFactoryMethodNullUserInvalidTest()
        {
            Transport.FromTransporterDateTimeLots(null,
                DateTime.Now, new List<Lot> { testingLot1, testingLot2 });
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportParameterFactoryMethodInvalidDateTimeTest()
        {
            Transport.FromTransporterDateTimeLots(testingUser,
                new DateTime(1975, 1, 1), new List<Lot> { testingLot1, testingLot2 });
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
               DateTime.Now, new List<Lot> { testingLot1, testingLot1 });
        }

        [TestMethod]
        [ExpectedException(typeof(TransportException))]
        public void TransportParameterFactoryMethodLotCollectionWithTransportedLotsInvalidTest()
        {
            Lot testingLot = Lot.InstanceForTestingPurposes();
            testingLot.AssociatedTransport = Transport.InstanceForTestingPurposes();
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
            var lotsToSet = new List<Lot> { testingLot3 };
            var createdTransport = Transport.FromTransporterDateTimeLots(testingUser,
                new DateTime(2015, 3, 3), lotsToSet);
            createdTransport.FinalizeTransportOnDate(endDateTimeToSet);
            Assert.AreSame(createdTransport, vehicleInLot3.StagesData.TransportData);
            Assert.AreEqual(endDateTimeToSet, createdTransport.EndDateTime);
            Assert.AreEqual(ProcessStages.YARD, vehicleInLot3.CurrentStage);
        }
    }
}
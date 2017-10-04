﻿using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    public class TransportTests
    {
        private static Transport testingTransport;
        private static readonly User testingUser = User.InstanceForTestingPurposes();
        private static Lot lot1;
        private static Lot lot2;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            InitializeFirstTestingLot();
            InitializeSecondTestingLot();
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
            var lot2Vehicle1PortInspection = Inspection.InstanceForTestingPurposes();
            lot2Vehicle1PortInspection.DateTime = new DateTime(2013, 9, 9);
            var lot2Vehicle1 = Vehicle.InstanceForTestingPurposes();
            lot2Vehicle1.CurrentState.PortInspection = lot2Vehicle1PortInspection;
            lot2 = Lot.InstanceForTestingPurposes();
            lot2.Vehicles = new List<Vehicle> { lot2Vehicle1 };
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
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class InspectionTests
    {
        private static Inspection testingInspection;
        private static List<string> testImageList;
        private static List<Damage> damageList;
        private static Damage testingDamage;

        [TestInitialize]
        public void TestSetup()
        {
            testingInspection = Inspection.InstanceForTestingPurposes();
            testImageList = new List<string> { "image1" };
            testingDamage = Damage.InstanceForTestingPurposes();
            damageList = new List<Damage> { testingDamage };
        }

        [TestMethod]
        public void InspectionInstanceForTestingPurposesTest()
        {
            Assert.IsNotNull(testingInspection.Id);
            Assert.AreEqual(Location.InstanceForTestingPurposes(), testingInspection.Location);
            Assert.AreEqual(User.InstanceForTestingPurposes(), testingInspection.Responsible);
            Assert.IsNotNull(testingInspection.Damages);
            Assert.AreEqual(0, testingInspection.Damages.Count);
        }

        [TestMethod]
        public void InspectionSetIdValidTest()
        {
            var idToSet = Guid.NewGuid();
            testingInspection.Id = idToSet;
            Assert.AreEqual(idToSet, testingInspection.Id);
        }

        [TestMethod]
        public void InspectionSetValidDateTimeTest()
        {
            testingInspection.DateTime = DateTime.Today;
            Assert.AreEqual(DateTime.Today, testingInspection.DateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidFutureDateTest()
        {
            testingInspection.DateTime = new DateTime(2019, 9, 24, 10, 9, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidFarPastDateTimeTest()
        {
            testingInspection.DateTime = new DateTime(1856, 8, 30, 12, 8, 9);
        }

        [TestMethod]
        public void InspectionSetValidResponsibleTest()
        {
            User alternativeUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Juan", "Perez",
                "miUsuario", "pass", "097364857");
            testingInspection.Responsible = alternativeUser;
            Assert.AreEqual(alternativeUser, testingInspection.Responsible);
        }

        [TestMethod]
        public void InspectionSetNullResponsibleValidTest()
        {
            testingInspection.Responsible = null;
        }

        [TestMethod]
        public void InspectionSetTransporterResponsibleValidTest()
        {
            User alternativeUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Juan", "Perez",
                "miUsuario", "pass", "26061199");
            testingInspection.Responsible = alternativeUser;
        }

        [TestMethod]
        public void InspectionSetLocationValidTest()
        {
            Location alternativeLocation = Location.CreateNewLocation(LocationType.PORT,
                "Puerto de Punta del Este");
            testingInspection.Location = alternativeLocation;
            Assert.AreEqual(alternativeLocation, testingInspection.Location);
        }

        [TestMethod]
        public void InspectionSetNullLocationValidTest()
        {
            testingInspection.Location = null;
        }

        [TestMethod]
        public void InspectionSetValidDamagesListTest()
        {
            testingInspection.Damages = damageList;
            Assert.AreSame(damageList, testingInspection.Damages);
        }

        [TestMethod]
        public void InspectionSetInvalidDamagesEmptyListValidTest()
        {
            var emptyListToSet = new List<Damage>();
            testingInspection.Damages = emptyListToSet;
            Assert.AreSame(emptyListToSet, testingInspection.Damages);
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidDamagesNullTest()
        {
            testingInspection.Damages = null;
        }

        [TestMethod]
        public void InspectionSetValidVehicleVINTest()
        {
            testingInspection.VehicleVIN = "QAZWSXEDCRFV12345";
            Assert.AreEqual("QAZWSXEDCRFV12345", testingInspection.VehicleVIN);
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidVehicleVINTooShortTest()
        {
            testingInspection.VehicleVIN = "QWERT12345";
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidVehicleVINTooLongTest()
        {
            testingInspection.VehicleVIN = "QWERTY1234567890QWERTY";
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidVehicleVINPunctuationTest()
        {
            testingInspection.VehicleVIN = "1212^@% --- (((*//&#^%&^";
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidVehicleVINSpacesTest()
        {
            testingInspection.VehicleVIN = "  \n\n\t    \t \t \n";
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidVehicleVINEmptyTest()
        {
            testingInspection.VehicleVIN = "";
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetNullVehicleVINInvalidTest()
        {
            testingInspection.VehicleVIN = null;
        }

        [TestMethod]
        public void InspectionSetValidStageIdTest()
        {
            User alternativeUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Juan", "Perez", "miUsuario", "pass",
                "097364857");
            testingInspection.Responsible = alternativeUser;
            Assert.AreEqual(alternativeUser, testingInspection.Responsible);
        }

        [TestMethod]
        public void InspectionParameterFactoryMethodValidTest()
        {
            Location alternativeLocation = Location.CreateNewLocation(LocationType.PORT, "Puerto de Punta del Este");
            User alternativeUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Juan", "Perez", "miUsuario", "pass",
               "097364857");
            DateTime alternativeDateTime = DateTime.Today;
            testingInspection = Inspection.CreateNewInspection(alternativeUser, alternativeLocation,
                alternativeDateTime, damageList, Vehicle.InstanceForTestingPurposes());
            Assert.AreSame(alternativeUser, testingInspection.Responsible);
            Assert.AreSame(alternativeLocation, testingInspection.Location);
            Assert.AreEqual(alternativeDateTime, testingInspection.DateTime);
            CollectionAssert.AreEqual(damageList, testingInspection.Damages.ToList());
            Assert.AreSame(Vehicle.InstanceForTestingPurposes().VIN, testingInspection.VehicleVIN);
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionParameterFactoryMethodInvalidResponsibleTest()
        {
            Location alternativeLocation = Location.CreateNewLocation(LocationType.PORT, "Puerto de Punta del Este");
            DateTime alternativeDateTime = DateTime.Today;
            testingInspection = Inspection.CreateNewInspection(null, alternativeLocation,
                alternativeDateTime, damageList, Vehicle.InstanceForTestingPurposes());
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionParameterFactoryMethodInvalidLocationTest()
        {
            User alternativeUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Juan", "Perez", "miUsuario", "pass",
               "097364857");
            DateTime alternativeDateTime = DateTime.Today;
            testingInspection = Inspection.CreateNewInspection(alternativeUser, null,
                alternativeDateTime, damageList, Vehicle.InstanceForTestingPurposes());
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionParameterFactoryMethodInvalidDateTimeTest()
        {
            Location alternativeLocation = Location.CreateNewLocation(LocationType.PORT, "Puerto de Punta del Este");
            User alternativeUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Juan", "Perez", "miUsuario", "pass",
               "097364857");
            DateTime alternativeDateTime = new DateTime(1856, 8, 30, 12, 8, 9);
            testingInspection = Inspection.CreateNewInspection(alternativeUser, alternativeLocation,
                alternativeDateTime, damageList, Vehicle.InstanceForTestingPurposes());
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionParameterFactoryMethodInvalidDamagesTest()
        {
            Location alternativeLocation = Location.CreateNewLocation(LocationType.PORT, "Puerto de Punta del Este");
            User alternativeUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Juan", "Perez", "miUsuario", "pass",
               "097364857");
            DateTime alternativeDateTime = DateTime.Today;
            testingInspection = Inspection.CreateNewInspection(alternativeUser, alternativeLocation,
                alternativeDateTime, null, Vehicle.InstanceForTestingPurposes());
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionParameterFactoryMethodUserRoleLocationTypeInvalidTest()
        {
            Location alternativeLocation = Location.CreateNewLocation(LocationType.PORT, "Puerto de Punta del Este");
            User alternativeUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Juan", "Perez", "miUsuario", "pass",
               "097364857");
            DateTime alternativeDateTime = DateTime.Today;
            testingInspection = Inspection.CreateNewInspection(alternativeUser, alternativeLocation,
                alternativeDateTime, damageList, Vehicle.InstanceForTestingPurposes());
        }

        [TestMethod]
        public void InspectionEqualsNullTest()
        {
            Assert.AreNotEqual(testingInspection, null);
        }

        [TestMethod]
        public void InspectionEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingInspection, someRandomObject);
        }

        [TestMethod]
        public void InspectionEqualsReflexiveTest()
        {
            Assert.AreEqual(testingInspection, testingInspection);
        }

        [TestMethod]
        public void InspectionEqualsSymmetricTest()
        {
            Inspection secondTestingInspection = Inspection.InstanceForTestingPurposes();
            secondTestingInspection.Id = testingInspection.Id;
            Assert.AreEqual(testingInspection, secondTestingInspection);
            Assert.AreEqual(secondTestingInspection, testingInspection);
        }

        [TestMethod]
        public void UserGetHashCodeTest()
        {
            object testingInspectionAsObject = testingInspection;
            Assert.AreEqual(testingInspection.GetHashCode(), testingInspection.GetHashCode());
        }
    }
}

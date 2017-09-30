using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System.Linq;

namespace Data.Tests.Domain_tests
{
    [TestClass]
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
        public void InspectionForTestingPurposesTest()
        {
            Assert.AreEqual(0, testingInspection.Id);
            Assert.AreEqual(new DateTime(2017, 9, 22, 10, 8, 0), testingInspection.DateTime);
            Assert.AreEqual(User.CreateNewUser(UserRoles.ADMINISTRATOR, "Maria", "Gonzalez", "mgon", "password", "26010376"),
                testingInspection.ResponsibleUser);
            Assert.AreEqual(Location.CreateNewLocation(LocationType.PORT, "Puerto de Montevideo"), testingInspection.Location);
            Assert.IsTrue(damageList.SequenceEqual(testingInspection.Damages));
            Assert.AreEqual("QWERTYUI123456789", testingInspection.VehicleVIN);
        }

        [TestMethod]
        public void InspectionSetValidDateTimeTest()
        {
            testingInspection.DateTime = DateTime.Today;
            Assert.AreEqual(DateTime.Today, testingInspection.DateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidDatePassTodayTest()
        {
            testingInspection.DateTime = new DateTime(2019, 9, 24, 10, 9, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidDateTimeOldTest()
        {
            testingInspection.DateTime = new DateTime(1856, 8, 30, 12, 8, 9);
        }

        [TestMethod]
        public void InspectionSetValidResponsibleUserTest()
        {
            User alternativeUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Juan", "Perez", "miUsuario", "pass",
                "097364857");
            testingInspection.ResponsibleUser = alternativeUser;
            Assert.AreEqual(alternativeUser, testingInspection.ResponsibleUser);
        }

        [ExpectedException(typeof(InspectionException))]
        [TestMethod]
        public void InspectionSetInvalidResponsibleUserNullTest()
        {
            testingInspection.ResponsibleUser = null;
        }

        [ExpectedException(typeof(InspectionException))]
        [TestMethod]
        public void InspectionSetInvalidResponsibleUserTransporterTest()
        {
            User alternativeUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Juan", "Perez", "miUsuario", "pass",
               "26061199");
            testingInspection.ResponsibleUser = alternativeUser;
            Assert.AreEqual(alternativeUser, testingInspection.ResponsibleUser);
        }

        [TestMethod]
        public void InspectionSetLocationValidTest()
        {
            Location alternativeLocation = Location.CreateNewLocation(LocationType.PORT, "Puerto de Punta del Este");
            testingInspection.Location = alternativeLocation;
            Assert.AreEqual(alternativeLocation, testingInspection.Location);
        }

        [ExpectedException(typeof(InspectionException))]
        [TestMethod]
        public void InspectionSetInvalidLocationNullTest()
        {
            testingInspection.Location = null;
        }

        [TestMethod]
        public void InspectionSetValidDamagesListTest()
        {
            testingInspection.Damages = damageList;
            Assert.IsTrue(testingInspection.Damages.SequenceEqual(damageList));
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspecionSetInvalidDamagesListEmptyTest()
        {
            testingInspection.Damages = new List<Damage>();
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidDamagesNullTest()
        {
            testingInspection.Damages = null;
        }

        [TestMethod]
        public void InspectionSetValidVINTest()
        {
            testingInspection.VehicleVIN = "QAZWSXEDCRFV12345";
            Assert.AreEqual("QAZWSXEDCRFV12345", testingInspection.VehicleVIN);
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidVINShortTest()
        {
            testingInspection.VehicleVIN = "QWERT12345";
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionSetInvalidVINLongTest()
        {
            testingInspection.VehicleVIN = "QWERTY1234567890QWERTY";
        }

        [TestMethod]
        public void InspectionSetValidStageIdTest()
        {                                
                User alternativeUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Juan", "Perez", "miUsuario", "pass",
                    "097364857");
                testingInspection.ResponsibleUser = alternativeUser;
            Assert.AreEqual(alternativeUser, testingInspection.ResponsibleUser);
        }

        [ExpectedException(typeof(InspectionException))]
        [TestMethod]
        public void InspectionSetInvalidStageIdNullTest()
        {
            testingInspection.ResponsibleUser = null;
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
            Assert.AreEqual(alternativeUser, testingInspection.ResponsibleUser);
            Assert.AreEqual(alternativeLocation, testingInspection.Location);
            Assert.AreEqual(alternativeDateTime, testingInspection.DateTime);
            Assert.IsTrue(damageList.SequenceEqual(testingInspection.Damages));
            Assert.AreEqual(Vehicle.InstanceForTestingPurposes().VIN, testingInspection.VehicleVIN);
        }

        [TestMethod]
        [ExpectedException(typeof(InspectionException))]
        public void InspectionParameterFactoryMethodInvalidResponsibleUserTest()
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

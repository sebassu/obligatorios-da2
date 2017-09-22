using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    public class InspectionTests
    {
        private static Inspection testingInspection;

        [TestInitialize]
        public void TestSetup()
        {
            testingInspection = Inspection.InstanceForTestingPurposes();

        }

        [TestMethod]
        public void InspectionForTestingPurposesTest()
        {
            Assert.AreEqual(0, testingInspection.Id);
            Assert.AreEqual(new DateTime(2017, 9, 22, 10, 8, 0), testingInspection.DateTime);
        }

        [TestMethod]
        public void InspectionSetValidDateTimeTest()
        {
            testingInspection.DateTime = DateTime.Now;
            Assert.AreEqual(DateTime.Now, testingInspection.DateTime);
            Assert.AreEqual(User.CreateNewUser(UserRoles.ADMINISTRATOR, "Maria", "Gonzalez", "mgon", "password", "1239456"),
                testingInspection.ResponsibleUser);
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
        public void InspectionSetInvalidResponsibleUserEmptyTest()
        {
            testingInspection.ResponsibleUser = null;
        }

        [ExpectedException(typeof(InspectionException))]
        [TestMethod]
        public void InspectionSetInvalidResponsibleUserTransporterTest()
        {
            User alternativeUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Juan", "Perez", "miUsuario", "pass",
               "097364857");
            testingInspection.ResponsibleUser = alternativeUser;
            Assert.AreEqual(alternativeUser, testingInspection.ResponsibleUser);
        }
    }
}

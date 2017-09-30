using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Domain;

namespace Data.Tests.Domain_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MovementTests
    {
        private static Movement testingMovement;
        private static User testingUser = User.InstanceForTestingPurposes();

        [TestInitialize]
        public void TestSetup()
        {
            testingMovement = Movement.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void MovementInstanceForTestingPurposesTest()
        {
            Assert.AreEqual(0, testingSubzone.Id);
            User alternativeUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Maria", "Gonzalez", "mgon", 
                "password", "26010376");
            Assert.AreEqual(alternativeUser, testingMovement.ResponsibleUser);
            Assert.AreEqual(new DateTime(2017, 9, 22, 10, 8, 0), testingMovement.DateTime);
        }

        [TestMethod]
        public void MovementSetIdValidTest()
        {
            testingMovement.Id = 42;
            Assert.AreEqual(42, testingMovement.Id);
        }

        [TestMethod]
        public void MovementSetResponsibleUserValidTest()
        {
            User alternativeUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Juan", "Perez", "jPerez", "Password", "26061199");
            testingMovement.ResponsibleUser = alternativeUser;
            Assert.AreEqual(alternativeUser, testingMovement.ResponsibleUser);
        }

        [ExpectedException(typeof(MovementException))]
        [TestMethod]
        public void MovementSetInvalidResponsibleUserNullTest()
        {
            testingMovement.ResponsibleUser = null;
        }

        [ExpectedException(typeof(MovementException))]
        [TestMethod]
        public void MovementSetInvalidResponsibleUserTransporterTest()
        {
            User alternativeUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Juan", "Perez", "miUsuario", "pass",
               "26061199");
            testingMovement.ResponsibleUser = alternativeUser;
        }

        [TestMethod]
        public void MovementSetValidDateTimeTest()
        {
            DateTime alternativeDateTime = new DateTime(2017, 8, 24, 10, 9, 0);
            testingMovement.DateTime = alternativeDateTime;
            Assert.AreEqual(alternativeDateTime, testingMovement.DateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(MovementException))]
        public void MovementSetInvalidDatePassTodayTest()
        {
            testingMovement.DateTime = new DateTime(2019, 9, 24, 10, 9, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(MovementException))]
        public void MovementSetInvalidDateTimeOldTest()
        {
            testingMovement.DateTime = new DateTime(1856, 8, 30, 12, 8, 9);
        }
    }
}

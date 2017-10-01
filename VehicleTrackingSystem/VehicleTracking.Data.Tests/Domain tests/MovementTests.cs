﻿using System;
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
        private static User alternativeUser = User.CreateNewUser(UserRoles.ADMINISTRATOR,
            "Maria", "Gonzalez", "mgon", "password", "26010376");
        private static Subzone alternativeSubzone = Subzone.CreateNewSubzone("arrival", 8,
            Zone.InstanceForTestingPurposes());

        [TestInitialize]
        public void TestSetup()
        {
            testingMovement = Movement.InstanceForTestingPurposes();
            alternativeSubzone.Id = 2;
        }

        [TestMethod]
        public void MovementInstanceForTestingPurposesTest()
        {
            Assert.AreEqual(0, testingMovement.Id);
            Assert.IsNull(testingMovement.ResponsibleUser);
            Assert.AreEqual(DateTime.MinValue, testingMovement.DateTime);
            Assert.IsNull(testingMovement.SubzoneDeparture);
            Assert.IsNull(testingMovement.SubzoneArrival);
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
            User alternativeUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Juan", "Perez",
                "jPerez", "Password", "26061199");
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
            User alternativeUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Juan",
                "Perez", "miUsuario", "pass", "26061199");
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

        [TestMethod]
        public void MovementSetSubzoneDepartureValidTest()
        {
            Subzone alternativeSubzone = Subzone.CreateNewSubzone("subzone1", 7,
                Zone.InstanceForTestingPurposes());
            testingMovement.SubzoneDeparture = alternativeSubzone;
            Assert.AreEqual(alternativeSubzone, testingMovement.SubzoneDeparture);
        }

        [ExpectedException(typeof(MovementException))]
        [TestMethod]
        public void MovementSetInvalidSubzoneDepartureNullTest()
        {
            testingMovement.SubzoneDeparture = null;
        }

        [TestMethod]
        public void MovementSetSubzoneArrivalValidTest()
        {
            Subzone alternativeSubzoneDeparture = Subzone.CreateNewSubzone("subzone1", 7,
                Zone.InstanceForTestingPurposes());
            testingMovement.SubzoneDeparture = alternativeSubzoneDeparture;
            Subzone alternativeSubzoneArrival = Subzone.CreateNewSubzone("subzone1", 7,
                Zone.InstanceForTestingPurposes());
            alternativeSubzoneArrival.Id = 9;
            testingMovement.SubzoneArrival = alternativeSubzoneArrival;
            Assert.AreEqual(alternativeSubzoneArrival, testingMovement.SubzoneArrival);
        }

        [ExpectedException(typeof(MovementException))]
        [TestMethod]
        public void MovementSetInvalidSubzoneArrivalNullTest()
        {
            testingMovement.SubzoneArrival = null;
        }

        [ExpectedException(typeof(MovementException))]
        [TestMethod]
        public void MovementSetInvalidSubzoneArrivalEqualsDepartureTest()
        {
            Subzone alternativeSubzone = Subzone.CreateNewSubzone("subzone1", 7,
                Zone.InstanceForTestingPurposes());
            testingMovement.SubzoneDeparture = alternativeSubzone;
            testingMovement.SubzoneArrival = alternativeSubzone;
        }

        [TestMethod]
        public void MovementParameterFactoryMethodValidTest()
        {
            Subzone alternativeSubzoneDeparture = Subzone.InstanceForTestingPurposes();
            Subzone alternativeSubzoneArrival = alternativeSubzone;
            DateTime alternativeDateTime = new DateTime(2014, 12, 11, 12, 34, 11);
            testingMovement = Movement.CreateNewMovement(alternativeUser, alternativeDateTime,
                alternativeSubzoneDeparture, alternativeSubzoneArrival);
            Assert.AreEqual(alternativeUser, testingMovement.ResponsibleUser);
            Assert.AreEqual(alternativeDateTime, testingMovement.DateTime);
            Assert.AreEqual(alternativeSubzoneDeparture, testingMovement.SubzoneDeparture);
            Assert.AreEqual(alternativeSubzoneArrival, testingMovement.SubzoneArrival);
        }

        [TestMethod]
        [ExpectedException(typeof(MovementException))]
        public void MovementParameterFactoryMethodInvalidResponsibleUserTest()
        {
            Subzone alternativeSubzoneDeparture = Subzone.InstanceForTestingPurposes();
            Subzone alternativeSubzoneArrival = alternativeSubzone;
            DateTime alternativeDateTime = new DateTime(2017, 12, 11, 12, 34, 11);
            testingMovement = Movement.CreateNewMovement(null, alternativeDateTime,
                alternativeSubzoneDeparture, alternativeSubzoneArrival);
        }

        [TestMethod]
        [ExpectedException(typeof(MovementException))]
        public void MovementParameterFactoryMethodInvalidDateTimeTest()
        {
            Subzone alternativeSubzoneDeparture = Subzone.InstanceForTestingPurposes();
            Subzone alternativeSubzoneArrival = alternativeSubzone;
            DateTime alternativeDateTime = new DateTime(2019, 12, 11, 12, 34, 11);
            testingMovement = Movement.CreateNewMovement(alternativeUser, alternativeDateTime,
                alternativeSubzoneDeparture, alternativeSubzoneArrival);
        }


        [TestMethod]
        [ExpectedException(typeof(MovementException))]
        public void MovementParameterFactoryMethodInvalidSubzoneDepartureTest()
        {
            Subzone alternativeSubzoneArrival = alternativeSubzone;
            DateTime alternativeDateTime = new DateTime(2017, 12, 11, 12, 34, 11);
            testingMovement = Movement.CreateNewMovement(alternativeUser, alternativeDateTime,
                null, alternativeSubzoneArrival);
        }

        [TestMethod]
        [ExpectedException(typeof(MovementException))]
        public void MovementParameterFactoryMethodInvalidSubzoneArrivalTest()
        {
            Subzone alternativeSubzoneDeparture = Subzone.InstanceForTestingPurposes();
            DateTime alternativeDateTime = new DateTime(2017, 12, 11, 12, 34, 11);
            testingMovement = Movement.CreateNewMovement(alternativeUser, alternativeDateTime,
                alternativeSubzoneDeparture, null);
        }

        [TestMethod]
        public void MovementEqualsReflexiveTest()
        {
            Assert.AreEqual(testingMovement, testingMovement);
        }

        [TestMethod]
        public void MovementEqualsSymmetricTest()
        {
            Movement secondTestingMovement = Movement.InstanceForTestingPurposes();
            Assert.AreEqual(testingMovement, secondTestingMovement);
            Assert.AreEqual(secondTestingMovement, testingMovement);
        }

        [TestMethod]
        public void MovementEqualsTransitiveTest()
        {
            Subzone alternativeSubzoneDeparture = Subzone.InstanceForTestingPurposes();
            Subzone alternativeSubzoneArrival = alternativeSubzone;
            DateTime alternativeDateTime = new DateTime(2015, 12, 11, 12, 34, 11);
            testingMovement = Movement.CreateNewMovement(alternativeUser, alternativeDateTime,
                alternativeSubzoneDeparture, alternativeSubzoneArrival);
            Movement secondTestingMovement = Movement.CreateNewMovement(alternativeUser,
                alternativeDateTime, alternativeSubzoneDeparture, alternativeSubzoneArrival);
            Movement thirdTestingMovement = Movement.CreateNewMovement(alternativeUser,
                alternativeDateTime, alternativeSubzoneDeparture, alternativeSubzoneArrival);
            Assert.AreEqual(testingMovement, secondTestingMovement);
            Assert.AreEqual(secondTestingMovement, thirdTestingMovement);
            Assert.AreEqual(testingMovement, thirdTestingMovement);
        }

        [TestMethod]
        public void MovementEqualsDifferentMovementTest()
        {
            Subzone alternativeSubzoneDeparture = Subzone.InstanceForTestingPurposes();
            Subzone alternativeSubzoneArrival = alternativeSubzone;
            DateTime alternativeDateTime = new DateTime(2015, 12, 11, 12, 34, 11);
            testingMovement = Movement.CreateNewMovement(alternativeUser, alternativeDateTime,
                alternativeSubzoneDeparture, alternativeSubzoneArrival);
            testingMovement.Id = 1;
            Movement secondTestingMovement = Movement.CreateNewMovement(alternativeUser,
                alternativeDateTime, alternativeSubzoneDeparture, alternativeSubzoneArrival);
            secondTestingMovement.Id = 2;
            Assert.AreNotEqual(testingMovement, secondTestingMovement);
        }

        [TestMethod]
        public void MovementEqualsNullTest()
        {
            Assert.AreNotEqual(testingMovement, null);
        }

        [TestMethod]
        public void MovementEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingMovement, someRandomObject);
        }

        [TestMethod]
        public void MovementGetHashCodeTest()
        {
            object testingMovementAsObject = testingMovement;
            Assert.AreEqual(testingMovementAsObject.GetHashCode(), testingMovement.GetHashCode());
        }
    }
}

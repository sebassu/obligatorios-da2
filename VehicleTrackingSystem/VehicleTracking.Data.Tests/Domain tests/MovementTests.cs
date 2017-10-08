using System;
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
            Assert.IsNull(testingMovement.Departure);
            Assert.AreEqual(Subzone.InstanceForTestingPurposes(), testingMovement.Arrival);
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

        [TestMethod]
        [ExpectedException(typeof(MovementException))]
        public void MovementSetInvalidResponsibleUserNullTest()
        {
            testingMovement.ResponsibleUser = null;
        }

        [TestMethod]
        [ExpectedException(typeof(MovementException))]
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
        public void MovementSetDepartureValidTest()
        {
            Subzone alternativeSubzone = Subzone.CreateNewSubzone("subzone1", 7,
                Zone.InstanceForTestingPurposes());
            alternativeSubzone.Id = 1;
            testingMovement.Departure = alternativeSubzone;
            Assert.AreEqual(alternativeSubzone, testingMovement.Departure);
        }

        [TestMethod]
        public void MovementSetInvalidDepartureNullTest()
        {
            testingMovement.Departure = null;
        }

        [TestMethod]
        public void MovementSetDepartureEqualsArrivalIValidTest()
        {
            var departureToSet = Subzone.InstanceForTestingPurposes();
            Assert.AreEqual(departureToSet, testingMovement.Arrival);
            testingMovement.Departure = departureToSet;
            Assert.AreSame(departureToSet, testingMovement.Departure);
        }

        [TestMethod]
        public void MovementSetArrivalValidTest()
        {
            Subzone alternativeDeparture = Subzone.CreateNewSubzone("subzone1", 7,
                Zone.InstanceForTestingPurposes());
            alternativeDeparture.Id = 1;
            testingMovement.Departure = alternativeDeparture;
            Subzone alternativeArrival = Subzone.CreateNewSubzone("subzone1", 7,
                Zone.InstanceForTestingPurposes());
            alternativeArrival.Id = 9;
            testingMovement.Arrival = alternativeArrival;
            Assert.AreEqual(alternativeArrival, testingMovement.Arrival);
        }

        [TestMethod]

        public void MovementSetNullArrivalValidTest()
        {
            testingMovement.Arrival = null;
        }

        [TestMethod]
        public void MovementSetArrivalEqualsDepartureValidTest()
        {
            Subzone alternativeSubzone = Subzone.CreateNewSubzone("subzone1", 7,
                Zone.InstanceForTestingPurposes());
            testingMovement.Departure = alternativeSubzone;
            testingMovement.Arrival = alternativeSubzone;
            Assert.AreEqual(alternativeSubzone, testingMovement.Arrival);
        }

        [TestMethod]
        public void MovementParameterFactoryMethodValidTest()
        {
            Subzone alternativeDeparture = Subzone.InstanceForTestingPurposes();
            Subzone alternativeArrival = alternativeSubzone;
            DateTime alternativeDateTime = new DateTime(2014, 12, 11, 12, 34, 11);
            testingMovement = Movement.CreateNewMovement(alternativeUser, alternativeDateTime,
                alternativeDeparture, alternativeArrival);
            Assert.AreEqual(alternativeUser, testingMovement.ResponsibleUser);
            Assert.AreEqual(alternativeDateTime, testingMovement.DateTime);
            Assert.AreEqual(alternativeDeparture, testingMovement.Departure);
            Assert.AreEqual(alternativeArrival, testingMovement.Arrival);
        }

        [TestMethod]
        [ExpectedException(typeof(MovementException))]
        public void MovementParameterFactoryMethodInvalidResponsibleUserTest()
        {
            Subzone alternativeDeparture = Subzone.InstanceForTestingPurposes();
            Subzone alternativeArrival = alternativeSubzone;
            DateTime alternativeDateTime = new DateTime(2017, 12, 11, 12, 34, 11);
            testingMovement = Movement.CreateNewMovement(null, alternativeDateTime,
                alternativeDeparture, alternativeArrival);
        }

        [TestMethod]
        [ExpectedException(typeof(MovementException))]
        public void MovementParameterFactoryMethodInvalidDateTimeTest()
        {
            Subzone alternativeDeparture = Subzone.InstanceForTestingPurposes();
            Subzone alternativeArrival = alternativeSubzone;
            DateTime alternativeDateTime = new DateTime(2019, 12, 11, 12, 34, 11);
            testingMovement = Movement.CreateNewMovement(alternativeUser, alternativeDateTime,
                alternativeDeparture, alternativeArrival);
        }


        [TestMethod]
        [ExpectedException(typeof(MovementException))]
        public void MovementParameterFactoryMethodInvalidDepartureTest()
        {
            Subzone alternativeArrival = alternativeSubzone;
            DateTime alternativeDateTime = new DateTime(2017, 12, 11, 12, 34, 11);
            testingMovement = Movement.CreateNewMovement(alternativeUser, alternativeDateTime,
                null, alternativeArrival);
        }

        [TestMethod]
        [ExpectedException(typeof(MovementException))]
        public void MovementParameterFactoryMethodInvalidArrivalTest()
        {
            Subzone alternativeDeparture = Subzone.InstanceForTestingPurposes();
            DateTime alternativeDateTime = new DateTime(2017, 12, 11, 12, 34, 11);
            testingMovement = Movement.CreateNewMovement(alternativeUser, alternativeDateTime,
                alternativeDeparture, null);
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
            Subzone alternativeDeparture = Subzone.InstanceForTestingPurposes();
            Subzone alternativeArrival = alternativeSubzone;
            DateTime alternativeDateTime = new DateTime(2015, 12, 11, 12, 34, 11);
            testingMovement = Movement.CreateNewMovement(alternativeUser, alternativeDateTime,
                alternativeDeparture, alternativeArrival);
            Movement secondTestingMovement = Movement.CreateNewMovement(alternativeUser,
                alternativeDateTime, alternativeDeparture, alternativeArrival);
            Movement thirdTestingMovement = Movement.CreateNewMovement(alternativeUser,
                alternativeDateTime, alternativeDeparture, alternativeArrival);
            Assert.AreEqual(testingMovement, secondTestingMovement);
            Assert.AreEqual(secondTestingMovement, thirdTestingMovement);
            Assert.AreEqual(testingMovement, thirdTestingMovement);
        }

        [TestMethod]
        public void MovementEqualsDifferentMovementTest()
        {
            Subzone alternativeDeparture = Subzone.InstanceForTestingPurposes();
            Subzone alternativeArrival = alternativeSubzone;
            DateTime alternativeDateTime = new DateTime(2015, 12, 11, 12, 34, 11);
            testingMovement = Movement.CreateNewMovement(alternativeUser, alternativeDateTime,
                alternativeDeparture, alternativeArrival);
            testingMovement.Id = 1;
            Movement secondTestingMovement = Movement.CreateNewMovement(alternativeUser,
                alternativeDateTime, alternativeDeparture, alternativeArrival);
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
            Assert.AreEqual(testingMovementAsObject.GetHashCode(),
                testingMovement.GetHashCode());
        }
    }
}
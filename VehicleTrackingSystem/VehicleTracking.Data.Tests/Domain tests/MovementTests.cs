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
            Assert.IsNull(testingMovement.ResponsibleUser);
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
    }
}

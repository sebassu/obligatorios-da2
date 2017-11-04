using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using API.Services;
using Persistence;
using Moq;
using Domain;

namespace Web.API.Tests.Services_Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class SessionServicesTests
    {
        private static readonly SessionServices testingSessionServices = new SessionServices();

        UserDTO testingUserData = UserDTO.FromData(UserRoles.PORT_OPERATOR, "Emilio",
        "Ravenna", "eRavenna", "HablarUnasPalabritas", "091696969");

        [TestMethod]
        public void LogInSuccessfullyTest()
        {
            UserDTO testingUserData = UserDTO.FromData(UserRoles.ADMINISTRATOR, "Maria",
                "Perez", "mPerez", "UnaContraseña", "091696969");
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Users.AddNewUser(It.IsAny<User>()))
                .Verifiable();
            var userServices = new UserServices(mockUnitOfWork.Object);
            userServices.AddNewUserFromData(testingUserData);
            bool actual = testingSessionServices.LogIn("mPerez", "UnaContraseña");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void CanNotLogInWrongUserNameTest()
        {
            UserDTO testingUserData = UserDTO.FromData(UserRoles.ADMINISTRATOR, "Juan",
                "Gonzalez", "Juancito", "Juan123", "091696969");
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Users.AddNewUser(It.IsAny<User>()))
                .Verifiable();
            var userServices = new UserServices(mockUnitOfWork.Object);
            userServices.AddNewUserFromData(testingUserData);
            bool actual = testingSessionServices.LogIn("jPerez", "Juan123");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void CanNotLogInWrongPasswordTest()
        {
            UserDTO testingUserData = UserDTO.FromData(UserRoles.ADMINISTRATOR, "Pedro",
                "Martinez", "pMartinez", "pMartinez123", "091696969");
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Users.AddNewUser(It.IsAny<User>()))
                .Verifiable();
            var userServices = new UserServices(mockUnitOfWork.Object);
            userServices.AddNewUserFromData(testingUserData);
            bool actual = testingSessionServices.LogIn("pMartinez", "pMartinez");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void CanNotLogInWrongUserRoleTest()
        {
            UserDTO testingUserData = UserDTO.FromData(UserRoles.PORT_OPERATOR, "Gonzalo",
                "Gonzalez", "gGonzalez", "Gonzalo123", "091696969");
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Users.AddNewUser(It.IsAny<User>()))
                .Verifiable();
            var userServices = new UserServices(mockUnitOfWork.Object);
            userServices.AddNewUserFromData(testingUserData);
            bool actual = testingSessionServices.LogIn("gGonzalez", "Gonzalo123");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void TestNoMailEntered()
        {
            bool actual = testingSessionServices.LogIn("", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void TestNoPasswordEntered()
        {
            UserDTO testingUserData = UserDTO.FromData(UserRoles.ADMINISTRATOR, "Pablo",
                "Martinez", "PabloMartinez", "pMartinez123", "091696969");
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Users.AddNewUser(It.IsAny<User>()))
                .Verifiable();
            var userServices = new UserServices(mockUnitOfWork.Object);
            userServices.AddNewUserFromData(testingUserData);
            bool actual = testingSessionServices.LogIn("PabloMartinez", "");
        }
    }
}


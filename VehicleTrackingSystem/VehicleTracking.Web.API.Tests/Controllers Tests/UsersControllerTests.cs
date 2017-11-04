using Moq;
using Domain;
using API.Services;
using System.Web.Http;
using Web.API.Controllers;
using System.Web.Http.Results;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System;
using Web.API.Tests;

namespace Web.API.Controllers_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UsersControllerTests
    {
        private static UserDTO fakeUserData = UserDTO.FromData(UserRoles.ADMINISTRATOR,
            "Mario", "Santos", "mSantos", "DisculpeFuegoTiene", "099424242");

        [TestMethod]
        public void UControllerDefaultParameterlessConstructorTest()
        {
            var controllerToVerify = new UsersController();
            Assert.IsNotNull(controllerToVerify.Model);
        }

        #region AddNewUserFromData tests
        [TestMethod]
        public void UControllerAddNewUserFromDataValidTest()
        {
            var idToVerify = 42;
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.AddNewUserFromData(fakeUserData))
                .Returns(idToVerify);
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.AddNewUserFromData(fakeUserData);
            var result = obtainedResult as CreatedAtRouteNegotiatedContentResult<UserDTO>;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual("VTSystemAPI", result.RouteName);
            Assert.AreEqual(idToVerify, result.RouteValues["id"]);
            Assert.AreEqual(fakeUserData, result.Content);
        }

        [TestMethod]
        public void UControllerAddNewUserFromNullDataInvalidTest()
        {
            var expectedErrorMessage = "Some error message";
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.AddNewUserFromData(null)).Throws(
                new VehicleTrackingException(expectedErrorMessage));
            var controller = new UsersController(mockUsersServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsBadRequestResponse(
                delegate { return controller.AddNewUserFromData(null); },
                mockUsersServices, expectedErrorMessage);
        }

        [TestMethod]
        public void UControllerAddNewUserFromDataUnexpectedErrorInvalidTest()
        {
            SystemException expectedException = new SystemException();
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.AddNewUserFromData(fakeUserData))
                .Throws(expectedException);
            var controller = new UsersController(mockUsersServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsServerErrorResponse(delegate
            { return controller.AddNewUserFromData(fakeUserData); }, mockUsersServices, expectedException);
        }
        #endregion

        #region GetRegisteredUsers tests
        [TestMethod]
        public void UControllerGetRegisteredUsersWithDataValidTest()
        {
            var expectedUsers = GetCollectionOfFakeUsers();
            VerifyMethodReturnsExpectedUsers(expectedUsers);
        }

        private IEnumerable<UserDTO> GetCollectionOfFakeUsers()
        {
            return new List<UserDTO>
            {
                UserDTO.FromData(UserRoles.ADMINISTRATOR, "Mario", "Santos", "mSantos",
                    "DisculpeFuegoTiene", "099424242"),
                UserDTO.FromData(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                    "pLamponne", "NoHaceFalta", "099212121")
            }.AsReadOnly();
        }

        [TestMethod]
        public void UControllerGetRegisteredUsersNoDataValidTest()
        {
            var expectedUsers = new List<UserDTO>().AsReadOnly();
            VerifyMethodReturnsExpectedUsers(expectedUsers);
        }

        private static void VerifyMethodReturnsExpectedUsers(IEnumerable<UserDTO> expectedUsers)
        {
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.GetRegisteredUsers()).Returns(expectedUsers);
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.GetRegisteredUsers();
            var contentResult = obtainedResult as
                OkNegotiatedContentResult<IEnumerable<UserDTO>>;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            CollectionAssert.AreEqual(expectedUsers.ToList(),
                contentResult.Content.ToList());
        }

        [TestMethod]
        public void UControllerGetRegisteredUsersNullResponseInvalidTest()
        {
            IEnumerable<UserDTO> unexpectedUsers = null;
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.GetRegisteredUsers()).Returns(unexpectedUsers);
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.GetRegisteredUsers();
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(obtainedResult);
            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void UControllerGetRegisteredUsersUnexpectedErrorInvalidTest()
        {
            SystemException expectedException = new SystemException();
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.GetRegisteredUsers()).Throws(expectedException);
            var controller = new UsersController(mockUsersServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsServerErrorResponse(
                delegate { return controller.GetRegisteredUsers(); },
                mockUsersServices, expectedException);
        }
        #endregion

        #region GetUserWithUsername tests
        [TestMethod]
        public void UControllerGetUserWithUsernameValidTest()
        {
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.GetUserWithUsername("mSantos")).Returns(fakeUserData);
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.GetUserByUsername("mSantos");
            var result = obtainedResult as OkNegotiatedContentResult<UserDTO>;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(fakeUserData, result.Content);
        }

        [TestMethod]
        public void UControllerGetUserWithUnregisteredUsernameInvalidTest()
        {
            string expectedErrorMessage = "Some fourth exception message";
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.GetUserWithUsername(It.IsAny<string>())).Throws(
                new VehicleTrackingException(expectedErrorMessage));
            var controller = new UsersController(mockUsersServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsBadRequestResponse(
                delegate { return controller.GetUserByUsername("eRavenna"); },
                mockUsersServices, expectedErrorMessage);
        }

        [TestMethod]
        public void UControllerGetUserWithUsernameUnexpectedErrorInvalidTest()
        {
            SystemException expectedException = new SystemException();
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.GetUserWithUsername(It.IsAny<string>())).Throws(expectedException);
            var controller = new UsersController(mockUsersServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsServerErrorResponse(
                delegate { return controller.GetUserByUsername("eRavenna"); },
                mockUsersServices, expectedException);
        }
        #endregion

        #region ModifyUserWithUsername tests
        [TestMethod]
        public void UControllerModifyUserWithUsernameValidTest()
        {
            var fakeUserDataToSet = UserDTO.FromData(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "pLamponne", "NoHaceFalta", "099212121");
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.ModifyUserWithUsername(fakeUserData.Username, It.IsAny<UserDTO>()));
            var controller = new UsersController(mockUsersServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsOkResponse(
                delegate { return controller.ModifyUserWithUsername("mSantos", fakeUserDataToSet); },
                mockUsersServices);
        }

        [TestMethod]
        public void UControllerModifyUserWithUsernameNullDataInvalidTest()
        {
            var expectedErrorMessage = "A third error message.";
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.ModifyUserWithUsername(fakeUserData.Username, null)).Throws(
                new VehicleTrackingException(expectedErrorMessage));
            var controller = new UsersController(mockUsersServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsBadRequestResponse(
                delegate { return controller.ModifyUserWithUsername("mSantos", null); }, mockUsersServices,
                expectedErrorMessage);
        }

        [TestMethod]
        public void UControllerModifyUserWithUnregisteredUsernameInvalidTest()
        {
            var expectedErrorMessage = "Fourth error message.";
            var fakeUserDataToSet = UserDTO.FromData(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "pLamponne", "NoHaceFaltaSaleSolo", "099212121");
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.ModifyUserWithUsername(It.IsAny<string>(), It.IsAny<UserDTO>())).Throws(
                new VehicleTrackingException(expectedErrorMessage));
            var controller = new UsersController(mockUsersServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsBadRequestResponse(delegate
                { return controller.ModifyUserWithUsername("eRavenna", fakeUserDataToSet); },
                mockUsersServices, expectedErrorMessage);
        }

        [TestMethod]
        public void UControllerModifyUserWithUsernameUnexpectedErrorInvalidTest()
        {
            SystemException expectedException = new SystemException();
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.ModifyUserWithUsername(It.IsAny<string>(), It.IsAny<UserDTO>()))
                .Throws(expectedException);
            var controller = new UsersController(mockUsersServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsServerErrorResponse(delegate
            { return controller.ModifyUserWithUsername("eRavenna", new UserDTO()); },
                mockUsersServices, expectedException);
        }
        #endregion

        #region RemoveUserWithUsername tests
        [TestMethod]
        public void UControllerRemoveUserWithUsernameValidTest()
        {
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.RemoveUserWithUsername(It.IsAny<string>()));
            var controller = new UsersController(mockUsersServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsOkResponse(
                delegate { return controller.RemoveUserWithUsername("eRavenna"); },
                mockUsersServices);
        }

        [TestMethod]
        public void UControllerRemoveUserWithUnregisteredUsernameInvalidTest()
        {
            var expectedErrorMessage = "Some other error message";
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.RemoveUserWithUsername(It.IsAny<string>())).Throws(
                new VehicleTrackingException(expectedErrorMessage));
            var controller = new UsersController(mockUsersServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsBadRequestResponse(
                delegate { return controller.RemoveUserWithUsername(""); },
                mockUsersServices, expectedErrorMessage);
        }

        [TestMethod]
        public void UControllerRemoveUserWithUsernameUnexpectedErrorInvalidTest()
        {
            SystemException expectedException = new SystemException();
            var mockUsersServices = new Mock<IUserServices>();
            mockUsersServices.Setup(u => u.RemoveUserWithUsername(It.IsAny<string>())).Throws(expectedException);
            var controller = new UsersController(mockUsersServices.Object);
            ControllerTestsUtilities.VerifyMethodReturnsServerErrorResponse(
                delegate { return controller.RemoveUserWithUsername("eRavenna"); },
                mockUsersServices, expectedException);
        }
        #endregion
    }
}
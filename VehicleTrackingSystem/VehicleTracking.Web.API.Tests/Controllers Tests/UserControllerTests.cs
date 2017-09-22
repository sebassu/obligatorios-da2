using Moq;
using Domain;
using API.Services;
using System.Web.Http;
using Web.API.Controllers;
using System.Web.Http.Results;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Web.API.Controllers_Tests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void UControllerGetRegisteredUsersWithDataValidTest()
        {
            var expectedUsers = GetCollectionOfFakeUsers();
            var mockUsersServices = new Mock<IUsersServices>();
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

        private IEnumerable<UserDTO> GetCollectionOfFakeUsers()
        {
            return new List<UserDTO>
            {
                UserDTO.FromUser(
                    User.CreateNewUser(UserRoles.ADMINISTRATOR, "Mario", "Santos", "mSantos",
                    "DisculpeFuegoTiene", "099424242")),
                UserDTO.FromUser(User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                    "pLamponne", "NoHaceFalta", "099212121"))
            }.AsReadOnly();
        }

        [TestMethod]
        public void UControllerGetRegisteredUsersNoDataValidTest()
        {
            var expectedUsers = new List<UserDTO>().AsReadOnly();
            var mockUsersServices = new Mock<IUsersServices>();
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
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.GetRegisteredUsers()).Returns(unexpectedUsers);
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.GetRegisteredUsers();
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(obtainedResult);
            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void UControllerAddValidNewUserValidTest()
        {
            var fakeUser = UserDTO.FromUser(User.CreateNewUser(UserRoles.ADMINISTRATOR,
                "Mario", "Santos", "mSantos", "DisculpeFuegoTiene", "099424242"));
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.AddNewUserFromData(fakeUser));
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.AddNewUserFromDTO(fakeUser);
            var result = obtainedResult as CreatedAtRouteNegotiatedContentResult<UserDTO>;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual("DefaultApi", result.RouteName);
            Assert.AreEqual(fakeUser.Username, result.RouteValues["id"]);
            Assert.AreEqual(fakeUser, result.Content);
        }

        [TestMethod]
        public void UControllerAddNullUserInvalidTest()
        {
            var expectedErrorMessage = "Some error message";
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.AddNewUserFromData(null)).Throws(
                new VTSystemException(expectedErrorMessage));
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.AddNewUserFromDTO(null);
            var result = obtainedResult as BadRequestErrorMessageResult;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedErrorMessage, result.Message);
        }


        [TestMethod]
        public void UControllerDeleteUserWithIdValidTest()
        {
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.RemoveUserWithUsername(It.IsAny<string>()));
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.RemoveUserWithId("eRavenna");
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(obtainedResult);
            Assert.IsInstanceOfType(obtainedResult, typeof(OkResult));
        }

        [TestMethod]
        public void UControllerDeleteUserWithUnregisteredIdInvalidTest()
        {
            var expectedErrorMessage = "Some other error message";
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.RemoveUserWithUsername(It.IsAny<string>())).Throws(
                new VTSystemException(expectedErrorMessage));
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.RemoveUserWithId("eRavenna");
            var result = obtainedResult as BadRequestErrorMessageResult;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedErrorMessage, result.Message);
        }

        [TestMethod]
        public void UControllerUpdateUserWithIdValidTest()
        {
            var fakeUser = User.CreateNewUser(UserRoles.ADMINISTRATOR,
                "Mario", "Santos", "mSantos", "DisculpeFuegoTiene", "099424242");
            var fakeUserDataToSet = UserDTO.FromUser(User.CreateNewUser(UserRoles.TRANSPORTER,
                "Pablo", "Lamponne", "pLamponne", "NoHaceFalta", "099212121"));
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.ModifyUserWithUsername(fakeUser.Username, It.IsAny<UserDTO>()));
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult result = controller.UpdateUserWithId("mSantos", fakeUserDataToSet);
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void UControllerUpdateUserWithIdNullDataInvalidTest()
        {
            var expectedErrorMessage = "A third error message.";
            var fakeUser = User.CreateNewUser(UserRoles.ADMINISTRATOR,
                "Mario", "Santos", "mSantos", "DisculpeFuegoTiene", "099424242");
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.ModifyUserWithUsername(fakeUser.Username, null)).Throws(
                new VTSystemException(expectedErrorMessage));
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.UpdateUserWithId("mSantos", null);
            var result = obtainedResult as BadRequestErrorMessageResult;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedErrorMessage, result.Message);
        }

        [TestMethod]
        public void UControllerUpdateUserWithUnregisteredIdTest()
        {
            var expectedErrorMessage = "Fourth error message.";
            var fakeUserDataToSet = UserDTO.FromUser(User.CreateNewUser(UserRoles.TRANSPORTER,
                "Pablo", "Lamponne", "pLamponne", "NoHaceFaltaSaleSolo", "099212121"));
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.ModifyUserWithUsername(It.IsAny<string>(), It.IsAny<UserDTO>())).Throws(
                new VTSystemException(expectedErrorMessage));
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.UpdateUserWithId("eRavenna", fakeUserDataToSet);
            var result = obtainedResult as BadRequestErrorMessageResult;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedErrorMessage, result.Message);
        }

        [TestMethod]
        public void UControllerGetUserByIdValidTest()
        {
            var fakeUser = UserDTO.FromUser(User.CreateNewUser(UserRoles.ADMINISTRATOR,
                "Mario", "Santos", "mSantos", "DisculpeFuegoTiene", "099424242"));
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.GetUserByUsername("mSantos")).Returns(fakeUser);
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.GetUserById("mSantos");
            var result = obtainedResult as OkNegotiatedContentResult<UserDTO>;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(fakeUser, result.Content);
        }

        [TestMethod]
        public void UControllerGetUserByUnregisteredIdInvalidTest()
        {
            string expectedErrorMessage = "Some fourth exception message";
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.GetUserByUsername(It.IsAny<string>())).Throws(
                new VTSystemException(expectedErrorMessage));
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.GetUserById("eRavenna");
            var result = obtainedResult as BadRequestErrorMessageResult;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedErrorMessage, result.Message);
        }
    }
}
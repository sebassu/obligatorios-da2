using Moq;
using Domain;
using API.Services;
using System.Web.Http;
using Web.API.Controllers;
using System.Web.Http.Results;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Web.API.Tests
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
                OkNegotiatedContentResult<IReadOnlyCollection<UserDTO>>;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            CollectionAssert.AreEqual(expectedUsers.ToList(),
                contentResult.Content.ToList());
        }

        private IReadOnlyCollection<UserDTO> GetCollectionOfFakeUsers()
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
                OkNegotiatedContentResult<IReadOnlyCollection<UserDTO>>;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            CollectionAssert.AreEqual(expectedUsers.ToList(),
                contentResult.Content.ToList());
        }

        [TestMethod]
        public void UControllerGetRegisteredUsersNullResponseInvalidTest()
        {
            IReadOnlyCollection<UserDTO> unexpectedUsers = null;
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
            fakeUser.Id = 42;
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.Add(fakeUser)).Returns(fakeUser.Id);
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.AddNewUserFromDTO(fakeUser);
            var result = obtainedResult as CreatedAtRouteNegotiatedContentResult<UserDTO>;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual("DefaultApi", result.RouteName);
            Assert.AreEqual(fakeUser.Id, result.RouteValues["id"]);
            Assert.AreEqual(fakeUser, result.Content);
        }

        [TestMethod]
        public void UControllerAddNullUserInvalidTest()
        {
            var expectedErrorMessage = "Some error message";
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.Add(null)).Throws(
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
            mockUsersServices.Setup(u => u.Remove(It.IsAny<int>()));
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.RemoveUserWithId(42);
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(obtainedResult);
            Assert.IsInstanceOfType(obtainedResult, typeof(OkResult));
        }

        [TestMethod]
        public void UControllerDeleteUserWithUnregisteredIdInvalidTest()
        {
            var expectedErrorMessage = "Some other error message";
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.Remove(It.IsAny<int>())).Throws(
                new VTSystemException(expectedErrorMessage));
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.RemoveUserWithId(42);
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
            fakeUser.Id = 42;
            var fakeUserDataToSet = UserDTO.FromUser(User.CreateNewUser(UserRoles.TRANSPORTER,
                "Pablo", "Lamponne", "pLamponne", "NoHaceFalta", "099212121"));
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.UpdateUserWithId(fakeUser.Id, It.IsAny<UserDTO>()));
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult result = controller.UpdateUserWithId(42, fakeUserDataToSet);
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
            fakeUser.Id = 42;
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.UpdateUserWithId(fakeUser.Id, null)).Throws(
                new VTSystemException(expectedErrorMessage));
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.UpdateUserWithId(42, null);
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
                "Pablo", "Lamponne", "pLamponne", "NoHaceFalta", "099212121"));
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.UpdateUserWithId(It.IsAny<int>(), It.IsAny<UserDTO>())).Throws(
                new VTSystemException(expectedErrorMessage));
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.UpdateUserWithId(42, fakeUserDataToSet);
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
            fakeUser.Id = 42;
            var mockUsersServices = new Mock<IUsersServices>();
            mockUsersServices.Setup(u => u.GetUserByUd(42)).Returns(fakeUser);
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.GetUserById(42);
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
            mockUsersServices.Setup(u => u.GetUserByUd(It.IsAny<int>())).Throws(
                new VTSystemException(expectedErrorMessage));
            var controller = new UsersController(mockUsersServices.Object);
            IHttpActionResult obtainedResult = controller.GetUserById(42);
            var result = obtainedResult as BadRequestErrorMessageResult;
            mockUsersServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedErrorMessage, result.Message);
        }
    }
}
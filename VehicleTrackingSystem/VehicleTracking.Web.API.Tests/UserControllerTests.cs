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
        public void UControllerGetRegisteredUsersWithDataOkTest()
        {
            var expectedUsers = GetCollectionOfFakeUsers();
            var mockUserServices = new Mock<IUsersServices>();
            mockUserServices.Setup(u => u.GetAllUsers()).Returns(expectedUsers);
            var controller = new UsersController(mockUserServices.Object);
            IHttpActionResult obtainedResult = controller.GetRegisteredUsers();
            var contentResult = obtainedResult as
                OkNegotiatedContentResult<IReadOnlyCollection<UserDTO>>;
            mockUserServices.VerifyAll();
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
        public void UControllerGetRegisteredUsersNoDataOkTest()
        {
            var expectedUsers = new List<UserDTO>().AsReadOnly();
            var mockUserServices = new Mock<IUsersServices>();
            mockUserServices.Setup(u => u.GetAllUsers()).Returns(expectedUsers);
            var controller = new UsersController(mockUserServices.Object);
            IHttpActionResult obtainedResult = controller.GetRegisteredUsers();
            var contentResult = obtainedResult as
                OkNegotiatedContentResult<IReadOnlyCollection<UserDTO>>;
            mockUserServices.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            CollectionAssert.AreEqual(expectedUsers.ToList(),
                contentResult.Content.ToList());
        }

        [TestMethod]
        public void UControllerGetRegisteredUsersNullResponseNotFoundTest()
        {
            IReadOnlyCollection<UserDTO> unexpectedUsers = null;
            var mockUserServices = new Mock<IUsersServices>();
            mockUserServices.Setup(u => u.GetAllUsers()).Returns(unexpectedUsers);
            var controller = new UsersController(mockUserServices.Object);
            IHttpActionResult obtainedResult = controller.GetRegisteredUsers();
            mockUserServices.VerifyAll();
            Assert.IsNotNull(obtainedResult);
            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void UControllerAddValidNewUserOkTest()
        {
            var fakeUser = UserDTO.FromUser(User.CreateNewUser(UserRoles.ADMINISTRATOR, "Mario", "Santos",
                "mSantos", "DisculpeFuegoTiene", "099424242"));
            fakeUser.Id = 42;
            var mockUserServices = new Mock<IUsersServices>();
            mockUserServices.Setup(u => u.Add(fakeUser)).Returns(fakeUser.Id);
            var controller = new UsersController(mockUserServices.Object);
            IHttpActionResult obtainedResult = controller.AddNewUserFromDTO(fakeUser);
            var result = obtainedResult as CreatedAtRouteNegotiatedContentResult<UserDTO>;
            mockUserServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual("DefaultApi", result.RouteName);
            Assert.AreEqual(fakeUser.Id, result.RouteValues["id"]);
            Assert.AreEqual(fakeUser, result.Content);
        }

        [TestMethod]
        public void UControllerCreateNullUserBadRequestTest()
        {
            var expectedErrorMessage = "Some error message";
            var mockUserServices = new Mock<IUsersServices>();
            mockUserServices.Setup(u => u.Add(null)).Throws(
                new VTSystemException(expectedErrorMessage));
            var controller = new UsersController(mockUserServices.Object);
            IHttpActionResult obtainedResult = controller.AddNewUserFromDTO(null);
            var result = obtainedResult as BadRequestErrorMessageResult;
            mockUserServices.VerifyAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedErrorMessage, result.Message);
        }
    }
}
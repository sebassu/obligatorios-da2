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
            IHttpActionResult obtainedResult = controller.Get();
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
            IHttpActionResult obtainedResult = controller.Get();
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
            IHttpActionResult obtainedResult = controller.Get();
            mockUserServices.VerifyAll();
            Assert.IsNotNull(obtainedResult);
            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
        }
    }
}
using API.Services;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Web.API.Services_Tests
{
    [TestClass]
    public class UserServicesTests
    {
        private static UserServices testingUserServices = new UserServices();
        private static User testingUser = User.CreateNewUser(UserRoles.PORT_OPERATOR, "Emilio",
            "Ravenna", "eRavenna", "HablarUnasPalabritas", "091696969");

        [TestMethod]
        public void UServicesGetRegisteredUsersWithDataTest()
        {
            var someUsers = GetCollectionOfFakeUsers();
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.Elements).Returns(someUsers);
            var userServices = new UserServices(mockUserRepository.Object);
            var result = userServices.GetRegisteredUsers().ToList();
            mockUserRepository.VerifyAll();
            CollectionAssert.AreEqual(GetCollectionOfFakeUserDTOs(), result);
        }

        private IEnumerable<User> GetCollectionOfFakeUsers()
        {
            return new List<User>
            {
                User.CreateNewUser(UserRoles.ADMINISTRATOR, "Mario", "Santos", "mSantos",
                    "DisculpeFuegoTiene", "099424242"),
                User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                    "pLamponne", "NoHaceFalta", "099212121")
            }.AsReadOnly();
        }

        private List<UserDTO> GetCollectionOfFakeUserDTOs()
        {
            var result = new List<UserDTO>();
            foreach (var user in GetCollectionOfFakeUsers())
            {
                result.Add(UserDTO.FromUser(user));
            }
            return result;
        }

        [TestMethod]
        public void UServicesGetRegisteredUsersNoDataTest()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.Elements).Returns(new List<User>());
            var userServices = new UserServices(mockUserRepository.Object);
            CollectionAssert.AreEqual(new List<UserDTO>(),
                userServices.GetRegisteredUsers().ToList());
        }
    }
}
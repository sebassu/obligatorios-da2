using API.Services;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Persistence;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Web.API.Services_Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
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

        [TestMethod]
        public void UServicesAddNewUserFromDataValidTest()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.AddNewUser(It.IsAny<User>()));
            var userServices = new UserServices(mockUserRepository.Object);
            userServices.AddNewUserFromData(UserDTO.FromUser(testingUser));
            mockUserRepository.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void UServicesAddNewUserFromNullDataInvalidTest()
        {
            testingUserServices.AddNewUserFromData(null);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UServicesAddNewUserFromDataInvalidFirstNameTest()
        {
            UserDTO testUserData = UserDTO.FromData(UserRoles.YARD_OPERATOR, "1d2@#!9 #(", "Medina",
                "gdMedina1", "MusicaSuperDivertida", "096869689");
            RunTestWithInvalidUserDataOnDTO(testUserData);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UServicesAddNewUserFromDataInvalidLastNameTest()
        {
            UserDTO testUserData = UserDTO.FromData(UserRoles.YARD_OPERATOR, "Gabriel David",
                "*$ 563a%7*//*0&d!@", "gdMedina2", "MusicaSuperDivertida", "096869689");
            RunTestWithInvalidUserDataOnDTO(testUserData);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UServicesAddNewUserFromDataInvalidUsernameTest()
        {
            UserDTO testUserData = UserDTO.FromData(UserRoles.YARD_OPERATOR, "Gabriel David", "Medina",
                "Ceci n'est pas un nom d'utilisateur.", "MusicaSuperDivertida", "096869689");
            RunTestWithInvalidUserDataOnDTO(testUserData);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UServicesAddNewUserFromDataInvalidPasswordTest()
        {
            UserDTO testUserData = UserDTO.FromData(UserRoles.YARD_OPERATOR, "Gabriel David",
                "Medina", "gdMedina3", "  \n \t \t\t\n ", "096869689");
            RunTestWithInvalidUserDataOnDTO(testUserData);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UServicesAddNewUserFromDataInvalidPhoneNumberTest()
        {
            UserDTO testUserData = UserDTO.FromData(UserRoles.YARD_OPERATOR, "Gabriel David", "Medina",
                "gdMedina4", "MusicaSuperDivertida", "La juguetería del Señor Simón.");
            RunTestWithInvalidUserDataOnDTO(testUserData);
        }

        private static void RunTestWithInvalidUserDataOnDTO(UserDTO testUserData)
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.ExistsUserWithUsername(It.IsAny<string>())).Returns(false);
            var userServices = new UserServices(mockUserRepository.Object);
            userServices.AddNewUserFromData(testUserData);
            mockUserRepository.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void UServicesAddNewUserWithRepeatedUsernameInvalidTest()
        {
            UserDTO testUserData = UserDTO.FromUser(testingUser);
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.ExistsUserWithUsername(It.IsAny<string>())).Returns(true);
            var userServices = new UserServices(mockUserRepository.Object);
            userServices.AddNewUserFromData(testUserData);
        }
    }
}
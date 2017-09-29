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
        private static UserDTO testingUserData = UserDTO.FromData(UserRoles.PORT_OPERATOR, "Emilio",
            "Ravenna", "eRavenna", "HablarUnasPalabritas", "091696969");

        [TestMethod]
        public void UServicesDefaultParameterlessConstructorTest()
        {
            Assert.IsNotNull(testingUserServices.Model);
        }

        #region GetRegisteredUsers tests
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
        #endregion

        #region AddNewUserFromData tests
        [TestMethod]
        public void UServicesAddNewUserFromDataValidTest()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.AddNewUser(It.IsAny<User>()));
            var userServices = new UserServices(mockUserRepository.Object);
            userServices.AddNewUserFromData(testingUserData);
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
            RunAddNewUserTestWithInvalidDataOnDTO(testUserData);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UServicesAddNewUserFromDataInvalidLastNameTest()
        {
            UserDTO testUserData = UserDTO.FromData(UserRoles.YARD_OPERATOR, "Gabriel David",
                "*$ 563a%7*//*0&d!@", "gdMedina2", "MusicaSuperDivertida", "096869689");
            RunAddNewUserTestWithInvalidDataOnDTO(testUserData);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UServicesAddNewUserFromDataInvalidUsernameTest()
        {
            UserDTO testUserData = UserDTO.FromData(UserRoles.YARD_OPERATOR, "Gabriel David", "Medina",
                "Ceci n'est pas un nom d'utilisateur.", "MusicaSuperDivertida", "096869689");
            RunAddNewUserTestWithInvalidDataOnDTO(testUserData);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UServicesAddNewUserFromDataInvalidPasswordTest()
        {
            UserDTO testUserData = UserDTO.FromData(UserRoles.YARD_OPERATOR, "Gabriel David",
                "Medina", "gdMedina3", "  \n \t \t\t\n ", "096869689");
            RunAddNewUserTestWithInvalidDataOnDTO(testUserData);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UServicesAddNewUserFromDataInvalidPhoneNumberTest()
        {
            UserDTO testUserData = UserDTO.FromData(UserRoles.YARD_OPERATOR, "Gabriel David", "Medina",
                "gdMedina4", "MusicaSuperDivertida", "La juguetería del Señor Simón.");
            RunAddNewUserTestWithInvalidDataOnDTO(testUserData);
        }

        private static void RunAddNewUserTestWithInvalidDataOnDTO(UserDTO testUserData)
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
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.ExistsUserWithUsername(It.IsAny<string>())).Returns(true);
            var userServices = new UserServices(mockUserRepository.Object);
            userServices.AddNewUserFromData(testingUserData);
        }
        #endregion

        #region GetUserWithUsername tests
        [TestMethod]
        public void UServicesGetUserWithUsernameValidTest()
        {
            UserDTO expectedData = UserDTO.FromUser(testingUser);
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.GetUserByUsername(testingUser.Username)).Returns(testingUser);
            var userServices = new UserServices(mockUserRepository.Object);
            var result = userServices.GetUserByUsername(testingUser.Username);
            mockUserRepository.VerifyAll();
            Assert.AreEqual(expectedData, result);
            Assert.AreNotEqual(testingUser.Password, result.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UServicesGetUserWithUsernameNotFoundInvalidTest()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.GetUserByUsername(It.IsAny<string>()))
                .Throws(new RepositoryException("Message."));
            var userServices = new UserServices(mockUserRepository.Object);
            userServices.GetUserByUsername(testingUser.Username);
        }
        #endregion

        #region ModifyUserWithUsername tests
        [TestMethod]
        public void UServicesModifyUserWithUsernameValidTest()
        {
            User userToModify = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Mario", "Santos",
                "mSantos", "DisculpeFuegoTiene", "099424242");
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.GetUserByUsername(userToModify.Username)).Returns(userToModify);
            var userServices = new UserServices(mockUserRepository.Object);
            userServices.ModifyUserWithUsername(userToModify.Username, testingUserData);
            mockUserRepository.VerifyAll();
            Assert.AreEqual(testingUser.Role, userToModify.Role);
            Assert.AreEqual(testingUser.FirstName, userToModify.FirstName);
            Assert.AreEqual(testingUser.LastName, userToModify.LastName);
            Assert.AreEqual(testingUser.Password, userToModify.Password);
            Assert.AreEqual(testingUser.PhoneNumber, userToModify.PhoneNumber);

            Assert.AreNotEqual(testingUser.Username, userToModify.Username);
            Assert.AreEqual("mSantos", userToModify.Username);
        }

        [TestMethod]
        public void UServicesModifyUserWithUsernameDoesNotModifyUsernameTest()
        {
            User userToModify = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Mario", "Santos",
                "mSantos", "DisculpeFuegoTiene", "099424242");
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.GetUserByUsername(userToModify.Username)).Returns(userToModify);
            var userServices = new UserServices(mockUserRepository.Object);
            var userData = UserDTO.FromUser(testingUser);
            userData.Username = "3* $ @!#$ 72"; // Does not fail with invalid username.
            userServices.ModifyUserWithUsername(userToModify.Username, testingUserData);
            mockUserRepository.VerifyAll();
            Assert.AreNotEqual(testingUser.Username, userToModify.Username);
            Assert.AreEqual("mSantos", userToModify.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UServicesModifyUserWithUsernameInvalidFirstNameTest()
        {
            UserDTO someUserData = UserDTO.FromData(UserRoles.PORT_OPERATOR, "4%# !sf*!@#9",
                "Ravenna", "eRavenna", "HablarUnasPalabritas", "091696969");
            RunModifyUserTestWithInvalidDataOnDTO(someUserData);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UServicesModifyUserWithUsernameInvalidLastNameTest()
        {
            UserDTO someUserData = UserDTO.FromData(UserRoles.PORT_OPERATOR, "Emilio",
                "a#$%s 9 $^!!12", "eRavenna", "HablarUnasPalabritas", "091696969");
            RunModifyUserTestWithInvalidDataOnDTO(someUserData);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UServicesModifyUserWithUsernameInvalidPasswordTest()
        {
            UserDTO someUserData = UserDTO.FromData(UserRoles.PORT_OPERATOR, "Emilio",
                "Ravenna", "eRavenna", " \t\t\n \n\n  ", "091696969");
            RunModifyUserTestWithInvalidDataOnDTO(someUserData);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UServicesModifyUserWithUsernameInvalidPhoneNumberTest()
        {
            UserDTO someUserData = UserDTO.FromData(UserRoles.PORT_OPERATOR, "Emilio",
                "Ravenna", "eRavenna", "eRavenna", "a &#^ 12&$!!/*- ");
            RunModifyUserTestWithInvalidDataOnDTO(someUserData);
        }

        private static void RunModifyUserTestWithInvalidDataOnDTO(UserDTO someUserData)
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.GetUserByUsername(testingUser.Username)).Returns(testingUser);
            var userServices = new UserServices(mockUserRepository.Object);
            userServices.ModifyUserWithUsername(testingUser.Username, someUserData);
        }
        #endregion

        #region RemoveUserWithUsername tests
        [TestMethod]
        public void UServicesRemoveUserWithUsernameValidTest()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.RemoveUserWithUsername(It.IsAny<string>()));
            var userServices = new UserServices(mockUserRepository.Object);
            userServices.RemoveUserWithUsername("mSantos");
            mockUserRepository.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void UServicesRemoveUserWithUnregisteredUsernameInvalidTest()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.RemoveUserWithUsername(It.IsAny<string>()))
                .Throws(new RepositoryException("Message."));
            var userServices = new UserServices(mockUserRepository.Object);
            userServices.RemoveUserWithUsername(null);
        }
        #endregion

        [TestMethod]
        public void UserDTODefaultInternalConstructorTest()
        {
            var defaultUserDTO = new UserDTO();
            Assert.IsNull(defaultUserDTO.Username);
            Assert.IsNull(defaultUserDTO.Password);
            Assert.IsNull(defaultUserDTO.FirstName);
            Assert.IsNull(defaultUserDTO.LastName);
            Assert.IsNull(defaultUserDTO.PhoneNumber);
            Assert.AreEqual(UserRoles.ADMINISTRATOR, defaultUserDTO.Role);
        }

        [TestMethod]
        public void UserDTOEqualsWithDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingUserData, someRandomObject);
        }
    }
}
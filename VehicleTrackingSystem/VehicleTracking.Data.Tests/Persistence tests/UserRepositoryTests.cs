using Domain;
using Persistence;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Data.Persistence_Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UserRepositoryTests
    {
        private string unaddedUsername = "Wololo";
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static IUserRepository testingUserRepository;

        [AssemblyInitialize]
        public static void AssemblySetup(TestContext context)
        {
            testingUnitOfWork.DeleteAllDataFromDatabase();
        }

        [AssemblyCleanup]
        public static void AssemblySetup()
        {
            testingUnitOfWork.DeleteAllDataFromDatabase();
        }

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingUserRepository = testingUnitOfWork.Users;
        }

        [TestMethod]
        public void URepositoryAddNewUserValidTest()
        {
            User userToVerify = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo",
                "Lamponne", "pLamponne1", "NoHaceFaltaSaleSolo", "099212121");
            testingUserRepository.AddNewUser(userToVerify);
            testingUnitOfWork.SaveChanges();
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void URepositoryAddNewUserOnlyUsernamesMatchValidTest()
        {
            User addedUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Mario",
                "Santos", "algunSimuladorDeLos4", "DisculpeFuegoTiene", "099424242");
            User userToVerify = User.InstanceForTestingPurposes();
            userToVerify.Username = "algunSimuladorDeLos4";
            testingUserRepository.AddNewUser(addedUser);
            testingUnitOfWork.SaveChanges();
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void URepositoryAddRepeatedUserValidTest()
        {
            User addedUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "pLamponne4", "NoHaceFaltaSaleSolo", "099212121");
            testingUserRepository.AddNewUser(addedUser);
            testingUnitOfWork.SaveChanges();
            testingUserRepository.AddNewUser(addedUser);
            testingUnitOfWork.SaveChanges();
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), addedUser);
        }

        [TestMethod]
        public void URepositoryAddNewUserRepeatedUsernameValidTest()
        {
            User someUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "repeatedUsername", "NoHaceFaltaSaleSolo", "099212121");
            testingUserRepository.AddNewUser(someUser);
            testingUnitOfWork.SaveChanges();
            User someOtherUser = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Gabriel David",
                "Medina", "repeatedUsername", "MusicaSuperDivertida", "096869689");
            testingUserRepository.AddNewUser(someOtherUser);
            testingUnitOfWork.SaveChanges();
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), someUser);
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), someOtherUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void URepositoryAddNullUserInvalidTest()
        {
            testingUserRepository.AddNewUser(null);
        }

        [TestMethod]
        public void URepositoryRemoveUserValidTest()
        {
            User userToVerify = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Gabriel David",
                "Medina", "gdMedina5", "MusicaSuperDivertida", "096869689");
            testingUserRepository.AddNewUser(userToVerify);
            testingUnitOfWork.SaveChanges();
            testingUserRepository.RemoveUserWithUsername(userToVerify.Username);
            testingUnitOfWork.SaveChanges();
            CollectionAssert.DoesNotContain(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryRemoveUserNotInRepositoryInvalidTest()
        {
            User userToVerify = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Gabriel David",
                "Medina", "gdMedina6", "MusicaSuperDivertida", "096869689");
            testingUserRepository.RemoveUserWithUsername(userToVerify.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryRemoveUserNullUsernameInvalidTest()
        {
            testingUserRepository.RemoveUserWithUsername(null);
        }

        [TestMethod]
        public void URepositoryRemoveAdministratorValidTest()
        {
            User administratorToVerify = User.CreateNewUser(UserRoles.ADMINISTRATOR,
                "Mario", "Santos", "mSantos1", "DisculpeFuegoTiene", "099424242");
            testingUserRepository.AddNewUser(administratorToVerify);
            testingUnitOfWork.SaveChanges();
            User secondAdministrator = User.CreateNewUser(UserRoles.ADMINISTRATOR, "John", "Smith", "hannibal",
                "theresNoPlanBOnlyPlanA", "099111111");
            testingUserRepository.AddNewUser(secondAdministrator);
            testingUnitOfWork.SaveChanges();
            testingUserRepository.RemoveUserWithUsername(administratorToVerify.Username);
            testingUnitOfWork.SaveChanges();
            CollectionAssert.DoesNotContain(testingUserRepository.Elements.ToList(), administratorToVerify);
        }

        [TestMethod]
        public void URepositoryTryToRemoveAllAdministratorsValidTest()
        {
            User someAdministrator = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Mario", "Santos",
                "mSantos2", "DisculpeFuegoTiene", "099424242");
            testingUserRepository.AddNewUser(someAdministrator);
            var administrators = testingUserRepository.Elements.Where(u =>
                u.Role == UserRoles.ADMINISTRATOR).ToList();
            foreach (var administrator in administrators)
            {
                testingUserRepository.RemoveUserWithUsername(administrator.Username);
            }
        }

        [TestMethod]
        public void URepositoryModifyUserValidTest()
        {
            User userToVerify = User.CreateNewUser(UserRoles.YARD_OPERATOR,
                "Algún tipo", "X", "tipo123", "vuelveLaX", "099999999");
            testingUserRepository.AddNewUser(userToVerify);
            testingUnitOfWork.SaveChanges();
            SetUserData(userToVerify, UserRoles.PORT_OPERATOR, "Gabriel David",
                "Medina", "MúsicaSuperDivertida", "096869689");
            testingUserRepository.UpdateUser(userToVerify);
            testingUnitOfWork.SaveChanges();
            Assert.AreEqual(UserRoles.PORT_OPERATOR, userToVerify.Role);
            Assert.AreEqual("Gabriel David", userToVerify.FirstName);
            Assert.AreEqual("Medina", userToVerify.LastName);
            Assert.AreEqual("MúsicaSuperDivertida", userToVerify.Password);
            Assert.AreEqual("096869689", userToVerify.PhoneNumber);
        }

        [TestMethod]
        public void URepositoryModifyUserSetSameDataValidTest()
        {
            User userToVerify = User.CreateNewUser(UserRoles.YARD_OPERATOR,
                "Algún tipo", "X", "algunUsuario", "vuelveLaX", "099999999");
            testingUserRepository.AddNewUser(userToVerify);
            testingUnitOfWork.SaveChanges();
            var previousRole = userToVerify.Role;
            var previousFirstName = userToVerify.FirstName;
            var previousLastName = userToVerify.LastName;
            var previousUsername = userToVerify.Username;
            var previousPassword = userToVerify.Password;
            var previousPhoneNumber = userToVerify.PhoneNumber;
            SetUserData(userToVerify, previousRole, previousFirstName,
                previousLastName, previousPassword, previousPhoneNumber);
            Assert.AreEqual(previousRole, userToVerify.Role);
            Assert.AreEqual(previousFirstName, userToVerify.FirstName);
            Assert.AreEqual(previousLastName, userToVerify.LastName);
            Assert.AreEqual(previousUsername, userToVerify.Username);
            Assert.AreEqual(previousPassword, userToVerify.Password);
            Assert.AreEqual(previousPhoneNumber, userToVerify.PhoneNumber);
        }

        private void SetUserData(User userToVerify, UserRoles roleToSet, string firstNameToSet,
            string lastNameToSet, string passwordToSet, string phoneNumberToSet)
        {
            userToVerify.Role = roleToSet;
            userToVerify.FirstName = firstNameToSet;
            userToVerify.LastName = lastNameToSet;
            userToVerify.Password = passwordToSet;
            userToVerify.PhoneNumber = phoneNumberToSet;
            testingUserRepository.UpdateUser(userToVerify);
            testingUnitOfWork.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryModifyNullUserInvalidTest()
        {
            testingUserRepository.UpdateUser(null);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryModifyNotAddedUserInvalidTest()
        {
            User notAddedUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo",
                "Lamponne", "pLamponne5", "NoHaceFaltaSaleSolo", "099212121");
            testingUserRepository.UpdateUser(notAddedUser);
            testingUnitOfWork.SaveChanges();
        }

        [TestMethod]
        public void URepositoryGetUserByUsernameValidTest()
        {
            User addedUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Mario",
                "Santos", "mSantos42", "DisculpeFuegoTiene", "099424242");
            testingUserRepository.AddNewUser(addedUser);
            testingUnitOfWork.SaveChanges();
            User result = testingUserRepository.GetUserWithUsername("mSantos42");
            Assert.AreEqual(addedUser, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryGetUserByUnaddedUsernameInvalidTest()
        {
            testingUserRepository.GetUserWithUsername(unaddedUsername);
        }

        [TestMethod]
        public void URepositoryExistsUserWithUsernameAddedTest()
        {
            User userToVerify = testingUserRepository.Elements.First();
            bool result = testingUserRepository.ExistsUserWithUsername(
                userToVerify.Username);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void URepositoryExistsUserWithUsernameUnaddedTest()
        {
            bool result = testingUserRepository.ExistsUserWithUsername(
                unaddedUsername);
            Assert.IsFalse(result);
        }
    }
}
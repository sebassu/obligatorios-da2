using Domain;
using Persistence;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence_Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UserRepositoryTests
    {
        private static UserRepository testingUserRepository;

        [AssemblyInitialize]
        public static void AssemblySetup(TestContext context)
        {
            DeleteAllDatabaseData();
        }

        [AssemblyCleanup]
        public static void AssemblySetup()
        {
            DeleteAllDatabaseData();
        }

        private static void DeleteAllDatabaseData()
        {
            using (var context = new VTSystemContext())
            {
                context.DeleteAllData();
            }
        }

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingUserRepository = new UserRepository();
        }

        [TestMethod]
        public void URepositoryAddNewUserValidTest()
        {
            User userToVerify = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo",
                "Lamponne", "pLamponne1", "NoHaceFaltaSaleSolo", "099212121");
            testingUserRepository.AddNewUser(userToVerify);
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
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddRepeatedUserInvalidTest()
        {
            User addedUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "pLamponne4", "NoHaceFaltaSaleSolo", "099212121");
            testingUserRepository.AddNewUser(addedUser);
            testingUserRepository.AddNewUser(addedUser);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddNewUserRepeatedUsernameInvalidTest()
        {
            User someUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "repeatedUsername", "NoHaceFaltaSaleSolo", "099212121");
            User someOtherUser = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Gabriel David",
                "Medina", "repeatedUsername", "MusicaSuperDivertida", "096869689");
            testingUserRepository.AddNewUser(someUser);
            testingUserRepository.AddNewUser(someOtherUser);
        }

        [TestMethod]
        public void URepositoryRemoveUserValidTest()
        {
            User userToVerify = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Gabriel David",
                "Medina", "gdMedina5", "MusicaSuperDivertida", "096869689");
            testingUserRepository.AddNewUser(userToVerify);
            testingUserRepository.Remove(userToVerify.Username);
            CollectionAssert.DoesNotContain(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryRemoveUserNotInRepositoryInvalidTest()
        {
            User userToVerify = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Gabriel David",
                "Medina", "gdMedina6", "MusicaSuperDivertida", "096869689");
            testingUserRepository.Remove(userToVerify.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryRemoveUserNullUsernameInvalidTest()
        {
            testingUserRepository.Remove(null);
        }

        [TestMethod]
        public void URepositoryRemoveAdministratorValidTest()
        {
            User administratorToVerify = User.CreateNewUser(UserRoles.ADMINISTRATOR,
                "Mario", "Santos", "mSantos1", "DisculpeFuegoTiene", "099424242");
            testingUserRepository.AddNewUser(administratorToVerify);
            User secondAdministrator = User.CreateNewUser(UserRoles.ADMINISTRATOR, "John", "Smith", "hannibal",
                "theresNoPlanBOnlyPlanA", "099111111");
            testingUserRepository.AddNewUser(secondAdministrator);
            testingUserRepository.Remove(administratorToVerify.Username);
            CollectionAssert.DoesNotContain(testingUserRepository.Elements.ToList(), administratorToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryTryToRemoveAllAdministratorsInvalidTest()
        {
            User someAdministrator = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Mario", "Santos",
                "mSantos2", "DisculpeFuegoTiene", "099424242");
            testingUserRepository.AddNewUser(someAdministrator);
            var administrators = testingUserRepository.Elements.Where(u =>
                u.Role == UserRoles.ADMINISTRATOR).ToList();
            foreach (var administrator in administrators)
            {
                testingUserRepository.Remove(administrator.Username);
            }
        }

        [TestMethod]
        public void URepositoryModifyUserValidTest()
        {
            User userToVerify = User.CreateNewUser(UserRoles.YARD_OPERATOR,
                "Algún tipo", "X", "tipo123", "vuelveLaX", "099999999");
            testingUserRepository.AddNewUser(userToVerify);
            SetUserData(userToVerify, UserRoles.PORT_OPERATOR, "Gabriel David",
                "Medina", "MúsicaSuperDivertida", "096869689");
            testingUserRepository.UpdateUser(userToVerify);
            Assert.AreEqual(UserRoles.PORT_OPERATOR, userToVerify.Role);
            Assert.AreEqual("Gabriel David", userToVerify.FirstName);
            Assert.AreEqual("Medina", userToVerify.LastName);
            Assert.AreEqual("MúsicaSuperDivertida", userToVerify.Password);
            Assert.AreEqual("096869689", userToVerify.PhoneNumber);
        }

        [TestMethod]
        public void URepositoryModifyUserSetSameDataValidTest()
        {
            User userToVerify = testingUserRepository.Elements.First();
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
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryModifyUsernameInvalidTest()
        {
            User userToModify = User.CreateNewUser(UserRoles.PORT_OPERATOR, "Gabriel David",
                "Medina", "gdMedina9", "MúsicaSuperDivertida", "096869689");
            testingUserRepository.AddNewUser(userToModify);
            userToModify.Username = "algunUsuarioNuevo";
            testingUserRepository.UpdateUser(userToModify);
        }

        [TestMethod]
        public void URepositoryGetUserByUsernameValidTest()
        {
            User addedUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Mario",
                "Santos", "mSantos42", "DisculpeFuegoTiene", "099424242");
            testingUserRepository.AddNewUser(addedUser);
            User result = testingUserRepository.GetUserByUsername("mSantos42");
            Assert.AreEqual(addedUser, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryGetUserByUnaddedUsernameInvalidTest()
        {
            testingUserRepository.GetUserByUsername("Wololo");
        }
    }
}
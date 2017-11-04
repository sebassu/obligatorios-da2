using Domain;
using Persistence;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UserRepositoryTests
    {
        private string unaddedUsername = "Wololo";
        private static readonly UnitOfWork testingUnitOfWork = new UnitOfWork();
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
            Assert.IsNotNull(testingUserRepository);
        }

        [TestMethod]
        public void URepositoryAddNewUserValidTest()
        {
            User userToVerify = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo",
                "Lamponne", "pLamponne1", "NoHaceFaltaSaleSolo", "099212121");
            AddNewUserAndSaveChanges(userToVerify);
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void URepositoryAddNewUserOnlyUsernamesMatchValidTest()
        {
            User addedUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Mario",
                "Santos", "algunSimuladorDeLos4", "DisculpeFuegoTiene", "099424242");
            User userToVerify = User.InstanceForTestingPurposes();
            userToVerify.Username = "algunSimuladorDeLos4";
            AddNewUserAndSaveChanges(addedUser);
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void URepositoryAddRepeatedUserValidTest()
        {
            User addedUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "pLamponne4", "NoHaceFaltaSaleSolo", "099212121");
            AddNewUserAndSaveChanges(addedUser);
            AddNewUserAndSaveChanges(addedUser);
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), addedUser);
        }

        [TestMethod]
        public void URepositoryAddNewUserRepeatedUsernameValidTest()
        {
            User someUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "repeatedUsername", "NoHaceFaltaSaleSolo", "099212121");
            AddNewUserAndSaveChanges(someUser);
            User someOtherUser = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Gabriel David",
                "Medina", "repeatedUsername", "MusicaSuperDivertida", "096869689");
            AddNewUserAndSaveChanges(someOtherUser);
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), someUser);
            CollectionAssert.Contains(testingUserRepository.Elements.ToList(), someOtherUser);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddNullUserInvalidTest()
        {
            AddNewUserAndSaveChanges(null);
        }

        [TestMethod]
        public void URepositoryRemoveUserValidTest()
        {
            User userToVerify = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Gabriel David",
                "Medina", "gdMedina5", "MusicaSuperDivertida", "096869689");
            AddNewUserAndSaveChanges(userToVerify);
            RemoveUserWithUsernameAndSaveChanges(userToVerify.Username);
            CollectionAssert.DoesNotContain(testingUserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryRemoveUserNotInRepositoryInvalidTest()
        {
            User userToVerify = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Gabriel David",
                "Medina", "gdMedina6", "MusicaSuperDivertida", "096869689");
            RemoveUserWithUsernameAndSaveChanges(userToVerify.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryRemoveUserNullUsernameInvalidTest()
        {
            RemoveUserWithUsernameAndSaveChanges(null);
        }

        [TestMethod]
        public void URepositoryUsernameBelongsToLastAdministratorMultipleValidTest()
        {
            User oneAdministrator = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Mario", "Santos",
                "mSantos2", "DisculpeFuegoTiene", "099424242");
            User secondAdministrator = User.CreateNewUser(UserRoles.ADMINISTRATOR, "John",
                "Smith", "hannibal", "theresNoPlanBOnlyPlanA", "099111111");
            AddNewUserAndSaveChanges(oneAdministrator);
            AddNewUserAndSaveChanges(secondAdministrator);
            Assert.IsFalse(testingUserRepository.UsernameBelongsToLastAdministrator("mSantos2"));
        }

        [TestMethod]
        public void URepositoryUsernameBelongsToLastAdministratorNonAdministratorValidTest()
        {
            User nonAdministrator = User.CreateNewUser(UserRoles.YARD_OPERATOR, "Gabriel David",
                "Medina", "gdMedina66", "MusicaSuperDivertida", "096869689");
            AddNewUserAndSaveChanges(nonAdministrator);
            Assert.IsFalse(testingUserRepository.UsernameBelongsToLastAdministrator("gdMedina66"));
        }

        [TestMethod]
        public void URepositoryUsernameBelongsToLastAdministratorUnaddedUsernameValidTest()
        {
            Assert.IsFalse(testingUserRepository.UsernameBelongsToLastAdministrator("marcosMundstock"));
        }

        [TestMethod]
        public void URepositoryUsernameBelongsToLastAdministratorValidTest()
        {
            RemoveAllAdministrators();
            User administrator = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Mario", "Santos",
                "mSantos", "DisculpeFuegoTiene", "099424242");
            AddNewUserAndSaveChanges(administrator);
            Assert.IsTrue(testingUserRepository.UsernameBelongsToLastAdministrator("mSantos"));
        }

        private static void RemoveAllAdministrators()
        {
            var administrators = testingUserRepository.Elements.Where(u =>
                u.Role == UserRoles.ADMINISTRATOR).Distinct().ToList();
            foreach (var administrator in administrators)
            {
                RemoveUserWithUsernameAndSaveChanges(administrator.Username);
            }
        }

        [TestMethod]
        public void URepositoryModifyUserValidTest()
        {
            User userToVerify = User.CreateNewUser(UserRoles.YARD_OPERATOR,
                "Algún tipo", "X", "tipo123", "vuelveLaX", "099999999");
            AddNewUserAndSaveChanges(userToVerify);
            SetUserData(userToVerify, UserRoles.PORT_OPERATOR, "Gabriel David",
                "Medina", "MúsicaSuperDivertida", "096869689");
            UpdateUserAndSaveChanges(userToVerify);
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

        private void SetUserData(User userToModify, UserRoles roleToSet, string firstNameToSet,
            string lastNameToSet, string passwordToSet, string phoneNumberToSet)
        {
            userToModify.Role = roleToSet;
            userToModify.FirstName = firstNameToSet;
            userToModify.LastName = lastNameToSet;
            userToModify.Password = passwordToSet;
            userToModify.PhoneNumber = phoneNumberToSet;
            UpdateUserAndSaveChanges(userToModify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryModifyNullUserInvalidTest()
        {
            UpdateUserAndSaveChanges(null);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryModifyNotAddedUserInvalidTest()
        {
            User notAddedUser = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo",
                "Lamponne", "pLamponne5", "NoHaceFaltaSaleSolo", "099212121");
            UpdateUserAndSaveChanges(notAddedUser);
        }

        [TestMethod]
        public void URepositoryGetUserByUsernameValidTest()
        {
            User addedUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Mario",
                "Santos", "mSantos42", "DisculpeFuegoTiene", "099424242");
            AddNewUserAndSaveChanges(addedUser);
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

        private static void AddNewUserAndSaveChanges(User userToAdd)
        {
            testingUnitOfWork.Users.AddNewUser(userToAdd);
            testingUnitOfWork.SaveChanges();
        }


        private static void UpdateUserAndSaveChanges(User userToModify)
        {
            testingUserRepository.UpdateUser(userToModify);
            testingUnitOfWork.SaveChanges();
        }

        private static void RemoveUserWithUsernameAndSaveChanges(string usernameToRemove)
        {
            testingUserRepository.RemoveUserWithUsername(usernameToRemove);
            testingUnitOfWork.SaveChanges();
        }
    }
}
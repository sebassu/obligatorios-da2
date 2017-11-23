using API.Services;
using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WinApp.Services_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SessionServicesTests
    {
        private static IUnitOfWork testingUnitOfWork = new UnitOfWork();

        [TestMethod]
        public void LogInSuccessfullyTest()
        {
            User administrator = User.CreateNewUser(UserRoles.ADMINISTRATOR,
                "Juan", "Perez", "jPerez", "Juancito", "099424242");
            AddNewUserAndSaveChanges(administrator);
            Assert.IsTrue(SessionServices.LogIn("jPerez", "Juancito"));
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void CannotLogInWrongUsernameTest()
        {
            SessionServices.LogIn("SomeUsername", "Victory");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void CannotLogInWrongPasswordTest()
        {
            SessionServices.LogIn("theAdministrator", "WrongPassword");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void CannotLogInWrongUserRoleTest()
        {
            User transporter = User.CreateNewUser(UserRoles.TRANSPORTER, "Maria",
                "Gonzalez", "mGonzalez", "mGonzalez123", "099424242");
            AddNewUserAndSaveChanges(transporter);
            SessionServices.LogIn("mGonzalez", "mGonzalez123");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void TestNoMailEntered()
        {
            SessionServices.LogIn("", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void TestNoPasswordEntered()
        {
            SessionServices.LogIn("theAdministrator", "");
        }

        private static void AddNewUserAndSaveChanges(User userToAdd)
        {
            testingUnitOfWork.Users.AddNewUser(userToAdd);
            testingUnitOfWork.SaveChanges();
        }
    }
}
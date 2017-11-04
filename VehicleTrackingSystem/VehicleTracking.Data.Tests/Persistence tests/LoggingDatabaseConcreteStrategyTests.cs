using Domain;
using System.Linq;
using Persistence;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence_tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LoggingDatabaseConcreteStrategyTests
    {
        private static readonly IUnitOfWork testingUnitOfWork = new UnitOfWork();
        private static ILoggingStrategy testingStrategy;
        private static User testingResponsible;

        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            testingStrategy = testingUnitOfWork.LoggingStrategy;
            Assert.IsNotNull(testingStrategy);
            testingResponsible = testingUnitOfWork.Users
                .Elements.First(u => u.Role == UserRoles.ADMINISTRATOR);
        }

        [TestMethod]
        public void LDCStrategyRegisterUserLoginWithAdministratorValidTest()
        {
            var logProduced = testingStrategy.RegisterUserLogin(testingResponsible);
            testingUnitOfWork.SaveChanges();
            CollectionAssert.Contains(testingStrategy.Log.ToList(), logProduced);
        }

        [TestMethod]
        public void LDCStrategyRegisterUserLoginWithNonAdministratorValidTest()
        {
            User someOtherUser = User.InstanceForTestingPurposes();
            someOtherUser.Role = UserRoles.SALESMAN;
            var logProduced = testingStrategy.RegisterUserLogin(someOtherUser);
            testingUnitOfWork.SaveChanges();
            CollectionAssert.Contains(testingStrategy.Log.ToList(), logProduced);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LDCStrategyRegisterNullUserLoginInvalidTest()
        {
            testingStrategy.RegisterUserLogin(null);
        }

        [TestMethod]
        public void LDCStrategyRegisterVehicleImportValidTest()
        {
            var logProduced = testingStrategy.RegisterVehicleImport(testingResponsible);
            testingUnitOfWork.SaveChanges();
            CollectionAssert.Contains(testingStrategy.Log.ToList(), logProduced);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LDCStrategyRegisterVehicleImportWithNonAdministratorInvalidTest()
        {
            User someOtherUser = User.InstanceForTestingPurposes();
            someOtherUser.Role = UserRoles.SALESMAN;
            testingStrategy.RegisterVehicleImport(someOtherUser);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggingException))]
        public void LDCStrategyRegisterNullUserForVehicleImportInvalidTest()
        {
            testingStrategy.RegisterVehicleImport(null);
        }
    }
}
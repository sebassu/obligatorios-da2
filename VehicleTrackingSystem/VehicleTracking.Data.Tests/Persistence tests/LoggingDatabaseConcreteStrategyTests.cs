using Domain;
using System.Linq;
using Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence_tests
{
    [TestClass]
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
    }
}
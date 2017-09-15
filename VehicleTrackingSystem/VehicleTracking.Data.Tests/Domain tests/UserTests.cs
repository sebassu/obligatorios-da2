using Domain;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UserTests
    {
        private static User testingUser;

        [TestInitialize]
        public void TestSetup()
        {
            testingUser = User.InstanceForTestingPurposes();
        }

        [TestMethod]
        public void UserForTestingPurposesTest()
        {
            Assert.AreEqual("Usuario", testingUser.FirstName);
        }

        [TestMethod]
        public void UserSetValidFirstNameTest()
        {
            testingUser.FirstName = "Mario";
            Assert.AreEqual("Mario", testingUser.FirstName);
        }

        [TestMethod]
        public void UserSetValidFirstNameCompoundTest()
        {
            testingUser.FirstName = "  Juan Martín  ";
            Assert.AreEqual("Juan Martín", testingUser.FirstName);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidFirstNameNumbersTest()
        {
            testingUser.FirstName = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidFirstNamePunctuationTest()
        {
            testingUser.FirstName = "!@.$#% *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidFirstNameOnlySpacesTest()
        {
            testingUser.FirstName = " \n\n  \t\t \n\t  ";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidFirstNameEmptyTest()
        {
            testingUser.FirstName = "";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidFirstNameNullTest()
        {
            testingUser.FirstName = null;
        }
    }
}

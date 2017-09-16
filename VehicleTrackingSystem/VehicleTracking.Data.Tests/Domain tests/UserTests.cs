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
            Assert.AreEqual("inválido.", testingUser.LastName);
            Assert.AreEqual("usuarioinválido", testingUser.Username);
            Assert.AreEqual("Contraseña inválida.", testingUser.Password);
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

        [TestMethod]
        public void UserSetValidLastNameTest()
        {
            testingUser.LastName = "Santos";
            Assert.AreEqual("Santos", testingUser.LastName);
        }

        [TestMethod]
        public void UserSetValidLastNameCompoundTest()
        {
            testingUser.LastName = "  García Morales  ";
            Assert.AreEqual("García Morales", testingUser.LastName);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidLastNameNumbersTest()
        {
            testingUser.LastName = "5678";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidLastNamePunctuationTest()
        {
            testingUser.LastName = "!@.$#% *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidLastNameOnlySpacesTest()
        {
            testingUser.FirstName = " \n\n  \t\t \n\t  ";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidLastNameEmptyTest()
        {
            testingUser.LastName = "";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidLastNameNullTest()
        {
            testingUser.LastName = null;
        }

        [TestMethod]
        public void UserSetValidUsernameTest()
        {
            testingUser.Username = "msantos";
            Assert.AreEqual("msantos", testingUser.Username);
        }

        [TestMethod]
        public void UserSetValidUsernameWithNumbersTest()
        {
            testingUser.Username = "msantos42";
            Assert.AreEqual("msantos42", testingUser.Username);
        }

        [TestMethod]
        public void UserSetValidUsernameNumbersTest()
        {
            testingUser.Username = "5218048";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidUsernameCompoundTest()
        {
            testingUser.Username = " msantos 42 ";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidUsernamePunctuationTest()
        {
            testingUser.Username = "!@.$#% *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidUsernameOnlySpacesTest()
        {
            testingUser.Username = " \n\n  \t\t \n\t  ";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidUsernameEmptyTest()
        {
            testingUser.Username = "";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidUsernameNullTest()
        {
            testingUser.Username = null;
        }

        [TestMethod]
        public void UserSetValidPasswordTest()
        {
            testingUser.Password = "pS8a11";
            Assert.AreEqual("pS8a11", testingUser.Password);
        }

        [TestMethod]
        public void UserSetValidPasswordNoLettersTest()
        {
            testingUser.Password = "123456789";
            Assert.AreEqual("123456789", testingUser.Password);
        }

        [TestMethod]
        public void UserSetValidPasswordNoNumbersTest()
        {
            testingUser.Password = "habitualEspacio";
            Assert.AreEqual("habitualEspacio", testingUser.Password);
        }

        [TestMethod]
        public void UserSetValidPasswordPunctuationTest()
        {
            testingUser.Password = "/*- #$%- ))";
            Assert.AreEqual("/*- #$%- ))", testingUser.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidPasswordEmptyTest()
        {
            testingUser.Password = "";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidPasswordNullTest()
        {
            testingUser.Password = null;
        }

        [TestMethod]
        public void UserSetValidPhoneNumberTest()
        {
            testingUser.PhoneNumber = "22032352";
            Assert.AreEqual("22032352", testingUser.PhoneNumber);
        }

        [TestMethod]
        public void UserSetValidPhoneNumberStartingWith0Test()
        {
            testingUser.PhoneNumber = "091946954";
            Assert.AreEqual("091946954", testingUser.PhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidPhoneNumberStartingWithDouble0Test()
        {
            testingUser.PhoneNumber = "00123456";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidPhoneNumberLettersTest()
        {
            testingUser.PhoneNumber = "Hola123456";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidPhoneNumberTooLongTest()
        {
            testingUser.PhoneNumber = "1234567891234679";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidPhoneNumberEmptyTest()
        {
            testingUser.Username = "";
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserSetInvalidPhoneNumberNullTest()
        {
            testingUser.PhoneNumber = null;
        }

        [TestMethod]
        public void UserParameterFactoryMethodValidTest()
        {
            testingUser = User.CreateNewUser(UserRoles.PORT_OPERATOR, "Emilio", "Ravenna",
                "emravenna", "contraseñaVálida123", "099212121");
            Assert.AreEqual(0, testingUser.Id);
            Assert.AreEqual(UserRoles.PORT_OPERATOR, testingUser.Role);
            Assert.AreEqual("Emilio", testingUser.FirstName);
            Assert.AreEqual("Ravenna", testingUser.LastName);
            Assert.AreEqual("emravenna", testingUser.Username);
            Assert.AreEqual("contraseñaVálida123", testingUser.Password);
            Assert.AreEqual("099212121", testingUser.PhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserParameterFactoryMethodInvalidFirstNameTest()
        {
            testingUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "1&6 1a2-*!3", "Ravenna",
                "emravenna", "contraseñaVálida123", "099212121");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserParameterFactoryMethodInvalidLastNameTest()
        {
            testingUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Emilio", ";#d1 -($!#",
                "emravenna", "contraseñaVálida123", "099212121");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserParameterFactoryMethodInvalidUsernameTest()
        {
            testingUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Emilio", "Ravenna",
                "12! $^#&", "contraseñaVálida123", "099212121");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserParameterFactoryMethodInvalidPasswordTest()
        {
            testingUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Emilio", "Ravenna",
                "emravenna", "", "099212121");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserParameterFactoryMethodInvalidPhoneNumberTest()
        {
            testingUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Emilio", "Ravenna",
                "emravenna", "contraseñaVálida123", "0A# .0!&1-2");
        }
    }
}

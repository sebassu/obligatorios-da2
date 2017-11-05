using VehicleTracking_Data_Entities;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Domain_tests
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
        public void UserInstanceForTestingPurposesTest()
        {
            Assert.AreEqual(UserRoles.ADMINISTRATOR, testingUser.Role);
            Assert.AreEqual("Usuario", testingUser.FirstName);
            Assert.AreEqual("inválido", testingUser.LastName);
            Assert.AreEqual("usuarioinválido", testingUser.Username);
            Assert.AreEqual("Contraseña inválida.", testingUser.Password);
            Assert.AreEqual("099424242", testingUser.PhoneNumber);
        }

        [TestMethod]
        public void UserSetIdValidTest()
        {
            testingUser.Id = 42;
            Assert.AreEqual(42, testingUser.Id);
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
        public void UserSetValidUsernameOnlyNumbersTest()
        {
            testingUser.Username = "5218048";
            Assert.AreEqual("5218048", testingUser.Username);
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
            User.CreateNewUser(UserRoles.ADMINISTRATOR, "1&6 1a2-*!3", "Ravenna",
                "emravenna", "contraseñaVálida123", "099212121");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserParameterFactoryMethodInvalidLastNameTest()
        {
            User.CreateNewUser(UserRoles.ADMINISTRATOR, "Emilio", ";#d1 -($!#",
                "emravenna", "contraseñaVálida123", "099212121");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserParameterFactoryMethodInvalidUsernameTest()
        {
            User.CreateNewUser(UserRoles.ADMINISTRATOR, "Emilio", "Ravenna",
                "12! $^#&", "contraseñaVálida123", "099212121");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserParameterFactoryMethodInvalidPasswordTest()
        {
            User.CreateNewUser(UserRoles.ADMINISTRATOR, "Emilio", "Ravenna",
                "emravenna", "", "099212121");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void UserParameterFactoryMethodInvalidPhoneNumberTest()
        {
            User.CreateNewUser(UserRoles.ADMINISTRATOR, "Emilio", "Ravenna",
                "emravenna", "contraseñaVálida123", "0A# .0!&1-2");
        }

        [TestMethod]
        public void UserEqualsReflexiveTest()
        {
            Assert.AreEqual(testingUser, testingUser);
        }

        [TestMethod]
        public void UserEqualsSymmetricTest()
        {
            User secondTestingUser = User.InstanceForTestingPurposes();
            Assert.AreEqual(testingUser, secondTestingUser);
            Assert.AreEqual(secondTestingUser, testingUser);
        }

        [TestMethod]
        public void UserEqualsTransitiveTest()
        {
            testingUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "A", "B",
                "sameUsername", "Password1", "22003695");
            User secondTestingUser = User.CreateNewUser(UserRoles.PORT_OPERATOR, "C", "D",
                "sameUsername", "Password2", "26927852");
            User thirdTestingUser = User.CreateNewUser(UserRoles.TRANSPORTER, "E", "F",
                "sameUsername", "Password4", "43651245");
            Assert.AreEqual(testingUser, secondTestingUser);
            Assert.AreEqual(secondTestingUser, thirdTestingUser);
            Assert.AreEqual(testingUser, thirdTestingUser);
        }

        [TestMethod]
        public void UserEqualsDifferentUsersTest()
        {
            testingUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Same first name",
                "Same last name", "differentUsernames0", "SamePassword0", "22001223");
            User secondTestingUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Same first name",
                "Same last name", "seeTheyAreDifferent0", "SamePassword0", "22001223");
            Assert.AreNotEqual(testingUser, secondTestingUser);
        }

        [TestMethod]
        public void UserEqualsNullTest()
        {
            Assert.AreNotEqual(testingUser, null);
        }

        [TestMethod]
        public void UserEqualsDifferentTypesTest()
        {
            object someRandomObject = new object();
            Assert.AreNotEqual(testingUser, someRandomObject);
        }

        [TestMethod]
        public void UserGetHashCodeTest()
        {
            object testingUserAsObject = testingUser;
            Assert.AreEqual(testingUserAsObject.GetHashCode(), testingUser.GetHashCode());
        }

        [TestMethod]
        public void UserToStringTest1()
        {
            Assert.AreEqual("Usuario inválido <usuarioinválido>",
                testingUser.ToString());
        }

        [TestMethod]
        public void UserToStringTest2()
        {
            testingUser.FirstName = "Mario";
            testingUser.LastName = "Santos";
            testingUser.Username = "msantos";
            Assert.AreEqual("Mario Santos <msantos>", testingUser.ToString());
        }

        [TestMethod]
        public void UserToStringTest3()
        {
            testingUser.FirstName = "Gabriel";
            testingUser.LastName = "Medina";
            testingUser.Username = "gmedina";
            Assert.AreEqual(testingUser.FirstName + " " + testingUser.LastName + " <"
                + testingUser.Username + ">", testingUser.ToString());
        }
    }
}
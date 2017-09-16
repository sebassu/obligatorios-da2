using Domain;
using Persistence;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Persistence.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UserRepositoryTests
    {
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

        [TestMethod]
        public void URepositoryAddNewUserValidTest()
        {
            User userToVerify = User.CreateNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "pLamponne1", "NoHaceFaltaSaleSolo", "099212121");
            UserRepository.AddNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "pLamponne1", "NoHaceFaltaSaleSolo", "099212121");
            CollectionAssert.Contains(UserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        public void URepositoryAddNewUserReturnsAddedUserValidTest()
        {
            User addedUser = UserRepository.AddNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "pLamponne2", "NoHaceFaltaSaleSolo", "099212121");
            CollectionAssert.Contains(UserRepository.Elements.ToList(), addedUser);
        }

        [TestMethod]
        public void URepositoryAddNewUserOnlyUsernamesMatchValidTest()
        {
            User userToVerify = User.InstanceForTestingPurposes();
            userToVerify.Username = "pLamponne3";
            UserRepository.AddNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "pLamponne3", "NoHaceFaltaSaleSolo", "099212121");
            CollectionAssert.Contains(UserRepository.Elements.ToList(), userToVerify);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddRepeatedUserInvalidTest()
        {
            UserRepository.AddNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "pLamponne4", "NoHaceFaltaSaleSolo", "099212121");
            UserRepository.AddNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "pLamponne4", "NoHaceFaltaSaleSolo", "099212121");
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void URepositoryAddNewUserRepeatedMailInvalidTest()
        {
            UserRepository.AddNewUser(UserRoles.TRANSPORTER, "Pablo", "Lamponne",
                "repeatedUsername", "NoHaceFaltaSaleSolo", "099212121");
            UserRepository.AddNewUser(UserRoles.YARD_OPERATOR, "Gabriel David", "Medina",
                "repeatedUsername", "MusicaSuperDivertida", "096869689");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidFirstNameTest()
        {
            UserRepository.AddNewUser(UserRoles.YARD_OPERATOR, "1d2@#!9 #(", "Medina",
                "gdMedina1", "MusicaSuperDivertida", "096869689");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidLastNameTest()
        {
            UserRepository.AddNewUser(UserRoles.YARD_OPERATOR, "Gabriel David", "*$ 563a%7*//*0&d!@",
                "gdMedina2", "MusicaSuperDivertida", "096869689");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidUsernameTest()
        {
            UserRepository.AddNewUser(UserRoles.YARD_OPERATOR, "Gabriel David", "Medina",
                "Ceci n'est pas un nom d'utilisateur.", "MusicaSuperDivertida", "096869689");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidPasswordTest()
        {
            UserRepository.AddNewUser(UserRoles.YARD_OPERATOR, "Gabriel David", "Medina",
                "gdMedina3", "  \n \t \t\t\n ", "096869689");
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public void URepositoryAddNewUserInvalidPhoneNumberTest()
        {
            UserRepository.AddNewUser(UserRoles.YARD_OPERATOR, "Gabriel David", "Medina",
                "gdMedina4", "MusicaSuperDivertida", "La juguetería del Señor Simón.");
        }
    }
}
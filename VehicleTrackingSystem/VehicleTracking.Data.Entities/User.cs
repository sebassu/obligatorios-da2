using System.Resources;
using System.Globalization;
using System.Runtime.CompilerServices;

[assembly: NeutralResourcesLanguage("es")]
[assembly: InternalsVisibleTo("VehicleTracking.Data.Tests")]
[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Tests")]
namespace Domain
{
    public enum UserRoles
    {
        ADMINISTRATOR, PORT_OPERATOR, TRANSPORTER,
        YARD_OPERATOR, SALESMAN
    }

    public class User
    {
        public int Id { get; set; }

        public bool WasRemoved { get; set; }

        public UserRoles Role { get; set; } = UserRoles.ADMINISTRATOR;

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (IsValidName(value))
                {
                    firstName = value.Trim();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.NameIsInvalid, "Nombre", value);
                    throw new UserException(errorMessage);
                }
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (IsValidName(value))
                {
                    lastName = value.Trim();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.NameIsInvalid, "Apellido", value);
                    throw new UserException(errorMessage);
                }
            }
        }

        protected bool IsValidName(string value)
        {
            return Utilities.ContainsLettersOrSpacesOnly(value);
        }

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                if (IsValidUsername(value))
                {
                    username = value.Trim();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.UsernameIsInvalid, value);
                    throw new UserException(errorMessage);
                }
            }
        }

        internal static bool IsValidUsername(string value)
        {
            return Utilities.ContainsLettersOrDigitsOnly(value);
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (IsValidPassword(value))
                {
                    password = value;
                }
                else
                {
                    throw new UserException(ErrorMessages.PasswordIsInvalid);
                }
            }
        }

        protected bool IsValidPassword(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (IsValidPhoneNumber(value))
                {
                    phoneNumber = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.PhoneNumberIsInvalid, value);
                    throw new UserException(errorMessage);
                }
            }
        }

        protected bool IsValidPhoneNumber(string value)
        {
            return Utilities.HasValidPhoneFormat(value);
        }

        internal static User InstanceForTestingPurposes()
        {
            return new User();
        }

        protected User()
        {
            firstName = "Usuario";
            lastName = "inválido";
            username = "usuarioinválido";
            password = "Contraseña inválida.";
            phoneNumber = "099424242";
        }

        public static User CreateNewUser(UserRoles role, string firstName, string lastName,
            string username, string password, string phoneNumber)
        {
            return new User(role, firstName, lastName, username, password, phoneNumber);
        }

        protected User(UserRoles roleToSet, string firstNameToSet, string lastNameToSet,
            string usernameToSet, string passwordToSet, string phoneNumberToSet)
        {
            Role = roleToSet;
            FirstName = firstNameToSet;
            LastName = lastNameToSet;
            Username = usernameToSet;
            Password = passwordToSet;
            PhoneNumber = phoneNumberToSet;
        }

        public override bool Equals(object obj)
        {
            User userToCompareAgainst = obj as User;
            if (Utilities.IsNotNull(userToCompareAgainst))
            {
                return username.Equals(userToCompareAgainst.username);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " <" + username + ">";
        }
    }
}
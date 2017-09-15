using System.Resources;
using System.Globalization;
using System.Runtime.CompilerServices;

[assembly: NeutralResourcesLanguage("es")]
[assembly: InternalsVisibleTo("VehicleTracking.Data.Tests")]
namespace Domain
{
    public class User
    {
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

        public static bool IsValidName(string value)
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

        public static bool IsValidUsername(string value)
        {
            return Utilities.ContainsLettersOrDigitsOnly(value);
        }

        private string password;
        public virtual string Password
        {
            get { return password; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    password = value;
                }
                else
                {
                    throw new UserException(ErrorMessages.PasswordIsInvalid);
                }
            }
        }

        internal static User InstanceForTestingPurposes()
        {
            return new User();
        }

        protected User()
        {
            firstName = "Usuario";
            lastName = "inválido.";
            username = "usuarioinválido";
            password = "Contraseña inválida.";
        }
    }
}
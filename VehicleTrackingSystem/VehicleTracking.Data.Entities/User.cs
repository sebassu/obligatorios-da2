using System.Globalization;
using System.Runtime.CompilerServices;
using System.Linq;

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

        public static bool IsValidName(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                value.ToCharArray().All(c => char.IsLetter(c)
                || char.IsWhiteSpace(c));
        }

        internal static User InstanceForTestingPurposes()
        {
            return new User();
        }

        protected User()
        {
            firstName = "Usuario";
        }
    }
}
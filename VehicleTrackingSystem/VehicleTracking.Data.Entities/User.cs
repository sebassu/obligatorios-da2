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

        public static bool IsValidName(string value)
        {
            return Utilities.ContainsLettersOrSpacesOnly(value);
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
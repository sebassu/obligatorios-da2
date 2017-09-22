using Domain;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Tests")]
namespace API.Services
{
    public class UserDTO
    {
        public UserRoles Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        internal static UserDTO FromUser(User someUser)
        {
            return new UserDTO(someUser);
        }

        protected UserDTO(User someUser) : this(someUser.Role, someUser.FirstName,
            someUser.LastName, someUser.Username, someUser.Password.Length.ToString(),
            someUser.PhoneNumber)
        { }

        public static UserDTO FromData(UserRoles role, string firstName, string lastName,
            string username, string password, string phoneNumber)
        {
            return new UserDTO(role, firstName, lastName, username, password, phoneNumber);
        }

        protected UserDTO(UserRoles roleToSet, string firstNameToSet, string lastNameToSet,
            string usernameToSet, string passwordToSet, string phoneNumberToSet)
        {
            Role = roleToSet;
            FirstName = firstNameToSet;
            LastName = lastNameToSet;
            Username = usernameToSet;
            Password = passwordToSet;
            PhoneNumber = phoneNumberToSet;
        }

        internal User ToUser()
        {
            return User.CreateNewUser(Role, FirstName, LastName,
                Username, Password, PhoneNumber);
        }

        internal void SetDataToUser(User userToModify)
        {
            userToModify.Role = Role;
            userToModify.FirstName = FirstName;
            userToModify.LastName = LastName;
            userToModify.Username = Username;
            userToModify.Password = Password;
            userToModify.PhoneNumber = PhoneNumber;
        }

        public override bool Equals(object obj)
        {
            UserDTO dtoToCompareAgainst = obj as UserDTO;
            if (Utilities.IsNotNull(dtoToCompareAgainst))
            {
                return Username.Equals(dtoToCompareAgainst.Username);
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
    }
}
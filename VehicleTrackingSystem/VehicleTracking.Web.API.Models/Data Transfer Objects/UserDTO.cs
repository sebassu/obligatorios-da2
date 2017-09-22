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

        protected UserDTO(User someUser)
        {
            Role = someUser.Role;
            FirstName = someUser.FirstName;
            LastName = someUser.LastName;
            Username = someUser.Username;
            Password = someUser.Password.Length.ToString();
            PhoneNumber = someUser.PhoneNumber;
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
    }
}
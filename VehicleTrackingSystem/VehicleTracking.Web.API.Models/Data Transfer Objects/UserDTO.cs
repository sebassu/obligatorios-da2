using Domain;

namespace API.Services
{
    public class UserDTO
    {
        public int Id { get; set; }
        public UserRoles Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public static UserDTO FromUser(User someUser)
        {
            return new UserDTO(someUser);
        }

        protected UserDTO(User someUser)
        {
            Id = someUser.Id;
            Role = someUser.Role;
            FirstName = someUser.FirstName;
            LastName = someUser.LastName;
            Username = someUser.Username;
            Password = someUser.Password.Length.ToString();
            PhoneNumber = someUser.PhoneNumber;
        }
    }
}
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API")]
namespace API.Services
{
    public interface IUserServices
    {
        void AddNewUserFromData(UserDTO userToAdd);
        IEnumerable<UserDTO> GetRegisteredUsers();
        UserDTO GetUserByUsername(string usernameToLookup);
        void RemoveUserWithUsername(string usernameToRemove);
        void ModifyUserWithUsername(string usernameToModify, UserDTO userDataToSet);
    }
}
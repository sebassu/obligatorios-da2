using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API")]
namespace API.Services
{
    public interface IUserServices
    {
        IEnumerable<UserDTO> GetRegisteredUsers();
        UserDTO GetUserByUsername(string usernameToLookup);
        void AddNewUserFromData(UserDTO userToAdd);
        void RemoveUserWithUsername(string usernameToRemove);
        void ModifyUserWithUsername(string usernameToModify, UserDTO userDataToSet);
    }
}
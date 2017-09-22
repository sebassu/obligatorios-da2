using System.Collections.Generic;

namespace API.Services
{
    public interface IUsersServices
    {
        IEnumerable<UserDTO> GetRegisteredUsers();
        UserDTO GetUserByUsername(string usernameToLookup);
        void AddNewUserFromData(UserDTO userToAdd);
        void RemoveUserWithUsername(string usernameToRemove);
        void ModifyUserWithUsername(string usernameToModify, UserDTO userDataToSet);
    }
}
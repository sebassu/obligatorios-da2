using System.Collections.Generic;

namespace API.Services
{
    public interface IUsersServices
    {
        IReadOnlyCollection<UserDTO> GetRegisteredUsers();
        UserDTO GetUserByUd(int id);
        int Add(UserDTO userToAdd);
        void Remove(int id);
        void Modify(int id, UserDTO userToModify);
        void UpdateUserWithId(int id, UserDTO userDataToSet);
    }
}
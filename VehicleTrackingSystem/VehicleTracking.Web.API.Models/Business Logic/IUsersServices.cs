using System.Collections.Generic;

namespace API.Services
{
    public interface IUsersServices
    {
        IReadOnlyCollection<UserDTO> GetAllUsers();
        UserDTO GetByID(int id);
        int Add(UserDTO userToAdd);
        void Remove(int id);
        void Modify(int id, UserDTO userToModify);
    }
}
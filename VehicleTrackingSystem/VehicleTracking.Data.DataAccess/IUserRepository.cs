using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface IUserRepository
    {
        IEnumerable<User> Elements { get; }
        User GetUserWithUsername(string usernameToLookup);
        int AddNewUser(User userToAdd);
        void UpdateUser(User userToModify);
        void RemoveUserWithUsername(string usernameToRemove);
        bool ExistsUserWithUsername(string usernameToLookup);
        bool UsernameBelongsToLastAdministrator(string usernameToRemove);
    }
}
using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface IUserRepository
    {
        void AddNewUser(User userToAdd);
        IEnumerable<User> Elements { get; }
        User GetUserWithUsername(string usernameToLookup);
        void UpdateUser(User userToModify);
        void RemoveUserWithUsername(string usernameToRemove);
        bool ExistsUserWithUsername(string usernameToLookup);
        bool UsernameBelongsToLastAdministrator(string usernameToRemove);
    }
}
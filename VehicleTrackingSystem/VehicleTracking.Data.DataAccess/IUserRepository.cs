using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface IUserRepository
    {
        IEnumerable<User> Elements { get; }
        User GetUserByUsername(string usernameToLookup);
        void AddNewUser(User userToAdd);
        void UpdateUser(User userToModify);
        void Remove(string usernameToRemove);
        bool ExistsUserWithUsername(string usernameToLookup);
    }
}
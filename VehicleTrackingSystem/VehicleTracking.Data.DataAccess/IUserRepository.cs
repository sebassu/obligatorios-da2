﻿using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface IUserRepository
    {
        IEnumerable<User> Elements { get; }
        User GetUserWithUsername(string usernameToLookup);
        void AddNewUser(User userToAdd);
        void UpdateUser(User userToModify);
        void RemoveUserWithUsername(string usernameToRemove);
        bool ExistsUserWithUsername(string usernameToLookup);
    }
}
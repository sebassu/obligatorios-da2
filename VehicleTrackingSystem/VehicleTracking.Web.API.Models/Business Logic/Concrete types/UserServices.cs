using Persistence;
using System.Collections.Generic;
using System;

namespace API.Services
{
    public class UserServices : IUserServices
    {
        private IUserRepository Users { get; }

        public UserServices(IUserRepository someRepository = null)
        {
            Users = someRepository;
        }

        public IEnumerable<UserDTO> GetRegisteredUsers()
        {
            List<UserDTO> result = new List<UserDTO>();
            foreach (var user in Users.Elements)
            {
                result.Add(UserDTO.FromUser(user));
            }
            return result.AsReadOnly();
        }

        public UserDTO GetUserByUsername(string usernameToLookup)
        {
            throw new NotImplementedException();
        }

        public void AddNewUserFromData(UserDTO userToAdd)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserWithUsername(string usernameToRemove)
        {
            throw new NotImplementedException();
        }

        public void ModifyUserWithUsername(string usernameToModify, UserDTO userDataToSet)
        {
            throw new NotImplementedException();
        }
    }
}

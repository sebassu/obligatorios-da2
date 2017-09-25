using Domain;
using Persistence;
using System.Collections.Generic;

namespace API.Services
{
    public class UserServices : IUserServices
    {
        internal IUserRepository Model { get; }

        public UserServices()
        {
            Model = new UserRepository();
        }

        public UserServices(IUserRepository someRepository = null)
        {
            Model = someRepository;
        }

        public void AddNewUserFromData(UserDTO userDataToAdd)
        {
            ServiceUtilities.CheckParameterIsNotNullAndExecute(userDataToAdd,
                delegate { AttemptToAddUser(userDataToAdd); });
        }

        public IEnumerable<UserDTO> GetRegisteredUsers()
        {
            var result = new List<UserDTO>();
            foreach (var user in Model.Elements)
            {
                result.Add(UserDTO.FromUser(user));
            }
            return result.AsReadOnly();
        }

        public UserDTO GetUserByUsername(string usernameToLookup)
        {
            User userFound = Model.GetUserByUsername(usernameToLookup);
            return UserDTO.FromUser(userFound);
        }

        private void AttemptToAddUser(UserDTO userDataToAdd)
        {
            bool usernameIsNotRegistered =
                !Model.ExistsUserWithUsername(userDataToAdd.Username);
            if (usernameIsNotRegistered)
            {
                User userToAdd = userDataToAdd.ToUser();
                Model.AddNewUser(userToAdd);
            }
            else
            {
                throw new ServiceException(ErrorMessages.UsernameMustBeUnique);
            }
        }

        public void ModifyUserWithUsername(string usernameToModify, UserDTO userData)
        {
            ServiceUtilities.CheckParameterIsNotNullAndExecute(userData,
            delegate { AttemptToPerformModification(usernameToModify, userData); });

        }

        private void AttemptToPerformModification(string usernameToModify,
            UserDTO userData)
        {
            User userFound = Model.GetUserByUsername(usernameToModify);
            userData.SetDataToUser(userFound);
            Model.UpdateUser(userFound);
        }

        public void RemoveUserWithUsername(string usernameToRemove)
        {
            Model.RemoveUserWithUsername(usernameToRemove);
        }
    }
}
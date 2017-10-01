using Domain;
using Persistence;
using System.Collections.Generic;
using System.Globalization;

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

        private void AttemptToAddUser(UserDTO userDataToAdd)
        {
            User userToAdd = userDataToAdd.ToUser();
            Model.AddNewUser(userToAdd);
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
            User userFound = Model.GetUserWithUsername(usernameToLookup);
            return UserDTO.FromUser(userFound);
        }

        public void ModifyUserWithUsername(string usernameToModify, UserDTO userDataToSet)
        {
            ServiceUtilities.CheckParameterIsNotNullAndExecute(userDataToSet,
            delegate { AttemptToPerformModification(usernameToModify, userDataToSet); });

        }

        private void AttemptToPerformModification(string usernameToModify,
            UserDTO userData)
        {
            if (ChangeCausesRepeatedUsernames(usernameToModify, userData))
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.FieldMustBeUnique, "nombre de usuario");
                throw new ServiceException(errorMessage);
            }
            else
            {
                User userFound = Model.GetUserWithUsername(usernameToModify);
                userData.SetDataToUser(userFound);
                Model.UpdateUser(userFound);
            }
        }

        private bool ChangeCausesRepeatedUsernames(string currentUsername, UserDTO userData)
        {
            bool usernameChanges = !currentUsername.Equals(userData.Username);
            return usernameChanges && Model.ExistsUserWithUsername(userData.Username);
        }

        public void RemoveUserWithUsername(string usernameToRemove)
        {
            Model.RemoveUserWithUsername(usernameToRemove);
        }
    }
}
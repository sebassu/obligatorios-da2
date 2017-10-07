using Domain;
using Persistence;
using System.Collections.Generic;
using System.Globalization;

namespace API.Services
{
    public class UserServices : IUserServices
    {
        internal IUnitOfWork Model { get; }
        internal IUserRepository Users { get; }

        public UserServices()
        {
            Model = new UnitOfWork();
            Users = Model.Users;
        }

        public UserServices(IUnitOfWork someUnitOfWork)
        {
            Model = someUnitOfWork;
            Users = someUnitOfWork.Users;
        }

        public int AddNewUserFromData(UserDTO userDataToAdd)
        {
            if (Utilities.IsNotNull(userDataToAdd))
            {
                return AttemptToAddUser(userDataToAdd);
            }
            else
            {
                throw new ServiceException(ErrorMessages.NullDTOReference);
            }
        }

        private int AttemptToAddUser(UserDTO userDataToAdd)
        {
            bool usernameIsNotRegistered =
                !Users.ExistsUserWithUsername(userDataToAdd.Username);
            if (usernameIsNotRegistered)
            {
                User userToAdd = userDataToAdd.ToUser();
                Users.AddNewUser(userToAdd);
                Model.SaveChanges();
                return userToAdd.Id;
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.FieldMustBeUnique, "nombre de usuario");
                throw new ServiceException(errorMessage);
            }
        }

        public IEnumerable<UserDTO> GetRegisteredUsers()
        {
            var result = new List<UserDTO>();
            foreach (var user in Users.Elements)
            {
                result.Add(UserDTO.FromUser(user));
            }
            return result.AsReadOnly();
        }

        public UserDTO GetUserWithUsername(string usernameToLookup)
        {
            User userFound = Users.GetUserWithUsername(usernameToLookup);
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
                User userFound = Users.GetUserWithUsername(usernameToModify);
                userData.SetDataToUser(userFound);
                Users.UpdateUser(userFound);
                Model.SaveChanges();
            }
        }

        private bool ChangeCausesRepeatedUsernames(string currentUsername, UserDTO userData)
        {
            bool usernameChanges = !currentUsername.Equals(userData.Username);
            return usernameChanges && Users.ExistsUserWithUsername(userData.Username);
        }

        public void RemoveUserWithUsername(string usernameToRemove)
        {
            if (Users.UsernameBelongsToLastAdministrator(usernameToRemove))
            {
                throw new ServiceException(ErrorMessages.CannotRemoveAllAdministrators);
            }
            else
            {
                Users.RemoveUserWithUsername(usernameToRemove);
                Model.SaveChanges();
            }
        }
    }
}
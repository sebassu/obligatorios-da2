using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public static class SessionServices
    {

        public static User LoggedUser;

        public static bool LogIn(string username, string password)
        {
            if (username.Trim() != "" && password.Trim() != "")
            {
                return AttemptToLogIn(username, password);
            }
            else
            {
                throw new ServiceException(ErrorMessages.NotEmptyValues);
            }
        }

        private static bool AttemptToLogIn(string username, string password)
        {
            User actualUser = GetUser(username);
            if (ValidPassword(password, actualUser))
            {
                if (ValidateRole(actualUser))
                {
                    LoggedUser = actualUser;
                    return true;
                }
                else
                {
                    throw new ServiceException(ErrorMessages.WrongUserRole);
                }
            }
            else
            {
                throw new ServiceException(ErrorMessages.NotMatchingPasswords);
            }
        }

        private static User GetUser(string username)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
                IUserRepository users = unitOfWork.Users;
                return users.GetUserWithUsername(username);
            }
        }

        private static bool ValidPassword (string password, User actualUser)
        {
            return actualUser.Password.Equals(password);
        }

        private static bool ValidateRole(User actualUser)
        {
            return actualUser.Role.Equals(UserRoles.ADMINISTRATOR);
        }
    }
}
    


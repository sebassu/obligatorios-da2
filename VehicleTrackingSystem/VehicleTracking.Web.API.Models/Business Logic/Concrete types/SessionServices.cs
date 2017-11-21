using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;

namespace API.Services
{
    public static class SessionServices
    {

        public static User LoggedUser;

        public static bool LogIn(string username, string password)
        {
            bool recievedEmptyField = string.IsNullOrWhiteSpace(username)
                || string.IsNullOrWhiteSpace(password);
            if (recievedEmptyField)
            {
                throw new ServiceException(ErrorMessages.NotEmptyValues);
            }
            else
            {
                return AttemptToLogIn(username, password);
            }
        }

        private static bool AttemptToLogIn(string username, string password)
        {
            User actualUser = GetUserWithUsername(username);
            if (ValidPassword(password, actualUser))
            {
                return LogInUserIfAdministrator(actualUser);
            }
            else
            {
                throw new ServiceException(ErrorMessages.NotMatchingPasswords);
            }
        }

        private static bool LogInUserIfAdministrator(User someUser)
        {
            bool isAdministrator = someUser.Role.Equals(UserRoles.ADMINISTRATOR);
            if (isAdministrator)
            {
                LoggedUser = someUser;
                return true;
            }
            else
            {
                throw new ServiceException(ErrorMessages.WrongUserRole);
            }
        }

        private static User GetUserWithUsername(string username)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
                IUserRepository users = unitOfWork.Users;
                return users.GetUserWithUsername(username);
            }
        }

        private static bool ValidPassword(string password, User actualUser)
        {
            return actualUser.Password.Equals(password);
        }
    }
}
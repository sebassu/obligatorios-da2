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
            User actual;
            if (username.Trim() != "" && password.Trim() != "")
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork())
                {
                    IUserRepository users = unitOfWork.Users;
                    actual = users.GetUserWithUsername(username);
                }
                if (actual.Password.Equals(password))
                {
                    if (actual.Role.Equals(UserRoles.ADMINISTRATOR))
                    {
                        LoggedUser = actual;
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
            else
            {
                throw new ServiceException(ErrorMessages.NotEmptyValues);
            }
        }
    }
}
    


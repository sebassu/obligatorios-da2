using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Movement
    {
        private User responsibleUser;
        public User ResponsibleUser
        {
            get { return responsibleUser; }
            set
            {
                if (IsValidUser(value))
                {
                    responsibleUser = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                       ErrorMessages.ResponsibleUserIsInvalid, "", null);
                    throw new MovementException(errorMessage);
                }
            }
        }

        private static UserRoles[] allowedUserRoles = { UserRoles.ADMINISTRATOR, UserRoles.YARD_OPERATOR };

        protected bool IsValidUser(User user)
        {
            return Utilities.IsValidUser(user, allowedUserRoles);
        }

        internal static Movement InstanceForTestingPurposes()
        {
            return new Movement();
        }

        protected Movement()
        {
            responsibleUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Maria", "Gonzalez", "mgon", "password", "26010376");
        }
    }
}

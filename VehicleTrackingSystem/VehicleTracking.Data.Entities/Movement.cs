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
        public int Id { get; set; }

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

        private DateTime dateTime;
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                if (IsValidDate(value))
                {
                    dateTime = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.DateIsInvalid, "", value);
                    throw new MovementException(errorMessage);
                }
            }
        }

        protected virtual bool IsValidDate(DateTime value)
        {
            return Utilities.IsValidDate(value);
        }

        internal static Movement InstanceForTestingPurposes()
        {
            return new Movement();
        }

        protected Movement()
        {
            responsibleUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Maria", "Gonzalez", "mgon", "password", "26010376");
            dateTime = new DateTime(2017, 9, 22, 10, 8, 0);
        }
    }
}

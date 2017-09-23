using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Inspection
    {

        public int Id { get; set; }

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
                    throw new InspectionException(errorMessage);
                }
            }
        }

        protected virtual bool IsValidDate(DateTime value)
        {
            return Utilities.IsValidDate(value);
        }

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
                    throw new InspectionException(errorMessage);
                }
            }
        }

        private UserRoles[] allowedUserRoles = { UserRoles.ADMINISTRATOR, UserRoles.PORT_OPERATOR, UserRoles.YARD_OPERATOR };

        protected bool IsValidUser(User user)
        {
            return Utilities.IsNotNull(user) ? allowedUserRoles.Contains(user.Role) : false;
        }

        private Location location;
        public Location Location
        {
            get { return location; }
            set
            {
                if (IsValidLocation(value))
                {
                    location = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                       ErrorMessages.LocationIsInvalid, "", null);
                    throw new InspectionException(errorMessage);
                }
            }
        }

        protected bool IsValidLocation(Location value)
        {
            return Utilities.IsNotNull(value);
        }

        internal static Inspection InstanceForTestingPurposes()
        {
            return new Inspection();
        }

        protected Inspection()
        {
            dateTime = new DateTime(2017, 9, 22, 10, 8, 0);
            responsibleUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Maria", "Gonzalez", "mgon", "password", "26010376");

        }
    }
}

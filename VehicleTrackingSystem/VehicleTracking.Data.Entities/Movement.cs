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

        private Subzone subzoneDeparture;
        public Subzone SubzoneDeparture
        {
            get { return subzoneDeparture; }
            set
            {
                if (IsValidSubzone(value))
                {
                    subzoneDeparture = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                       ErrorMessages.SubzoneIsInvalid, "partida", null);
                    throw new MovementException(errorMessage);
                }
            }
        }

        protected virtual bool IsValidSubzone(Subzone value)
        {
            return Utilities.IsNotNull(value);
        }

        private Subzone subzoneArrival;
        public Subzone SubzoneArrival
        {
            get { return subzoneArrival; }
            set
            {
                if (IsValidSubzone(value))
                {
                    if (IsValidSubzoneArrival(subzoneDeparture, value))
                    {
                        subzoneArrival = value;
                    }
                    else
                    {
                        string errorMessage = string.Format(CultureInfo.CurrentCulture,
                      ErrorMessages.SubzoneArrivalIsInvalid, "", null);
                        throw new MovementException(errorMessage);
                    }
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                       ErrorMessages.SubzoneIsInvalid, "llegada", null);
                    throw new MovementException(errorMessage);
                }
            }
        }

        protected virtual bool IsValidSubzoneArrival(Subzone departure, Subzone arrival)
        {
            return Utilities.IsNotNull(departure) && Utilities.IsNotNull(arrival) ? !departure.Equals(arrival) : false;
        }

        internal static Movement InstanceForTestingPurposes()
        {
            return new Movement();
        }

        protected Movement()
        {
            responsibleUser = User.CreateNewUser(UserRoles.ADMINISTRATOR, "Maria", "Gonzalez", "mgon", "password", "26010376");
            dateTime = new DateTime(2017, 9, 22, 10, 8, 0);
            subzoneDeparture = Subzone.InstanceForTestingPurposes();
            Subzone alternativeSubzone = Subzone.CreateNewSubzone("arrival", 8, Zone.InstanceForTestingPurposes());
            alternativeSubzone.Id = 2;
            subzoneArrival = alternativeSubzone;
        }

        public static Movement CreateNewMovement(User user, DateTime dateTime, Subzone subzoneDeparture,
            Subzone subzoneArrival)
        {
            return new Movement(user, dateTime, subzoneDeparture, subzoneArrival);
        }

        protected Movement(User userToSet, DateTime dateTimeToSet, Subzone subzoneDepartureToSet,
            Subzone subzoneArrivalToSet)
        {
            ResponsibleUser = userToSet;
            DateTime = dateTimeToSet;
            SubzoneDeparture = subzoneDepartureToSet;
            SubzoneArrival = subzoneArrivalToSet;
        }

        public override bool Equals(object obj)
        {
            Movement movementToCompareAgainst = obj as Movement;
            if (Utilities.IsNotNull(movementToCompareAgainst))
            {
                return Id.Equals(movementToCompareAgainst.Id);
            }
            else
            {
                return false;
            }
        }
    }
}

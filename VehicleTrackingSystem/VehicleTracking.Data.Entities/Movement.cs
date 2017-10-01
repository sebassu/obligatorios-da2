using System;
using System.Globalization;
using System.Linq;

namespace Domain
{
    public class Movement
    {
        private static UserRoles[] allowedUserRoles = { UserRoles.ADMINISTRATOR,
            UserRoles.YARD_OPERATOR };

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
                       ErrorMessages.ResponsibleUserIsInvalid, value);
                    throw new MovementException(errorMessage);
                }
            }
        }

        protected bool IsValidUser(User user)
        {
            return Utilities.IsNotNull(user) &&
                allowedUserRoles.Contains(user.Role);
        }

        private DateTime dateTime;
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                if (IsValidMovementDate(value))
                {
                    dateTime = value;
                }
                else
                {
                    throw new MovementException(ErrorMessages.DateIsInvalid);
                }
            }
        }

        protected virtual bool IsValidMovementDate(DateTime value)
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
            return Utilities.IsNotNull(departure) && Utilities.IsNotNull(arrival) ?
                !departure.Equals(arrival) : false;
        }

        internal static Movement InstanceForTestingPurposes()
        {
            return new Movement();
        }

        protected Movement() { }

        public static Movement CreateNewMovement(User user, DateTime dateTime,
            Subzone subzoneDeparture, Subzone subzoneArrival)
        {
            return new Movement(user, dateTime, subzoneDeparture, subzoneArrival);
        }

        protected Movement(User userToSet, DateTime dateTimeToSet,
            Subzone subzoneDepartureToSet, Subzone subzoneArrivalToSet)
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

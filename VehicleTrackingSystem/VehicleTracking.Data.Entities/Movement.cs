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
                if (IsValidResponsibleUser(value))
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

        protected bool IsValidResponsibleUser(User user)
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

        private Subzone departure;
        public Subzone Departure
        {
            get { return departure; }
            set
            {
                if (ExistsMovementBetween(value, arrival))
                {
                    departure = value;
                }
                else
                {
                    throw new MovementException(ErrorMessages.DepartureIsInvalid);
                }
            }
        }

        private Subzone arrival;
        public Subzone Arrival
        {
            get { return arrival; }
            set
            {
                if (IsValidArrival(departure, value))
                {
                    arrival = value;
                }
                else
                {
                    throw new MovementException(ErrorMessages.ArrivalIsInvalid);
                }
            }
        }

        private bool IsValidArrival(Subzone departure, Subzone arrival)
        {
            return Utilities.IsNotNull(arrival) &&
                ExistsMovementBetween(departure, arrival);
        }

        protected virtual bool ExistsMovementBetween(Subzone departure,
            Subzone arrival)
        {
            return departure != arrival;
        }

        internal static Movement InstanceForTestingPurposes()
        {
            return new Movement()
            {
                arrival = Subzone.InstanceForTestingPurposes()
            };
        }

        protected Movement() { }

        public static Movement CreateNewMovement(User user, DateTime dateTime,
            Subzone subzoneDeparture, Subzone subzoneArrival)
        {
            return new Movement(user, dateTime, subzoneDeparture, subzoneArrival);
        }

        protected Movement(User userToSet, DateTime dateTimeToSet,
            Subzone departureToSet, Subzone arrivalToSet)
        {
            if (IsValidArrival(departureToSet, arrivalToSet))
            {
                SetCreationParameters(userToSet, dateTimeToSet,
                    departureToSet, arrivalToSet);
            }
            else
            {
                throw new MovementException(ErrorMessages.ArrivalIsInvalid);
            }
        }

        private void SetCreationParameters(User userToSet, DateTime dateTimeToSet,
            Subzone departureToSet, Subzone arrivalToSet)
        {
            ResponsibleUser = userToSet;
            DateTime = dateTimeToSet;
            departure = departureToSet;
            arrival = arrivalToSet;
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
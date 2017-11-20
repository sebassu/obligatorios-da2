using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleTracking_Data_Entities
{
    public class Movement
    {
        private static readonly IReadOnlyCollection<UserRoles> allowedUserRoles =
            new List<UserRoles> { UserRoles.ADMINISTRATOR, UserRoles.YARD_OPERATOR }.AsReadOnly();

        public int Id { get; set; }

        private User responsible;
        public User Responsible
        {
            get { return responsible; }
            set
            {
                if (IsValidResponsibleUser(value))
                {
                    responsible = value;
                }
                else
                {
                    throw new MovementException(ErrorMessages.ResponsibleUserIsInvalid);
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

        public Subzone Departure { get; set; }

        public Subzone Arrival { get; set; }

        internal static Movement InstanceForTestingPurposes()
        {
            return new Movement()
            {
                Arrival = Subzone.InstanceForTestingPurposes()
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

        private bool IsValidArrival(Subzone departure, Subzone arrival)
        {
            return Utilities.IsNotNull(arrival) &&
                !arrival.Equals(departure);
        }

        private void SetCreationParameters(User userToSet, DateTime dateTimeToSet,
            Subzone departureToSet, Subzone arrivalToSet)
        {
            Responsible = userToSet;
            DateTime = dateTimeToSet;
            Departure = departureToSet;
            Arrival = arrivalToSet;
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
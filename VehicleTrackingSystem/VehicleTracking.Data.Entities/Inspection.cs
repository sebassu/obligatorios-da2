using System;
using System.Collections.Generic;
using System.Globalization;

namespace Domain
{
    public class Inspection
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

        protected bool IsValidUser(User user)
        {
            return Utilities.IsValidUserInspection(user) && Utilities.ValidateInspection(user, location);
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
            return Utilities.IsNotNull(value) && Utilities.ValidateInspection(responsibleUser, value);
        }

        private List<Damage> damages;
        public List<Damage> Damages
        {
            get { return damages; }
            set
            {
                if (IsValidList(value))
                {
                    damages = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                       ErrorMessages.ListIsInvalid, value);
                    throw new InspectionException(errorMessage);
                }
            }
        }

        protected bool IsValidList(List<Damage> value)
        {
            return Utilities.IsNotNull(value) ? value.Count > 0 : false;
        }

        private string vehicleVIN;
        public string VehicleVIN
        {
            get { return vehicleVIN; }
            set
            {
                if (IsValidVIN(value))
                {
                    vehicleVIN = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                       ErrorMessages.VINIsInvalid, "VIN", value);
                    throw new InspectionException(errorMessage);
                }
            }
        }

        protected bool IsValidVIN(string value)
        {
            return Utilities.IsValidVIN(value);
        }

        internal static Inspection InstanceForTestingPurposes()
        {
            return new Inspection()
            {
                location = Location.InstanceForTestingPurposes(),
                responsibleUser = User.InstanceForTestingPurposes()
            };
        }

        protected Inspection() { }

        public static Inspection CreateNewInspection(User user, Location location,
            DateTime dateTime, List<Damage> damages, Vehicle vehicle)
        {
            return new Inspection(user, location, dateTime, damages, vehicle);
        }

        protected Inspection(User userToSet, Location locationToSet, DateTime dateTimeToSet,
            List<Damage> damagesToSet, Vehicle vehicleToSet)
        {
            if (ValidParameters(userToSet, locationToSet))
            {
                responsibleUser = userToSet;
                location = locationToSet;
                DateTime = dateTimeToSet;
                Damages = damagesToSet;
                VehicleVIN = vehicleToSet.VIN;
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                       ErrorMessages.UserRoleLocationTypeInvalid);
                throw new InspectionException(errorMessage);
            }
        }

        protected bool ValidParameters(User user, Location location)
        {
            return Utilities.ValidateInspection(user, location);
        }

        public override bool Equals(object obj)
        {
            Inspection InspectionToCompareAgainst = obj as Inspection;
            if (Utilities.IsNotNull(InspectionToCompareAgainst))
            {
                return Id.Equals(InspectionToCompareAgainst.Id);
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

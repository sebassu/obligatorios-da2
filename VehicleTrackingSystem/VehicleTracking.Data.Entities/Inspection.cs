using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Domain
{
    public class Inspection
    {
        private static readonly IReadOnlyCollection<UserRoles> PortInspectionAllowedRoles =
            new List<UserRoles> { UserRoles.ADMINISTRATOR, UserRoles.PORT_OPERATOR }.AsReadOnly();
        private static readonly IReadOnlyCollection<UserRoles> YardInspectionAllowedRoles =
            new List<UserRoles> { UserRoles.ADMINISTRATOR, UserRoles.YARD_OPERATOR }.AsReadOnly();

        public int Id { get; set; }

        private DateTime dateTime;
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                if (IsValidInspectionDate(value))
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

        protected bool IsValidInspectionDate(DateTime value)
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
<<<<<<< HEAD
            return UserCanInspect(user, location);
        }

        public static bool UserCanInspect(User user, Location location)
        {
            bool parametersAreNotNull = Utilities.IsNotNull(user) &&
                Utilities.IsNotNull(location);
            if (parametersAreNotNull)
            {
                return IsValidRoleLocationConcordance(user, location);
            }
            else
            {
                return false;
            }
        }

        private static bool IsValidRoleLocationConcordance(User user, Location location)
        {
            switch (location.Type)
            {
                case LocationType.PORT:
                    return PortInspectionAllowedRoles.Contains(user.Role);
                case LocationType.YARD:
                    return YardInspectionAllowedRoles.Contains(user.Role);
                default:
                    return false;
            }
=======
            return Utilities.IsValidUser(user, allowedUserRoles);
>>>>>>> feature/Zone_SubzoneRepository
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
            return UserCanInspect(responsibleUser, value);
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

        protected Inspection()
        {
        }

        public static Inspection CreateNewInspection(User user, Location location,
            DateTime dateTime, List<Damage> damages, Vehicle vehicle)
        {
            return new Inspection(user, location, dateTime, damages, vehicle);
        }

        protected Inspection(User userToSet, Location locationToSet, DateTime dateTimeToSet,
            List<Damage> damagesToSet, Vehicle vehicleToSet)
        {
            if (UserCanInspect(userToSet, locationToSet))
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

        public override bool Equals(object obj)
        {
            Inspection inspectionToCompareAgainst = obj as Inspection;
            if (Utilities.IsNotNull(inspectionToCompareAgainst))
            {
                return Id.Equals(inspectionToCompareAgainst.Id);
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

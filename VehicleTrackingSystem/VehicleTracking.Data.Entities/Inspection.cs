using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Domain
{
    public class Inspection
    {
        private static readonly IReadOnlyDictionary<LocationType, IReadOnlyCollection<UserRoles>> allowedRolesPerLocationType =
            new Dictionary<LocationType, IReadOnlyCollection<UserRoles>>
            {
                { LocationType.PORT, new List<UserRoles> { UserRoles.ADMINISTRATOR, UserRoles.PORT_OPERATOR }.AsReadOnly() },
                { LocationType.YARD, new List<UserRoles> { UserRoles.ADMINISTRATOR, UserRoles.YARD_OPERATOR }.AsReadOnly() }
            };

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
                    throw new InspectionException(ErrorMessages.DateIsInvalid);
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
                    throw new InspectionException(ErrorMessages.UserRoleLocationTypeInvalid);
                }
            }
        }

        protected bool IsValidUser(User value)
        {
            return UserCanInspect(value, location);
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
            var permittedUserRoles = allowedRolesPerLocationType[location.Type];
            return permittedUserRoles.Contains(user.Role);
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
                    throw new InspectionException(ErrorMessages.UserRoleLocationTypeInvalid);
                }
            }
        }

        protected bool IsValidLocation(Location value)
        {
            return UserCanInspect(responsibleUser, value);
        }

        private ICollection<Damage> damages = new List<Damage>();
        public ICollection<Damage> Damages
        {
            get { return damages; }
            set
            {
                if (IsValidDamageCollection(value))
                {
                    damages = value;
                }
                else
                {
                    throw new InspectionException(ErrorMessages.DamageCollectionIsInvalid);
                }
            }
        }

        private bool IsValidDamageCollection(ICollection<Damage> value)
        {
            return Utilities.IsNotNull(value) &&
                value.Distinct().Count() == value.Count;
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
            DateTime dateTime, ICollection<Damage> damages, Vehicle vehicle)
        {
            return new Inspection(user, location, dateTime, damages, vehicle);
        }

        protected Inspection(User userToSet, Location locationToSet, DateTime dateTimeToSet,
            ICollection<Damage> damagesToSet, Vehicle vehicleToSet)
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
                throw new InspectionException(ErrorMessages.UserRoleLocationTypeInvalid);
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
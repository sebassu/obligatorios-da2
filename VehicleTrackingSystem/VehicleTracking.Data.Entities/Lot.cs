﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Domain
{
    public class Lot
    {
        private static readonly IReadOnlyCollection<UserRoles> ValidCreatorRoles =
            new List<UserRoles> { UserRoles.ADMINISTRATOR, UserRoles.PORT_OPERATOR }.AsReadOnly();

        public User Creator { get; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (IsValidName(value))
                {
                    name = value.Trim();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.NameIsInvalid, "Nombre de lote", value);
                    throw new LotException(errorMessage);
                }
            }
        }

        protected bool IsValidName(string value)
        {
            return Utilities.ContainsLettersDigitsOrSpacesOnly(value);
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (IsValidDescription(value))
                {
                    description = value.Trim();
                }
                else
                {
                    throw new LotException(ErrorMessages.DescriptionIsInvalid);
                }
            }
        }

        protected bool IsValidDescription(string value)
        {
            return Utilities.IsNotEmpty(value);
        }

        private ICollection<Vehicle> vehicles = new List<Vehicle>();
        public ICollection<Vehicle> Vehicles
        {
            get { return vehicles; }
            set
            {
                if (IsValidVehicleListToSet(value))
                {
                    MarkRemovedVehiclesAsUnlotted(value);
                    MarkAddedVehiclesAsLotted(value);
                    vehicles = value;
                }
                else
                {
                    throw new LotException(
                        ErrorMessages.InvalidVehicleCollectionForLot);
                }
            }
        }

        private bool IsValidVehicleListToSet(ICollection<Vehicle> vehiclesToSet)
        {
            bool isNonEmpty = Utilities.IsNotNull(vehiclesToSet) && vehiclesToSet.Any();
            return isNonEmpty && vehiclesToSet.Except(vehicles).All(v => !v.IsLotted);
        }

        private void MarkRemovedVehiclesAsUnlotted(ICollection<Vehicle> vehiclesToSet)
        {
            foreach (var vehicle in vehicles.Except(vehiclesToSet))
            {
                vehicle.IsLotted = false;
            }
        }

        private void MarkAddedVehiclesAsLotted(ICollection<Vehicle> vehiclesToSet)
        {
            foreach (var vehicle in vehiclesToSet.Except(vehicles))
            {
                vehicle.IsLotted = true;
            }
        }

        internal static Lot InstanceForTestingPurposes()
        {
            return new Lot();
        }

        protected Lot()
        {
            Name = "Lote inválido";
            Description = "Descripción inválida";
        }

        public static Lot CreatorNameDescriptionVehicles(User creator, string name,
            string description, ICollection<Vehicle> vehicles)
        {
            return new Lot(creator, name, description, vehicles);
        }

        protected Lot(User someUser, string nameToSet,
            string descriptionToSet, ICollection<Vehicle> vehiclesToSet)
        {
            if (CreatorIsValid(someUser))
            {
                Creator = someUser;
                Name = nameToSet;
                Description = descriptionToSet;
                Vehicles = vehiclesToSet;
            }
            else
            {
                throw new LotException(ErrorMessages.LotUnauthorizedUserType);
            }
        }

        private bool CreatorIsValid(User someUser)
        {
            return Utilities.IsNotNull(someUser) &&
                ValidCreatorRoles.Contains(someUser.Role);
        }
    }
}

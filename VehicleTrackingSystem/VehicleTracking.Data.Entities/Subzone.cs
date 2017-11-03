using System;
using System.Collections.Generic;
using System.Globalization;

namespace Domain
{
    public class Subzone
    {
        public int Id { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
            = new List<Vehicle>();

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
                        ErrorMessages.ZoneNameIsInvalid, "Nombre", value);
                    throw new SubzoneException(errorMessage);
                }
            }
        }

        internal static bool IsValidName(string value)
        {
            return Utilities.ContainsLettersSpacesOrDigitsOnly(value);
        }

        private int capacity;
        public int Capacity
        {
            get { return capacity; }
            set
            {
                if (IsValidCapacity(value))
                {
                    capacity = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.CapacityIsInvalid, value, Vehicles.Count);
                    throw new SubzoneException(errorMessage);
                }
            }
        }

        protected bool IsValidCapacity(int value)
        {
            return Utilities.ValidMinimumCapacity(value) &&
                value >= Vehicles.Count;
        }

        public Zone Container
        {
            get;
            set;
        }

        public bool CanAdd(Vehicle someVehicle)
        {
            return Utilities.IsNotNull(someVehicle) &&
                Vehicles.Count < Capacity && !Vehicles.Contains(someVehicle);
        }

        internal static Subzone InstanceForTestingPurposes()
        {
            return new Subzone()
            {
                Container = Zone.InstanceForTestingPurposes()
            };
        }

        protected Subzone()
        {
            name = "Subzona inválida";
            capacity = 3;
        }

        public static Subzone CreateNewSubzone(String name,
            int capacity, Zone zone)
        {
            return new Subzone(name, capacity, zone);
        }

        protected Subzone(string nameToSet, int capacityToSet,
            Zone zoneToSet)
        {
            if (IsValidZone(zoneToSet))
            {
                SetCreationParameters(nameToSet,
                    capacityToSet, zoneToSet);
                zoneToSet.AddSubzone(this);
            }
            else
            {
                throw new SubzoneException(ErrorMessages.ZoneIsInvalid);
            }
        }

        protected bool IsValidZone(Zone value)
        {
            return Utilities.IsNotNull(value);
        }

        private void SetCreationParameters(string nameToSet,
            int capacityToSet, Zone zoneToSet)
        {
            Name = nameToSet;
            Capacity = capacityToSet;
            Container = zoneToSet;
        }

        public override bool Equals(object obj)
        {
            Subzone subzoneToCompareAgainst = obj as Subzone;
            if (Utilities.IsNotNull(subzoneToCompareAgainst))
            {
                return Id.Equals(subzoneToCompareAgainst.Id);
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

        public override string ToString()
        {
            return Container.ToString() + "/" + name;
        }
    }
}
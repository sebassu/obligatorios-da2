using System;
using System.Collections.Generic;
using System.Globalization;

namespace Domain
{
    public class Subzone
    {
        public int Id { get; set; }


        public List<Vehicle> Vehicles { get; set; }

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

        protected bool IsValidName(string value)
        {
            return Utilities.ContainsLettersOrSpacesOrDigitsOnly(value);
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
                        ErrorMessages.CapacityIsInvalid, "Capacidad", value);
                    throw new SubzoneException(errorMessage);
                }
            }
        }

        protected bool IsValidCapacity(int value)
        {
            return Utilities.ValidMinimumCapacity(value);
        }

        private Zone containerZone;
        public Zone ContainerZone
        {
            get { return containerZone; }
            set
            {
                if (IsValidZone(value))
                {
                    containerZone = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                       ErrorMessages.ZoneIsInvalid, "", null);
                    throw new SubzoneException(errorMessage);
                }
            }
        }

        protected bool IsValidZone(Zone value)
        {
            return Utilities.IsNotNull(value);
        }

        internal static Subzone InstanceForTestingPurposes()
        {
            return new Subzone();
        }

        protected Subzone()
        {
            name = "Subzone 1";
            capacity = 3;
            containerZone = Zone.InstanceForTestingPurposes();
        }

        public static Subzone CreateNewSubzone(String name, int capacity, Zone zone)
        {
            return new Subzone(name, capacity, zone);
        }

        protected Subzone(string nameToSet, int capacityToSet, Zone zoneToSet)
        {
            Name = nameToSet;
            Capacity = capacityToSet;
            ContainerZone = zoneToSet;
            Vehicles = new List<Vehicle>();
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
    }
}

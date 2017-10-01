using System;
using System.Collections.Generic;
using System.Globalization;

namespace Domain
{
    public class Zone
    {
        public int Id { get; set; }

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
                    throw new ZoneException(errorMessage);
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
                    throw new ZoneException(errorMessage);
                }
            }
        }

        protected bool IsValidCapacity(int value)
        {
            return Utilities.ValidMinimumCapacity(value);
        }

        public List<Subzone> Subzones { get; set; }

        internal static Zone InstanceForTestingPurposes()
        {
            return new Zone();
        }

        protected Zone()
        {
            name = "Zone 1";
            capacity = 9;
        }

        public static Zone CreateNewZone(String name, int capacity)
        {
            return new Zone(name, capacity);
        }

        protected Zone(string nameToSet, int capacityToSet)
        {
            Name = nameToSet;
            Capacity = capacityToSet;
            Subzones = new List<Subzone>();
        }

        public override bool Equals(object obj)
        {
            Zone zoneToCompareAgainst = obj as Zone;
            if (Utilities.IsNotNull(zoneToCompareAgainst))
            {
                return Id.Equals(zoneToCompareAgainst.Id);
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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
                        ErrorMessages.CapacityIsInvalid, value, usedCapacity);
                    throw new ZoneException(errorMessage);
                }
            }
        }

        private int usedCapacity = 0;

        public void AddSubzone(Subzone subzoneToAdd)
        {
            bool isValidSubzone = Utilities.IsNotNull(subzoneToAdd) &&
                DoesNotExceedMaximumCapacity(subzoneToAdd) &&
                !Subzones.Any(s => s.Name.Equals(subzoneToAdd.Name));
            if (isValidSubzone)
            {
                Subzones.Add(subzoneToAdd);
                usedCapacity += subzoneToAdd.Capacity;
            }
            else
            {
                throw new ZoneException(ErrorMessages.SubzoneIsInvalidForZone);
            }
        }

        private bool DoesNotExceedMaximumCapacity(Subzone subzoneToAdd)
        {
            return subzoneToAdd.Capacity + usedCapacity <= Capacity;
        }

        public void RemoveSubzone(Subzone subzoneToRemove)
        {
            if (Subzones.Remove(subzoneToRemove))
            {
                usedCapacity -= subzoneToRemove.Capacity;
            }
            else
            {
                throw new ZoneException(ErrorMessages.ElementNotFound);
            }
        }

        protected bool IsValidCapacity(int value)
        {
            return Utilities.ValidMinimumCapacity(value);
        }

        public ICollection<Subzone> Subzones { get; set; }
            = new List<Subzone>();

        internal static Zone InstanceForTestingPurposes()
        {
            return new Zone();
        }

        protected Zone()
        {
            name = "Zona inválida";
            capacity = int.MaxValue;
        }

        public static Zone CreateNewZone(String name, int capacity)
        {
            return new Zone(name, capacity);
        }

        protected Zone(string nameToSet, int capacityToSet)
        {
            Name = nameToSet;
            Capacity = capacityToSet;
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

        public override string ToString()
        {
            return name;
        }
    }
}
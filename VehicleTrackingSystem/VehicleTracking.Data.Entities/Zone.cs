using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Zone
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

        private List<Subzone> subzones;
        public List<Subzone> Subzones
        {
            get { return subzones; }
            set
            {
                if (IsValidList(value))
                {
                    subzones = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                       ErrorMessages.ListIsInvalid, value);
                    throw new ZoneException(errorMessage);
                }
            }
        }

        protected bool IsValidList(List<Subzone> value)
        {
            return Utilities.IsNotNull(value) ? value.Count > 0 : false;
        }

        internal static Zone InstanceForTestingPurposes()
        {
            return new Zone();
        }

        protected Zone()
        {
            name = "Zone 1";
            List<Subzone> subzoneList = new List<Subzone> { Subzone.InstanceForTestingPurposes() };
            subzones = subzoneList;
        }

        public static Zone CreateNewZone(String name, int capacity, List<Subzone> subzones)
        {
            return new Zone(name, capacity, subzones);
        }

        protected Zone(string nameToSet, int capacityToSet, List<Subzone> subzonesToSet)
        {
            Name = nameToSet;
            Capacity = capacityToSet;
            Subzones = subzonesToSet;
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

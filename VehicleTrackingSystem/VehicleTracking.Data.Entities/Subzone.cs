using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Subzone
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

        internal static Subzone InstanceForTestingPurposes()
        {
            return new Subzone();
        }

        protected Subzone()
        {
            name = "Subzone 1";
            capacity = 3;
        }

        public static Subzone CreateNewSubzone(String name, int capacity)
        {
            return new Subzone(name, capacity);
        }

        protected Subzone(string nameToSet, int capacityToSet)
        {
            Name = nameToSet;
            Capacity = capacityToSet;
        }
    }
}

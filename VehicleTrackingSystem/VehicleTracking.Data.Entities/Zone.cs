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

        private List<Zone> subzones;
        public List<Zone> Subzones
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

        protected bool IsValidList(List<Zone> value)
        {
            return Utilities.IsNotNull(value) ? value.Count > 0 : false;
        }

        internal static Zone SubzoneForTestingPurposes()
        {
            Zone subzone = InstanceForTestingPurposes();
            subzone.name = "Subzone 1";
            return subzone;
        }

        internal static Zone InstanceForTestingPurposes()
        {
            return new Zone();
        }

        protected Zone()
        {
            name = "Zone 1";
        }
    }
}

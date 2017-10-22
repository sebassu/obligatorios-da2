using System.Globalization;

namespace Domain
{
    public enum LocationType { PORT, YARD }

    public class Location
    {
        public int Id { get; set; }

        public LocationType Type { get; set; } = LocationType.PORT;

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
                        ErrorMessages.NameIsInvalid, "Nombre", value);
                    throw new LocationException(errorMessage);
                }
            }
        }

        protected virtual bool IsValidName(string value)
        {
            return Utilities.ContainsLettersOrSpacesOnly(value);
        }


        internal static Location InstanceForTestingPurposes()
        {
            return new Location();
        }

        protected Location()
        {
            name = "Lugar inválido";
        }

        public static Location CreateNewLocation(LocationType type, string name)
        {
            return new Location(type, name);
        }

        protected Location(LocationType typeToSet, string nameToSet)
        {
            Type = typeToSet;
            Name = nameToSet;
        }

        public override bool Equals(object obj)
        {
            Location locationToCompareAgainst = obj as Location;
            if (Utilities.IsNotNull(locationToCompareAgainst))
            {
                return Id.Equals(locationToCompareAgainst.Id);
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
            return name + ".";
        }
    }
}
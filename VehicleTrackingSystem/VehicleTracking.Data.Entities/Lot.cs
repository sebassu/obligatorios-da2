using System.Globalization;

namespace Domain
{
    public class Lot
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

        internal static Lot InstanceForTestingPurposes()
        {
            return new Lot();
        }

        protected Lot()
        {
            Name = "Lote inválido";
            Description = "Descripción inválida";
        }
    }
}

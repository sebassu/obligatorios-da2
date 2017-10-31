using System.Globalization;

namespace Domain
{
    public class Customer
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
                        ErrorMessages.NameIsInvalid, "Nombre", value);
                    throw new CustomerException(errorMessage);
                }
            }
        }

        protected bool IsValidName(string value)
        {
            return Utilities.ContainsLettersOrSpacesOnly(value);
        }

        internal static Customer InstanceForTestingPurposes()
        {
            return new Customer();
        }

        protected Customer()
        {
            name = "Cliente inválido";
        }
    }
}
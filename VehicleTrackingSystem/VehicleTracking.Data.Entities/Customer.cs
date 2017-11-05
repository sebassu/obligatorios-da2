using System.Globalization;

namespace VehicleTracking_Data_Entities
{
    public class Customer
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
                        ErrorMessages.NameIsInvalid, "Nombre", value);
                    throw new CustomerException(errorMessage);
                }
            }
        }

        protected bool IsValidName(string value)
        {
            return Utilities.ContainsLettersOrSpacesOnly(value);
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (IsValidPhoneNumber(value))
                {
                    phoneNumber = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.PhoneNumberIsInvalid, value);
                    throw new CustomerException(errorMessage);
                }
            }
        }

        protected bool IsValidPhoneNumber(string value)
        {
            return Utilities.HasValidPhoneFormat(value);
        }

        internal static Customer InstanceForTestingPurposes()
        {
            return new Customer();
        }

        protected Customer()
        {
            name = "Cliente inválido";
            phoneNumber = "099424242";
        }

        public static Customer FromNamePhoneNumber(string name, string phoneNumber)
        {
            return new Customer(name, phoneNumber);
        }

        public Customer(string nameToSet, string phoneNumberToSet)
        {
            Name = nameToSet;
            PhoneNumber = phoneNumberToSet;
        }

        public override bool Equals(object obj)
        {
            Customer customerToCompareAgainst = obj as Customer;
            if (Utilities.IsNotNull(customerToCompareAgainst))
            {
                return name.Equals(customerToCompareAgainst.name) &&
                    phoneNumber.Equals(customerToCompareAgainst.phoneNumber);
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
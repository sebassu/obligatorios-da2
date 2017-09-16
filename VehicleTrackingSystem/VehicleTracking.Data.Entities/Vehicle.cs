using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Vehicle
    {
        private string brand;
        public string Brand
        {
            get { return brand; }
            set
            {
                if (IsValidBrand(value))
                {
                    brand = value.Trim();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.BrandIsInvalid, "Marca", value);
                    throw new VehicleException(errorMessage);
                }
            }
        }

        private bool IsValidBrand(string value)
        {
            return Utilities.ContainsLettersOrSpacesOnly(value);
        }

        internal static Vehicle InstanceForTestingPurposes()
        {
            return new Vehicle();
        }

        protected Vehicle()
        {
            brand = "Audi";
        }
    }
}

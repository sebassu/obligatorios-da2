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

        private string model;
        public string Model
        {
            get { return model; }
            set
            {
                if (IsValidModel(value))
                {
                    model = value.Trim();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.ModelIsInvalid, "Modelo", value);
                    throw new VehicleException(errorMessage);
                }
            }
        }

        private bool IsValidModel(string value)
        {
            return Utilities.ContainsLettersOrDigitsOnly(value) || Utilities.ContainsLettersOrSpacesOnly(value);
        }

        private int year;
        public int Year
        {
            get { return year; }
            set
            {
                if (IsValidYear(value))
                {
                    year = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.YearIsInvalid, "Año", value);
                    throw new VehicleException(errorMessage);
                }
            }
        }

        public bool IsValidYear(int value)
        {
            return Utilities.ValidYear(value);
        }

        internal static Vehicle InstanceForTestingPurposes()
        {
            return new Vehicle();
        }

        protected Vehicle()
        {
            brand = "Audi";
            model = "Q5";
        }
    }
}

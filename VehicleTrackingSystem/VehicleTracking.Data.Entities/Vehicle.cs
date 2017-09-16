using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public enum VehicleType { CAR, TRUCK, SUV, VAN, MINI_VAN }

    class Vehicle
    {
        public int Id { get; set; }

        public VehicleType Type { get; set; } = VehicleType.CAR;

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

        private string color;
        public string Color
        {
            get { return color; }
            set
            {
                if (IsValidColor(value))
                {
                    color = value.Trim();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.ColorIsInvalid, "", value);
                    throw new VehicleException(errorMessage);
                }
            }
        }

        private bool IsValidColor(string value)
        {
            return Utilities.ContainsLettersOrSpacesOnly(value);
        }

        private string vin;
        public string Vin
        {
            get { return vin; }
            set
            {
                if (IsValidVin(value))
                {
                    color = value.Trim();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.VinIsInvalid, "", value);
                    throw new VehicleException(errorMessage);
                }
            }
        }

        private int VinLength = 17;
        private bool IsValidVin(string value)
        {
            return Utilities.ContainsLettersOrDigitsOnly(value) && value.Length == VinLength;
        }

        internal static Vehicle InstanceForTestingPurposes()
        {
            return new Vehicle();
        }

        protected Vehicle()
        {
            brand = "Audi";
            model = "Q5";
            year = 2016;
            color = "Blue";
            vin = "QWERTYUI123456789";
        }

        public static Vehicle CreateNewVehicle(VehicleType type, string brand, string model,
           int year, string color, string vin)
        {
            return new Vehicle(type, brand, model, year, color, vin);
        }

        protected Vehicle(VehicleType typeToSet, string brandToSet, string modelToSet,
            int yearToSet, string colorToSet, string vinToSet)
        {
            Type = typeToSet;
            Brand = brandToSet;
            Model = modelToSet;
            Year = yearToSet;
            Color = colorToSet;
            Vin = vinToSet;
        }
    }
}

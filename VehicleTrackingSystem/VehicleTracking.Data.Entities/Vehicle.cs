﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace VehicleTracking_Data_Entities
{
    public class Vehicle
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
                        ErrorMessages.BrandIsInvalid, value);
                    throw new VehicleException(errorMessage);
                }
            }
        }

        protected bool IsValidBrand(string value)
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
                        ErrorMessages.ModelIsInvalid, value);
                    throw new VehicleException(errorMessage);
                }
            }
        }

        protected bool IsValidModel(string value)
        {
            return Utilities.ContainsLettersOrDigitsOnly(value)
                || Utilities.ContainsLettersOrSpacesOnly(value);
        }

        private short year;
        public short Year
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
                        ErrorMessages.YearIsInvalid, value);
                    throw new VehicleException(errorMessage);
                }
            }
        }

        protected bool IsValidYear(int value)
        {
            return Utilities.IsValidYear(value);
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
                        ErrorMessages.ColorIsInvalid, value);
                    throw new VehicleException(errorMessage);
                }
            }
        }

        private bool IsValidColor(string value)
        {
            return Utilities.ContainsLettersOrSpacesOnly(value);
        }

        private string vin;
        public string VIN
        {
            get { return vin; }
            set
            {
                if (IsValidVIN(value))
                {
                    vin = value.Trim();
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.VINIsInvalid, value);
                    throw new VehicleException(errorMessage);
                }
            }
        }

        protected bool IsValidVIN(string value)
        {
            return Utilities.IsValidVIN(value);
        }

        public ProcessData StagesData { get; set; }

        public bool IsLotted => Utilities.IsNotNull(StagesData.PortLot);

        public ProcessStages CurrentStage
        {
            get { return StagesData.CurrentStage; }
            set { StagesData.CurrentStage = value; }
        }

        public Lot PortLot
        {
            get { return StagesData.PortLot; }
            set
            {
                StagesData.RegisterPortLot(value);
            }
        }

        public Inspection PortInspection
        {
            get { return StagesData.PortInspection; }
            set
            {
                StagesData.RegisterPortInspection(value);
            }
        }

        public Transport TransportData => StagesData.TransportData;

        public Inspection YardInspection
        {
            get { return StagesData.YardInspection; }
            set
            {
                StagesData.RegisterYardInspection(value);
            }
        }

        public ICollection<Movement> Movements => StagesData.YardMovements;

        public bool IsReadyForSale => CurrentStage == ProcessStages.READY_FOR_SALE;

        public bool IsReadyForTransport()
        {
            return StagesData.IsReadyForTransport();
        }

        internal void SetTransportStartData(Transport someTransport)
        {
            StagesData.SetTransportStartData(someTransport);
        }

        internal void SetTransportEndData()
        {
            StagesData.SetTransportEndData();
        }

        public Movement RegisterNewMovementToSubzone(User responsible,
           DateTime datetimeOfMovement, Subzone destination)
        {
            return StagesData.RegisterNewMovementToSubzone(responsible,
                datetimeOfMovement, destination);
        }

        public Sale SaleRecord => StagesData.SaleRecord;

        internal void RegisterSale(Sale associatedSale)
        {
            StagesData.RegisterVehicleSale(associatedSale);
        }

        internal static Vehicle InstanceForTestingPurposes()
        {
            return new Vehicle()
            {
                StagesData = new ProcessData()
            };
        }

        protected Vehicle()
        {
            brand = "Marca inválida";
            model = "Vehículo inválido";
            year = 1912;
            color = "Color inválido";
            vin = "VININVLDOVNINVLDO";
        }

        public static Vehicle CreateNewVehicle(VehicleType type, string brand, string model,
           short year, string color, string VIN)
        {
            return new Vehicle(type, brand, model, year, color, VIN);
        }

        protected Vehicle(VehicleType typeToSet, string brandToSet, string modelToSet,
            short yearToSet, string colorToSet, string VINToSet)
        {
            Type = typeToSet;
            Brand = brandToSet;
            Model = modelToSet;
            Year = yearToSet;
            Color = colorToSet;
            VIN = VINToSet;
            StagesData = new ProcessData();
        }

        public override bool Equals(object obj)
        {
            Vehicle vehicleToCompareAgainst = obj as Vehicle;
            if (Utilities.IsNotNull(vehicleToCompareAgainst))
            {
                return vin.Equals(vehicleToCompareAgainst.vin);
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
            return vin + ". " + brand + " " + model + ". " + year;
        }
    }
}
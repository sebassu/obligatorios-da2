using System;
using System.Globalization;

namespace Domain
{
    public class Sale
    {
        private Customer buyer;
        public Customer Buyer
        {
            get { return buyer; }
            set
            {
                if (IsValidBuyer(value))
                {
                    buyer = value;
                }
                else
                {
                    throw new SaleException(ErrorMessages.BuyerIsNull);
                }
            }
        }

        protected static bool IsValidBuyer(Customer value)
        {
            return Utilities.IsNotNull(value);
        }

        private string vehicleVIN;
        public string VehicleVIN
        {
            get { return vehicleVIN; }
            set
            {
                if (IsValidVIN(value))
                {
                    vehicleVIN = value;
                }
                else
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                       ErrorMessages.VINIsInvalid, value);
                    throw new SaleException(errorMessage);
                }
            }
        }

        protected bool IsValidVIN(string value)
        {
            return Utilities.IsValidVIN(value);
        }

        private int sellingPrice;
        public int SellingPrice
        {
            get { return sellingPrice; }
            set
            {
                if (IsValidPrice(value))
                {
                    sellingPrice = value;
                }
                else
                {
                    throw new SaleException(ErrorMessages.SalePriceMustBePositive);
                }
            }
        }

        protected bool IsValidPrice(int value)
        {
            return value > 0;
        }

        private DateTime dateTime;
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                if (IsValidSaleDate(value))
                {
                    dateTime = value;
                }
                else
                {
                    throw new SaleException(ErrorMessages.DateIsInvalid);
                }
            }
        }

        protected bool IsValidSaleDate(DateTime value)
        {
            return Utilities.IsValidDate(value);
        }

        internal static Sale InstanceForTestingPurposes()
        {
            return new Sale();
        }

        private Sale() { }
    }
}
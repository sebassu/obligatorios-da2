using System;
using VehicleTracking_Data_Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Services
{
    public class SaleDTO
    {
        [Required]
        public string BuyerName { get; set; }

        [Required]
        public string BuyerPhoneNumber { get; set; }

        [Required]
        public int SellingPrice { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public string VehicleVIN { get; set; }

        internal static SaleDTO FromSale(Sale someSale)
        {
            return new SaleDTO(someSale);
        }

        public SaleDTO(Sale someSale)
        {
            BuyerName = someSale.Buyer.Name;
            BuyerPhoneNumber = someSale.Buyer.PhoneNumber;
            SellingPrice = someSale.SellingPrice;
            DateTime = someSale.DateTime;
            VehicleVIN = someSale.VehicleVIN;
        }
    }
}
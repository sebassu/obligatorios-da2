using System;
using System.ComponentModel.DataAnnotations;
using VehicleTracking_Data_Entities;

namespace API.Services
{
    public class SaleDTO
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerPhoneNumber { get; set; }

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
            CustomerName = someSale.Buyer.Name;
            CustomerPhoneNumber = someSale.Buyer.PhoneNumber;
            SellingPrice = someSale.SellingPrice;
            DateTime = someSale.DateTime;
            VehicleVIN = someSale.VehicleVIN;
        }
    }
}
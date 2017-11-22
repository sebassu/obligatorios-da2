using System.Linq;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;

namespace API.Services
{
    public class SaleServices : ISaleServices
    {
        internal IUnitOfWork Model { get; }
        internal ISaleRepository Sales { get; }

        public SaleServices()
        {
            Model = new UnitOfWork();
            Sales = Model.Sales;
        }

        public SaleServices(IUnitOfWork someUnitOfWork)
        {
            Model = someUnitOfWork;
            Sales = someUnitOfWork.Sales;
        }

        public int AddNewSaleFromData(string vinToModify, SaleDTO saleData)
        {
            var soldVehicle = Model.Vehicles.GetVehicleWithVIN(vinToModify);
            var buyer = GetCustomerFromData(saleData);
            var addedSale = AddNewSaleWithData(saleData, soldVehicle, buyer);
            return addedSale.Id;
        }

        private Sale AddNewSaleWithData(SaleDTO saleData, Vehicle soldVehicle, Customer buyer)
        {
            var saleToAdd = Sale.FromBuyerVehiclePriceDateTime(buyer, soldVehicle,
                saleData.SellingPrice, saleData.DateTime);
            Sales.AddNewSale(saleToAdd);
            Model.SaveChanges();
            return saleToAdd;
        }

        private Customer GetCustomerFromData(SaleDTO saleData)
        {
            var name = saleData.BuyerName;
            var phoneNumber = saleData.BuyerPhoneNumber;
            try
            {
                return Model.Customers.GetCustomerWithData(name, phoneNumber);
            }
            catch (RepositoryException)
            {
                return Customer.FromNamePhoneNumber(name, phoneNumber);
            }
        }

        public IEnumerable<SaleDTO> GetRegisteredSales()
        {
            return Sales.Elements.Select(s => SaleDTO.FromSale(s));
        }
    }
}
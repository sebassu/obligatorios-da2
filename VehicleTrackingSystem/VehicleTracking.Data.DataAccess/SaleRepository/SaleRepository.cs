using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    internal class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(VTSystemContext someContext)
            : base(someContext) { }

        public IEnumerable<Sale> Elements => GetElementsWith("Buyer");

        public void AddNewSale(Sale saleToAdd)
        {
            Add(saleToAdd);
        }
    }
}
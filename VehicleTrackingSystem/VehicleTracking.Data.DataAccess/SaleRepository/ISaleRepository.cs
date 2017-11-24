using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    public interface ISaleRepository
    {
        void AddNewSale(Sale saleToAdd);
        IEnumerable<Sale> Elements { get; }
    }
}
using System.Collections.Generic;

namespace API.Services
{
    public interface ISaleServices
    {
        int AddNewSaleFromData(string vinToModify, SaleDTO saleData);
        IEnumerable<SaleDTO> GetRegisteredSales();
    }
}
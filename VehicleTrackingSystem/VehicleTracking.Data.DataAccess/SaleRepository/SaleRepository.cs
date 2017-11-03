using System.Collections.Generic;
using Domain;

namespace Persistence
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
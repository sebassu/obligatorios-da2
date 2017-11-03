using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface ISaleRepository
    {
        void AddNewSale(Sale saleToAdd);
        IEnumerable<Sale> Elements { get; }
    }
}
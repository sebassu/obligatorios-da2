using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface ILotRepository
    {
        void AddNewLot(Lot lotToAdd);
        IEnumerable<Lot> Elements { get; }
    }
}

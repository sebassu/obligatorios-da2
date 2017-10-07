using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface ILotRepository
    {
        void AddNewLot(Lot lotToAdd);
        IEnumerable<Lot> Elements { get; }
        Lot GetLotWithId(int IdToFind);
        void RemoveLotWithId(int lotToRemove);
        void UpdateLot(Lot lotToModify);
    }
}

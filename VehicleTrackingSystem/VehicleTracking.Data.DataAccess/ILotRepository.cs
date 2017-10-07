using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface ILotRepository
    {
        void AddNewLot(Lot lotToAdd);
        IEnumerable<Lot> Elements { get; }
        Lot GetLotById(int idToFind);
        void UpdateLot(Lot lotToModify);
        void RemoveLotWithId(int lotToRemove);
        bool ExistsLotWithName(string nameToFind);
    }
}

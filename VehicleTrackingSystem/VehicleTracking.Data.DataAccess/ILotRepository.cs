using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface ILotRepository
    {
        void AddNewLot(Lot lotToAdd);
        IEnumerable<Lot> Elements { get; }
        Lot GetLotByName(string nameToFind);
        void UpdateLot(Lot lotToModify);
        void RemoveLotWithName(string nameToRemove);
        bool ExistsLotWithName(string nameToFind);
    }
}

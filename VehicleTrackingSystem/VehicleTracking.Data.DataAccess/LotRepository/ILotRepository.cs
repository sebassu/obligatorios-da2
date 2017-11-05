using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    public interface ILotRepository
    {
        void AddNewLot(Lot lotToAdd);
        IEnumerable<Lot> Elements { get; }
        Lot GetLotWithName(string nameToFind);
        void UpdateLot(Lot lotToModify);
        void RemoveLotWithName(string nameToRemove);
        bool ExistsLotWithName(string nameToFind);
    }
}

﻿using Domain;
using System.Collections.Generic;


namespace API.Services
{
    interface ILotServices
    {
        int AddNewLotFromData(LotDTO lotDataToAdd);
        IEnumerable<LotDTO> GetRegisteredLots();
        LotDTO GetLotByName(string nameToFind);
        void ModifyLotWithName(string nameToModify, LotDTO lotDataToSet, ICollection<Vehicle> vehicles);
        void RemoveZoneWithName(string nameToModify);
    }
}

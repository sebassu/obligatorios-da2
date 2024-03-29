﻿using System;
using System.Collections.Generic;

namespace API.Services
{
    public interface ILotServices
    {
        Guid AddNewLotFromData(string activeUsername,
            LotDTO lotDataToAdd);
        IEnumerable<LotDTO> GetRegisteredLots();
        LotDTO GetLotByName(string nameToFind);
        void ModifyLotWithName(string nameToModify, LotDTO lotDataToSet);
        void RemoveLotWithName(string nameToModify);
    }
}
using System.Collections.Generic;

namespace API.Services.Business_Logic
{
    public interface IZoneServices
    {
        int AddNewZoneFromData(ZoneDTO zoneDataToAdd);
        IEnumerable<ZoneDTO> GetRegisteredZones();
        ZoneDTO GetZoneWithName(string vinToLookup);
        void ModifyZoneWithName(string nameToModify,
            ZoneDTO zoneDataToSet);
        void RemoveZoneWithName(string vinToRemove);
    }
}

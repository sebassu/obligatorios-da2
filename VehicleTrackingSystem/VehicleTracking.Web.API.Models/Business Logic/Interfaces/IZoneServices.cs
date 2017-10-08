using System.Collections.Generic;

namespace API.Services
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

using System.Collections.Generic;

namespace API.Services.Business_Logic
{
    interface IZoneSubzoneServices
    {
        int AddNewZoneFromData(ZoneDTO zoneDataToAdd);
        int AddNewSubzoneFromData(string containerName,
            SubzoneDTO subzoneDataToAdd);
        IEnumerable<ZoneDTO> GetRegisteredZones();
        IEnumerable<SubzoneDTO> GetRegisteredSubzones();
        ZoneDTO GetZoneWithName(string vinToLookup);
        SubzoneDTO GetSubzoneWithId(string vinToLookup);
        void ModifyZoneWithName(string nameToModify,
            ZoneDTO zoneDataToSet);
        void ModifySubzoneWithId(int idToModify,
            SubzoneDTO subzoneDataToSet);
        void RemoveZoneWithName(string vinToRemove);
        void RemoveSubzoneWithId(int idToRemove);
    }
}

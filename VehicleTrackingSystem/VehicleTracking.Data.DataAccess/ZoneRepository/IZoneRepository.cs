using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    public interface IZoneRepository
    {
        void AddNewZone(Zone zoneToAdd);
        IEnumerable<Zone> Elements { get; }
        Zone GetZoneWithName(string nameToFind);
        void UpdateZone(Zone zoneToModify);
        void RemoveZone(Zone zoneToRemove);
        bool ExistsZoneWithName(string username);
    }
}
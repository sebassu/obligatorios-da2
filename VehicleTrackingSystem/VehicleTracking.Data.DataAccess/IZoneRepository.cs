using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface IZoneRepository
    {
        void AddNewZone(Zone zoneToAdd);
        IEnumerable<Zone> Elements { get; }
        Zone GetZoneWithName(string nameToFind);
        void UpdateZone(Zone zoneToModify);
        void RemoveZoneWithName(string nameToRemove);
        bool ExistsZoneWithName(string username);
    }
}
using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface IZoneRepository
    {
        IEnumerable<Zone> Elements { get; }
        void AddNewZone(Zone zoneToAdd);
        void UpdateZone(Zone zoneToModify);
        void RemoveZoneWithName(string nameToRemove);
    }
}
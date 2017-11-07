using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    public interface ILocationRepository
    {
        IEnumerable<Location> Elements { get; }
        Location GetLocationWithName(string nameToLookup);
    }
}

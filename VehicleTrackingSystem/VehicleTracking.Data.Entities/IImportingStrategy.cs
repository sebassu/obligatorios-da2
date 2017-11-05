using System;
using System.Collections.Generic;

namespace VehicleTracking_Data_Entities
{
    public interface IImportingStrategy
    {
        Dictionary<string, Type> RequiredParameters { get; }
        IEnumerable<Vehicle> GetVehicles(
            IDictionary<string, object> parameters);
    }
}

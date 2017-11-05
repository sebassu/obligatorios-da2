using System;
using System.Collections.Generic;

namespace Domain
{
    public interface IImportingStrategy
    {
        Dictionary<string, Type> RequiredParameters { get; }
        IEnumerable<Vehicle> GetVehicles(
            IDictionary<string, object> parameters);
    }
}

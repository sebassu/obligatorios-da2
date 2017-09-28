using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> Elements { get; }
        Vehicle GetVehicleByVIN(string vinToLookup);
        int AddNewVehicle(Vehicle vehicleToAdd);
        void UpdateVehicle(Vehicle vehicleToModify);
        void RemoveVehicleByVIN(string usernameToRemove);
        bool ExistsVehicleWithVIN(string usernameToLookup);
    }
}
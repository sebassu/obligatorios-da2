using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface IVehicleRepository
    {
        void AddNewVehicle(Vehicle vehicleToAdd);
        IEnumerable<Vehicle> Elements { get; }
        bool ExistsVehicleWithVIN(string usernameToLookup);
        Vehicle GetVehicleWithVIN(string vinToLookup);
        void UpdateVehicle(Vehicle vehicleToModify);
        void RemoveVehicleWithVIN(string usernameToRemove);
    }
}
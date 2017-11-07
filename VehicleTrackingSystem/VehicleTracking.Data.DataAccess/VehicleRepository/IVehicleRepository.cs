using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    public interface IVehicleRepository
    {
        void AddNewVehicle(Vehicle vehicleToAdd);
        IEnumerable<Vehicle> Elements { get; }
        bool ExistsVehicleWithVIN(string usernameToLookup);
        Vehicle GetVehicleWithVIN(string vinToLookup);
        void UpdateVehicle(Vehicle vehicleToModify);
        void RemoveVehicleWithVIN(string usernameToRemove);
        Vehicle GetFullyLoadedVehicleWithVIN(string vinToLookup);
    }
}
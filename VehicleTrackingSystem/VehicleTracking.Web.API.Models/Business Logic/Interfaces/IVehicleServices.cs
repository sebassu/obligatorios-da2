using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace API.Services
{
    public interface IVehicleServices
    {
        IEnumerable<VehicleDTO> GetRegisteredVehicles();
        VehicleDTO GetVehicleWithVIN(string vinToLookup);
        int AddNewVehicleFromData(VehicleDTO vehicleToAdd);
        void RemoveVehicleWithVIN(string vinToRemove);
        void ModifyVehicleWithVIN(string vinToModify, VehicleDTO vehicleDataToSet);
    }
}
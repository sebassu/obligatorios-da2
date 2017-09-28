using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Tests")]
namespace API.Services
{
    public interface IVehicleServices
    {
        int AddNewVehicleFromData(VehicleDTO vehicleToAdd);
        IEnumerable<VehicleDTO> GetRegisteredVehicles();
        VehicleDTO GetVehicleWithVIN(string vinToLookup);
        void ModifyVehicleWithVIN(string vinToModify,
            VehicleDTO vehicleDataToSet);
        void RemoveVehicleWithVIN(string vinToRemove);
    }
}
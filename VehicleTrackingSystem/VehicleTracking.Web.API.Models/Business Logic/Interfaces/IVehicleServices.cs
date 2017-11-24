using System;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Tests")]
namespace API.Services
{
    public interface IVehicleServices
    {
        int AddNewVehicleFromData(VehicleDTO vehicleToAdd);
        IEnumerable<VehicleDTO> GetRegisteredVehiclesFor(UserRoles
            roleToProcess);
        VehicleDTO GetVehicleWithVIN(string vinToLookup);
        void ModifyVehicleWithVIN(string vinToModify,
            VehicleDTO vehicleDataToSet);
        void RemoveVehicleWithVIN(string vinToRemove);
        int AddNewMovementFromData(string responsibleUsername,
            string vinToModify, MovementDTOIn movementData);
        HistoryDTO GetHistoryForVehicleWithVIN(string vinToLookup);
    }
}
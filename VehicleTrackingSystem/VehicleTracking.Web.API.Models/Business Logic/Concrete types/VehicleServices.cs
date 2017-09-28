﻿using Domain;
using Persistence;
using System.Collections.Generic;

namespace API.Services
{
    public class VehicleServices : IVehicleServices
    {
        internal IVehicleRepository Model { get; }

        public VehicleServices(IVehicleRepository someRepository = null)
        {
            Model = someRepository;
        }

        public int AddNewVehicleFromData(VehicleDTO vehicleDataToAdd)
        {
            if (Utilities.IsNotNull(vehicleDataToAdd))
            {
                return AttemptToAddVehicle(vehicleDataToAdd);
            }
            else
            {
                throw new ServiceException(ErrorMessages.NullDTOReference);
            }
        }

        private int AttemptToAddVehicle(VehicleDTO vehicleDataToAdd)
        {
            bool vinIsNotRegistered =
                !Model.ExistsVehicleWithVIN(vehicleDataToAdd.VIN);
            if (vinIsNotRegistered)
            {
                Vehicle vehicleToAdd = vehicleDataToAdd.ToVehicle();
                return Model.AddNewVehicle(vehicleToAdd);
            }
            else
            {
                throw new ServiceException("El VIN del vehiculo debe ser único.");
            }
        }

        public IEnumerable<VehicleDTO> GetRegisteredVehicles()
        {
            var result = new List<VehicleDTO>();
            foreach (var vehicle in Model.Elements)
            {
                result.Add(VehicleDTO.FromVehicle(vehicle));
            }
            return result.AsReadOnly();
        }

        public VehicleDTO GetVehicleWithVIN(string vinToLookup)
        {
            Vehicle vehicleFound = Model.GetVehicleByVIN(vinToLookup);
            return VehicleDTO.FromVehicle(vehicleFound);
        }

        public void ModifyVehicleWithVIN(string vinToModify, VehicleDTO vehicleDataToSet)
        {
            ServiceUtilities.CheckParameterIsNotNullAndExecute(vehicleDataToSet,
            delegate { AttemptToPerformModification(vinToModify, vehicleDataToSet); });

        }

        private void AttemptToPerformModification(string vinToModify,
            VehicleDTO vehicleData)
        {
            Vehicle vehicleFound = Model.GetVehicleByVIN(vinToModify);
            vehicleData.SetDataToVehicle(vehicleFound);
            Model.UpdateVehicle(vehicleFound);
        }

        public void RemoveVehicleWithVIN(string vinToRemove)
        {
            Model.RemoveVehicleByVIN(vinToRemove);
        }
    }
}
using Domain;
using Persistence;
using System.Collections.Generic;
using System.Globalization;

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
            Vehicle vehicleToAdd = vehicleDataToAdd.ToVehicle();
            return Model.AddNewVehicle(vehicleToAdd);
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
            Vehicle vehicleFound = Model.GetVehicleWithVIN(vinToLookup);
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
            if (ChangeCausesRepeatedVINs(vinToModify, vehicleData))
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.FieldMustBeUnique, "VIN");
                throw new ServiceException(errorMessage);
            }
            else
            {
                Vehicle vehicleFound = Model.GetVehicleWithVIN(vinToModify);
                vehicleData.SetDataToVehicle(vehicleFound);
                Model.UpdateVehicle(vehicleFound);
            }
        }

        private bool ChangeCausesRepeatedVINs(string currentVIN, VehicleDTO vehicleData)
        {
            bool usernameChanges = !currentVIN.Equals(vehicleData.VIN);
            return usernameChanges && Model.ExistsVehicleWithVIN(vehicleData.VIN);
        }

        public void RemoveVehicleWithVIN(string vinToRemove)
        {
            Model.RemoveVehicleWithVIN(vinToRemove);
        }
    }
}
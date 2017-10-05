using Domain;
using Persistence;
using System.Collections.Generic;
using System.Globalization;

namespace API.Services
{
    public class VehicleServices : IVehicleServices
    {
        internal IUnitOfWork Model { get; }
        internal IVehicleRepository Vehicles { get; }

        public VehicleServices()
        {
            Model = new UnitOfWork();
            Vehicles = Model.Vehicles;
        }

        public VehicleServices(IUnitOfWork someUnitOfWork)
        {
            Model = someUnitOfWork;
            Vehicles = someUnitOfWork.Vehicles;
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
                !Vehicles.ExistsVehicleWithVIN(vehicleDataToAdd.VIN);
            if (vinIsNotRegistered)
            {
                Vehicle vehicleToAdd = vehicleDataToAdd.ToVehicle();
                return Vehicles.AddNewVehicle(vehicleToAdd);
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.FieldMustBeUnique, "VIN");
                throw new ServiceException(errorMessage);
            }
        }

        public IEnumerable<VehicleDTO> GetRegisteredVehicles()
        {
            var result = new List<VehicleDTO>();
            foreach (var vehicle in Vehicles.Elements)
            {
                result.Add(VehicleDTO.FromVehicle(vehicle));
            }
            return result.AsReadOnly();
        }

        public VehicleDTO GetVehicleWithVIN(string vinToLookup)
        {
            Vehicle vehicleFound = Vehicles.GetVehicleWithVIN(vinToLookup);
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
                Vehicle vehicleFound = Vehicles.GetVehicleWithVIN(vinToModify);
                vehicleData.SetDataToVehicle(vehicleFound);
                Vehicles.UpdateVehicle(vehicleFound);
            }
        }

        private bool ChangeCausesRepeatedVINs(string currentVIN, VehicleDTO vehicleData)
        {
            bool usernameChanges = !currentVIN.Equals(vehicleData.VIN);
            return usernameChanges && Vehicles.ExistsVehicleWithVIN(vehicleData.VIN);
        }

        public void RemoveVehicleWithVIN(string vinToRemove)
        {
            Vehicles.RemoveVehicleWithVIN(vinToRemove);
        }
    }
}
using System.Globalization;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;
using System.Linq;

namespace API.Services
{
    public class VehicleServices : IVehicleServices
    {
        internal IUnitOfWork Model { get; }
        internal IVehicleRepository Vehicles { get; }
        private IFlowRepository Flows;
        private Flow actualFlow;

        public VehicleServices()
        {
            Model = new UnitOfWork();
            Vehicles = Model.Vehicles;
            Flows = Model.Flow;
            actualFlow = Flows.GetCurrentFlow();
        }

        public VehicleServices(IUnitOfWork someUnitOfWork)
        {
            Model = someUnitOfWork;
            Vehicles = someUnitOfWork.Vehicles;
            Flows = Model.Flow;
            actualFlow = Flows.GetCurrentFlow();
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
                Vehicles.AddNewVehicle(vehicleToAdd);
                Model.SaveChanges();
                return vehicleToAdd.Id;
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
                Model.SaveChanges();
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
            Model.SaveChanges();
        }

        public int AddNewMovementFromData(string responsibleUsername, string vinToModify,
            MovementDTOIn movementDataToAdd)
        {
            if (Utilities.IsNotNull(movementDataToAdd))
            {
                Vehicle actualVehicle = Vehicles.GetFullyLoadedVehicleWithVIN(vinToModify);
                if (IsValidMovementVehicle(actualVehicle))
                {
                    if (IsValidMovementSubzone(movementDataToAdd, actualVehicle))
                    {
                        return AttemptToAddNewMovementFromData(responsibleUsername,
                            vinToModify, movementDataToAdd);
                    }
                    else
                    {
                        throw new ServiceException(ErrorMessages.InvalidMovementSubzone);
                    }
                }
                else
                {
                    throw new ServiceException(ErrorMessages.InvalidMovementVehicle);
                }
            }
            else
            {
                throw new ServiceException(ErrorMessages.NullDTOReference);
            }
        }

        private bool IsValidMovementVehicle(Vehicle actualVehicle)
        {
            if (actualVehicle.CurrentStage.Equals(ProcessStages.YARD))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsValidMovementSubzone(MovementDTOIn movementData, Vehicle actualVehicle)
        {
            ISubzoneServices subzoneInstance = new SubzoneServices();
            SubzoneDTO arrivalSubzone = subzoneInstance.GetSubzoneWithId(movementData.ArrivalSubzoneId);
            Subzone departureSubzone = actualVehicle.Movements.Last().Arrival;
            if (BelongsToFlowAndIsNextSubzone(departureSubzone.Name, arrivalSubzone.Name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool BelongsToFlowAndIsNextSubzone(string departure, string arrival)
        {
            if (DoesBelongToFlow(arrival))
            {
                IEnumerable<string> flowList = actualFlow.RequiredSubzoneNames;
                for (int i = 0; i < flowList.Count(); i++)
                {
                    if (flowList.ElementAt(i).Equals(departure) && flowList.ElementAt(i + 1).Equals(arrival))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool DoesBelongToFlow(string subzoneName)
        {
            return actualFlow.RequiredSubzoneNames.Contains(subzoneName);
        }

        private int AttemptToAddNewMovementFromData(string responsibleUsername,
            string vinToModify, MovementDTOIn movementData)
        {
            User responsible = Model.Users.GetUserWithUsername(responsibleUsername);
            Vehicle movedVehicle = Vehicles.GetVehicleWithVIN(vinToModify);
            Subzone destination = Model.Subzones.GetSubzoneWithId(movementData.ArrivalSubzoneId);
            Movement movementToAdd = movedVehicle.RegisterNewMovementToSubzone(responsible,
                movementData.DateTime, destination);
            return AddNewMovement(movedVehicle, movementToAdd);
        }

        private int AddNewMovement(Vehicle movedVehicle, Movement movementToAdd)
        {
            Model.Movements.AddNewMovement(movementToAdd);
            Vehicles.UpdateVehicle(movedVehicle);
            SetReadyForSale(movedVehicle, movementToAdd.Arrival);
            Model.SaveChanges();
            return movementToAdd.Id;
        }

        private void SetReadyForSale(Vehicle movedVehicle, Subzone arrival)
        {
            if (actualFlow.RequiredSubzoneNames.Last().Equals(arrival.Name))
            {
                movedVehicle.CurrentStage = ProcessStages.READY_FOR_SALE;
            }
        }

        public HistoryDTO GetHistoryForVehicleWithVIN(string vinToLookup)
        {
            Vehicle vehicleFound = Vehicles.GetFullyLoadedVehicleWithVIN(vinToLookup);
            return HistoryDTO.FromFullyLoadedVehicle(vehicleFound);
        }
    }
}
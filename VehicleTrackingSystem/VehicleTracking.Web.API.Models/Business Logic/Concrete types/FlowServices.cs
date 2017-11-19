using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;

namespace API.Services
{
    public class FlowServices : IFlowServices
    {
        internal IUnitOfWork Model { get; }
        internal IFlowRepository Flows { get; }

        public FlowServices()
        {
            Model = new UnitOfWork();
            Flows = Model.Flow;

        }

        public FlowServices(IUnitOfWork someUnitOfWork)
        {
            Model = someUnitOfWork;
            Flows = someUnitOfWork.Flow;
        }

        public int AddNewFlowFromData(List<string> flowDataToAdd)
        {
            if (Utilities.IsNotNull(flowDataToAdd))
            {
                return AttemptToAddFlow(flowDataToAdd);
            }
            else
            {
                throw new ServiceException(ErrorMessages.NotNullValues);
            }
        }

        private int AttemptToAddFlow(List<string> flowDataToAdd)
        {
            Flow flowToAdd = Flow.FromSubzoneNames(flowDataToAdd);
            Flows.RegisterNewFlow(flowToAdd);
            SetStuckVehicles();
            Model.SaveChanges();
            return flowToAdd.Id;
        }

        private void SetStuckVehicles()
        {
            IVehicleServices Vehicles = new VehicleServices();
            IEnumerable<VehicleDTO> registeredVehicles = Vehicles.GetRegisteredVehicles();
            foreach(var vDTO in registeredVehicles)
            {
                Vehicle v = Model.Vehicles.GetVehicleWithVIN(vDTO.VIN);
                AttemptToStuckVehicle(v);
            }
        }

        private void AttemptToStuckVehicle(Vehicle vehicle)
        {
            if (vehicle.Movements.Count > 0)
            {
                vehicle.CurrentStage = ProcessStages.STUCK_IN_PROCESS;
            }
        }

        public Flow GetRegisteredFlow()
        {
            return Flows.GetCurrentFlow();
        }
    }
}
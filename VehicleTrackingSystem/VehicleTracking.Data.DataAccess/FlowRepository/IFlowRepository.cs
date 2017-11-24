using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    public interface IFlowRepository
    {
        void RegisterNewFlow(Flow flowToRegister);
        Flow GetCurrentFlow();
    }
}
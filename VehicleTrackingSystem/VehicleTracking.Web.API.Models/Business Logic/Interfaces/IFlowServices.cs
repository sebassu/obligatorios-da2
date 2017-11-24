using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace API.Services
{
    public interface IFlowServices
    {
        int AddNewFlowFromData(List<string> flowDataToAdd);
        Flow GetRegisteredFlow();
    }
}

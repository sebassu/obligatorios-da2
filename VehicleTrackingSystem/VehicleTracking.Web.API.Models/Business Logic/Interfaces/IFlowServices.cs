using Domain;
using System.Collections.Generic;

namespace API.Services
{
    public interface IFlowServices
    {
        int AddNewFlowFromData(List<string> flowDataToAdd);
        Flow GetRegisteredFlow();
    }
}

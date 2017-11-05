using System.Linq;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    internal class FlowRepository : GenericRepository<Flow>,
        IFlowRepository
    {
        public FlowRepository(VTSystemContext someContext)
            : base(someContext) { }

        public Flow GetCurrentFlow()
        {
            return context.Flow.Single();
        }

        public void RegisterNewFlow(Flow flowToRegister)
        {
            var flowDbSet = context.Flow;
            flowDbSet.RemoveRange(flowDbSet);
            Add(flowToRegister);
        }
    }
}
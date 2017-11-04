using Domain;
using System.Linq;

namespace Persistence
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
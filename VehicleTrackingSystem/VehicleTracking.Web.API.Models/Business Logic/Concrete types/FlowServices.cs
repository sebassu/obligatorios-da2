using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Model.SaveChanges();
                return flowToAdd.Id;
        }

        public Flow GetRegisteredFlow()
        {
            return Flows.GetCurrentFlow();
        }
    }
}

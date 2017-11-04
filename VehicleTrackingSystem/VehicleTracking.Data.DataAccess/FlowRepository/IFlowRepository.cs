using Domain;

namespace Persistence
{
    public interface IFlowRepository
    {
        void RegisterNewFlow(Flow flowToRegister);
        Flow GetCurrentFlow();
    }
}
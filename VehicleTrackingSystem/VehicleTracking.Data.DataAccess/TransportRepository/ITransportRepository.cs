using Domain;

namespace Persistence
{
    public interface ITransportRepository
    {
        void AddNewTransport(Transport transportToAdd);
        Transport GetTransportWithId(int idToLookup);
        void UpdateTransport(Transport transportToModify);
    }
}

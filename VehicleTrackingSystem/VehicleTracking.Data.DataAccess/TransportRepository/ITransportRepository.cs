using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface ITransportRepository
    {
        void AddNewTransport(Transport transportToAdd);
        IEnumerable<Transport> Elements { get; }
        Transport GetTransportWithId(int idToLookup);
        void UpdateTransport(Transport transportToModify);
    }
}
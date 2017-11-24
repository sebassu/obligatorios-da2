using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    public interface ITransportRepository
    {
        void AddNewTransport(Transport transportToAdd);
        IEnumerable<Transport> Elements { get; }
        Transport GetTransportWithId(int idToLookup);
        void UpdateTransport(Transport transportToModify);
    }
}
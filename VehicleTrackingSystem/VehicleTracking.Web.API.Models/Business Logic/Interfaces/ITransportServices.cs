using System;
using System.Collections.Generic;

namespace API.Services
{
    public interface ITransportServices
    {
        int StartNewTransportFromData(string activeUsername,
            TransportDTO transportData);
        ICollection<TransportDTO> GetRegisteredTransports();
        void FinalizeTransport(string activeUsername, int transportIdToFinalize,
            DateTime finalizationDateTime);
    }
}
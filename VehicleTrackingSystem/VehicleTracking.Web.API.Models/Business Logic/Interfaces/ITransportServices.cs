using System;

namespace API.Services
{
    public interface ITransportServices
    {
        int StartNewTransportFromData(string activeUsername,
            TransportDTO transportData);
        void FinalizeTransport(string activeUsername, int transportIdToFinalize,
            DateTime finalizationDateTime);
    }
}
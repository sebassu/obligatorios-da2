using System;

namespace Domain
{
    [Serializable]
    public class TransportException : VehicleTrackingException
    {
        public TransportException(string message) : base(message) { }
    }
}
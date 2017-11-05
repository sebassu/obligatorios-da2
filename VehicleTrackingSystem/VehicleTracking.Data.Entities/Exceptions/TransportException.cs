using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class TransportException : VehicleTrackingException
    {
        public TransportException(string message) : base(message) { }
    }
}
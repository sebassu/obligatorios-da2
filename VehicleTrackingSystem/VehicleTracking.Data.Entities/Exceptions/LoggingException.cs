using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class LoggingException : VehicleTrackingException
    {
        public LoggingException(string message) : base(message) { }
    }
}
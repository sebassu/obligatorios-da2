using System;

namespace Domain
{
    [Serializable]
    public class LoggingException : VehicleTrackingException
    {
        public LoggingException(string message) : base(message) { }
    }
}
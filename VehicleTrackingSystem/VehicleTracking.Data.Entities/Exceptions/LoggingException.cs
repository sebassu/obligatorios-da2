using System;

namespace Domain
{
    [Serializable]
    public class LoggingRecordException : VehicleTrackingException
    {
        public LoggingRecordException(string message) : base(message) { }
    }
}
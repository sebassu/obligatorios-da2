using System;

namespace Domain
{
    [Serializable]
    public class ProcessException : VehicleTrackingException
    {
        public ProcessException(string message) : base(message) { }
    }
}
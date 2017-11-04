using System;

namespace Domain
{
    [Serializable]
    public class FlowException : VehicleTrackingException
    {
        public FlowException(string message) : base(message) { }
    }
}
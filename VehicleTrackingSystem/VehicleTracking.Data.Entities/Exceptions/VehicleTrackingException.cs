using System;

namespace Domain
{
    [Serializable]
    public class VehicleTrackingException : ArgumentException
    {
        public VehicleTrackingException(string message) : base(message) { }
    }
}
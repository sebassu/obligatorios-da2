using System;

namespace Domain
{
    [Serializable]
    public class VehicleException : VehicleTrackingException
    {
        public VehicleException(string message) : base(message) { }
    }
}

using System;

namespace Domain
{
    [Serializable]
    public class ZoneException : VehicleTrackingException
    {
        public ZoneException(string message) : base(message) { }
    }
}
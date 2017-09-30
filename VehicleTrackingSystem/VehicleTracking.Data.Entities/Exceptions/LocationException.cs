using System;

namespace Domain
{
    [Serializable]
    public class LocationException : VehicleTrackingException
    {
        public LocationException(string message) : base(message) { }
    }
}
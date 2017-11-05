using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class LocationException : VehicleTrackingException
    {
        public LocationException(string message) : base(message) { }
    }
}
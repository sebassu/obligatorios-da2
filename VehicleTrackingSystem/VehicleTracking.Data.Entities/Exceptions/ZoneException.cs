using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class ZoneException : VehicleTrackingException
    {
        public ZoneException(string message) : base(message) { }
    }
}
using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class VehicleTrackingException : ArgumentException
    {
        public VehicleTrackingException(string message) : base(message) { }
    }
}
using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class VehicleException : VehicleTrackingException
    {
        public VehicleException(string message) : base(message) { }
    }
}
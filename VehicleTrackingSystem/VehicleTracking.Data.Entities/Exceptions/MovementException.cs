using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class MovementException : VehicleTrackingException
    {
        public MovementException(string message) : base(message) { }
    }
}
using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class ReflectionException : VehicleTrackingException
    {
        public ReflectionException(string message) : base(message) { }
    }
}
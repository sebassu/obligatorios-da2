using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class CustomerException : VehicleTrackingException
    {
        public CustomerException(string message) : base(message) { }
    }
}
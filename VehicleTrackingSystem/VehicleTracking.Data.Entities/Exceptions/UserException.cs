using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class UserException : VehicleTrackingException
    {
        public UserException(string message) : base(message) { }
    }
}
using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class DamageException : VehicleTrackingException
    {
        public DamageException(string message) : base(message) { }
    }
}
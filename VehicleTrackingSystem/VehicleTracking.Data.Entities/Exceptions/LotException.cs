using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class LotException : VehicleTrackingException
    {
        public LotException(string message) : base(message) { }
    }
}
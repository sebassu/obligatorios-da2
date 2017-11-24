using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class FlowException : VehicleTrackingException
    {
        public FlowException(string message) : base(message) { }
    }
}
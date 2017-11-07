using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class ProcessException : VehicleTrackingException
    {
        public ProcessException(string message) : base(message) { }
    }
}
using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class InspectionException : VehicleTrackingException
    {
        public InspectionException(string message) : base(message) { }
    }
}
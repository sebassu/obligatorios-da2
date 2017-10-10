using System;

namespace Domain
{
    [Serializable]
    public class InspectionException : VehicleTrackingException
    {
        public InspectionException(string message) : base(message) { }

    }
}
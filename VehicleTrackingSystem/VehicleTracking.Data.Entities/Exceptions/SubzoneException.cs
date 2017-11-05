using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class SubzoneException : VehicleTrackingException
    {
        public SubzoneException(string message) : base(message) { }
    }
}
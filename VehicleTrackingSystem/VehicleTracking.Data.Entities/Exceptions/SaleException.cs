using System;

namespace VehicleTracking_Data_Entities
{
    [Serializable]
    public class SaleException : VehicleTrackingException
    {
        public SaleException(string message) : base(message) { }
    }
}
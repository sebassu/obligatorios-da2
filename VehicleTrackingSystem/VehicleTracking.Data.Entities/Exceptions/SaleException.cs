using System;

namespace Domain
{
    [Serializable]
    public class SaleException : VehicleTrackingException
    {
        public SaleException(string message) : base(message) { }
    }
}
using System;

namespace Domain
{
    [Serializable]
    public class CustomerException : VehicleTrackingException
    {
        public CustomerException(string message) : base(message) { }
    }
}
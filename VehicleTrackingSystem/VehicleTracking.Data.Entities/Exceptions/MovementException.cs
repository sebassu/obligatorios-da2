using System;

namespace Domain
{
    [Serializable]
    public class MovementException : VehicleTrackingException
    {
        public MovementException(string message) : base(message) { }
    }
}
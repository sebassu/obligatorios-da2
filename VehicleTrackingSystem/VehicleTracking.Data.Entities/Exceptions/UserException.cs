using System;

namespace Domain
{
    [Serializable]
    public class UserException : VehicleTrackingException
    {
        public UserException(string message) : base(message) { }
    }
}
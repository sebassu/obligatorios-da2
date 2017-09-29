using System;

namespace Domain
{
    [Serializable]
    public class DamageException : VehicleTrackingException
    {
        public DamageException(string message) : base(message) { }
    }
}
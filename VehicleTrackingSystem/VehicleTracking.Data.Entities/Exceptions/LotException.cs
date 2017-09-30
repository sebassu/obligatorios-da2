using System;

namespace Domain
{
    [Serializable]
    public class LotException : VehicleTrackingException
    {
        public LotException(string message) : base(message) { }
    }
}
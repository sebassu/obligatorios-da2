using System;

namespace Domain
{
    [Serializable]
    public class SubzoneException : VehicleTrackingException
    {
        public SubzoneException(string message) : base(message) { }
    }
}

using System;

namespace Domain
{
    [Serializable]
    public class VehicleException : VTSystemException
    {
        public VehicleException() : base() { }
        public VehicleException(string message) : base(message) { }
    }
}

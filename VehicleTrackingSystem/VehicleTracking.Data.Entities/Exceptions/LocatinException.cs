using System;

namespace Domain
{
    [Serializable]
    public class LocationException : VTSystemException
    {
        public LocationException(string message) : base(message) { }
    }
}
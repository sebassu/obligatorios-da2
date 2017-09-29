using System;

namespace Domain
{
    [Serializable]
    public class RepositoryException : VehicleTrackingException
    {
        public RepositoryException(string message) : base(message) { }
    }
}
using Domain;
using System;

namespace Persistence
{
    [Serializable]
    public class RepositoryException : VehicleTrackingException
    {
        public RepositoryException(string message) : base(message) { }
    }
}
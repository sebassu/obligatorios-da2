using Domain;
using System;

namespace API.Services
{
    [Serializable]
    public class ServiceException : VehicleTrackingException
    {
        public ServiceException(string message) : base(message) { }
    }
}
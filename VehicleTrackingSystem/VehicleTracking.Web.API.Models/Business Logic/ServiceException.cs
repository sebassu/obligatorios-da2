using System;
using VehicleTracking_Data_Entities;

namespace API.Services
{
    [Serializable]
    public class ServiceException : VehicleTrackingException
    {
        public ServiceException(string message) : base(message) { }
    }
}
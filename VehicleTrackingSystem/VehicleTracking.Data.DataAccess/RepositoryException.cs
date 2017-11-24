using System;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    [Serializable]
    public class RepositoryException : VehicleTrackingException
    {
        public RepositoryException(string message) : base(message) { }
    }
}
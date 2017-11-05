using System;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_ConcreteImportingStrategies
{
    [Serializable]
    public class ImportingException : VehicleTrackingException
    {
        public ImportingException(string message) : base(message) { }
    }
}
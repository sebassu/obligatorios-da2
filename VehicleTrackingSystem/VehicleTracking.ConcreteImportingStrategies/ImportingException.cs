using Domain;
using System;

namespace ImportingStrategies
{
    [Serializable]
    public class ImportingException : VehicleTrackingException
    {
        public ImportingException(string message) : base(message) { }
    }
}
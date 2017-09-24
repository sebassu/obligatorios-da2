using System;

namespace Domain
{
    [Serializable]
    public class InspectionException : VTSystemException
    {
        public InspectionException(string message) : base(message) { }

    }

}

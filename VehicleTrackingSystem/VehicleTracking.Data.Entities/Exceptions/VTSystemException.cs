using System;

namespace Domain
{
    [Serializable]
    public class VTSystemException : ArgumentException
    {
        public VTSystemException(string message) : base(message) { }
    }
}
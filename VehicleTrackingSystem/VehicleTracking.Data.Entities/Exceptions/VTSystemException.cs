using System;

namespace Domain
{
    [Serializable]
    public class VTSystemException : ArgumentException
    {
        public VTSystemException() : base() { }
        public VTSystemException(string message) : base(message) { }
    }
}
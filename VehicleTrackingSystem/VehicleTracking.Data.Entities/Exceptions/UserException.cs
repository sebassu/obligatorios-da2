using System;

namespace Domain
{
    [Serializable]
    public class UserException : VTSystemException
    {
        public UserException() : base() { }
        public UserException(string message) : base(message) { }
    }
}
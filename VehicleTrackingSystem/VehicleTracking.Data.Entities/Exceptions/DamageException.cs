using System;

namespace Domain
{
    [Serializable]
    public class DamageException : VTSystemException
    {
        public DamageException() : base() { }
        public DamageException(string message) : base(message) { }
    }
}
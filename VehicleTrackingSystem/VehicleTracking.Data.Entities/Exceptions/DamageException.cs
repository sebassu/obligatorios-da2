using System;

namespace Domain
{
    [Serializable]
    public class DamageException : VTSystemException
    {
        public DamageException(string message) : base(message) { }
    }
}
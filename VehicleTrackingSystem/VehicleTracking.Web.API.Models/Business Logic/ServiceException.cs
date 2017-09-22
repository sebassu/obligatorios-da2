using Domain;
using System;

namespace API.Services
{
    [Serializable]
    public class ServiceException : VTSystemException
    {
        public ServiceException(string message) : base(message) { }
    }
}
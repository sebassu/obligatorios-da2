using Domain;
using System;

namespace API.Services
{
    public static class ServiceUtilities
    {
        public static void CheckParameterIsNotNullAndExecute(object someObject,
            Action<object> action)
        {
            if (Utilities.IsNotNull(someObject))
            {
                action.Invoke(someObject);
            }
            else
            {
                throw new ServiceException(ErrorMessages.NullDTOReference);
            }
        }
    }
}
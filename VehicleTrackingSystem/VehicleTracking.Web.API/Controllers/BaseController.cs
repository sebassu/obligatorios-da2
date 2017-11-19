using System;
using System.Web.Http;
using VehicleTracking_Data_Entities;

namespace Web.API.Controllers
{
    public class BaseController : ApiController
    {
        protected IHttpActionResult ExecuteActionAndReturnOutcome(
            Func<IHttpActionResult> actionToExecute)
        {
            try
            {
                return actionToExecute.Invoke();
            }
            catch (VehicleTrackingException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (SystemException exception)
            {
                return InternalServerError(exception);
            }
        }
    }
}
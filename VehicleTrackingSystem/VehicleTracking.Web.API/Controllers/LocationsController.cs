using API.Services;
using System.Web.Http;

namespace Web.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Locations")]
    public class LocationsController : BaseController
    {
        internal ILocationServices Model { get; }

        public LocationsController()
        {
            Model = new LocationServices();
        }

        public LocationsController(ILocationServices someModel)
        {
            Model = someModel;
        }

        [HttpGet]
        [Route("Ports")]
        public IHttpActionResult GetRegisteredPorts()
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    var ports = Model.GetRegisteredPorts();
                    return Ok(ports);
                });
        }

        [HttpGet]
        [Route("Yards")]
        public IHttpActionResult GetRegisteredYards()
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    var yards = Model.GetRegisteredYards();
                    return Ok(yards);
                });
        }
    }
}
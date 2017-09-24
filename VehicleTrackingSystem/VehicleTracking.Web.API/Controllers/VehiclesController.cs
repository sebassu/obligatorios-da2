using Domain;
using API.Services;
using System.Web.Http;
using System.Collections.Generic;

namespace Web.API.Controllers
{
    public class VehiclesController : ApiController
    {
        internal IVehicleServices Model { get; }

        public VehiclesController(IVehicleServices someModel)
        {
            Model = someModel;
        }

        // GET: api/Vehicles
        public IHttpActionResult GetRegisteredVehicles()
        {
            IEnumerable<VehicleDTO> vehicles = Model.GetRegisteredVehicles();
            if (Utilities.IsNotNull(vehicles))
            {
                return Ok(vehicles);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
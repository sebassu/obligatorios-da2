using Domain;
using API.Services;
using System.Web.Http;
using System.Collections.Generic;

namespace Web.API.Controllers
{
    public class VehiclesController : ApiController
    {
        private readonly IVehicleServices model;

        public VehiclesController(IVehicleServices someModel)
        {
            model = someModel;
        }

        // GET: api/Vehicles
        public IHttpActionResult GetRegisteredVehicles()
        {
            IEnumerable<VehicleDTO> vehicles = model.GetRegisteredVehicles();
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
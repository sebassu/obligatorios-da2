using Domain;
using API.Services;
using System.Web.Http;
using System.Collections.Generic;

namespace Web.API.Controllers
{
    [RoutePrefix("api/Vehicles")]
    public class VehiclesController : BaseController
    {
        internal IVehicleServices Model { get; }

        public VehiclesController(IVehicleServices someModel)
        {
            Model = someModel;
        }

        [HttpPost]
        public IHttpActionResult AddNewVehicleFromData(
            [FromBody]VehicleDTO vehicleDataToAdd)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    int additionId = Model.AddNewVehicleFromData(vehicleDataToAdd);
                    return CreatedAtRoute("DefaultApi", new { id = additionId },
                        vehicleDataToAdd);
                });
        }

        [HttpGet]
        public IHttpActionResult GetRegisteredVehicles()
        {
            return ExecuteActionAndReturnOutcome(AttemptToGetRegisteredVehicles);
        }

        private IHttpActionResult AttemptToGetRegisteredVehicles()
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

        [HttpGet]
        [Route("{vinToLookup}")]
        public IHttpActionResult GetVehicleWithVIN(string vinToLookup)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    VehicleDTO requestedVehicle = Model.GetVehicleWithVIN(vinToLookup);
                    return Ok(requestedVehicle);
                });
        }

        [HttpPut]
        [Route("{vinToModify}")]
        public IHttpActionResult ModifyVehicleWithVIN(string vinToModify,
            [FromBody]VehicleDTO vehicleDataToSet)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.ModifyVehicleWithVIN(vinToModify, vehicleDataToSet);
                    return Ok();
                });
        }

        [HttpPut]
        [Route("{vinToRemove}")]
        public IHttpActionResult RemoveVehicleWithVIN(string vinToRemove)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.RemoveVehicleWithVIN(vinToRemove);
                    return Ok();
                });
        }
    }
}
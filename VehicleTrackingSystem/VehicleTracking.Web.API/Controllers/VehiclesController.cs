using Domain;
using API.Services;
using System.Web.Http;
using System.Collections.Generic;
using System;

namespace Web.API.Controllers
{
    public class VehiclesController : ApiController
    {
        internal IVehicleServices Model { get; }

        public VehiclesController(IVehicleServices someModel)
        {
            Model = someModel;
        }

        // POST: api/Vehicles
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

        // DELETE: api/Vehicles/QWERTYU12345678AS
        public IHttpActionResult RemoveVehicleWithVIN(string vinToRemove)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.RemoveVehicleWithVIN(vinToRemove);
                    return Ok();
                });
        }

        // PUT: api/Vehicles/QWERTYU12345678AS
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

        private IHttpActionResult ExecuteActionAndReturnOutcome(
            Func<IHttpActionResult> actionToExecute)
        {
            try
            {
                return actionToExecute.Invoke();
            }
            catch (VTSystemException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
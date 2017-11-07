using VehicleTracking_Data_Entities;
using API.Services;
using System.Web.Http;
using System.Collections.Generic;

namespace Web.API.Controllers
{
    [RoutePrefix("api/Vehicles")]
    [Authorize]
    public class VehiclesController : BaseController
    {
        internal IVehicleServices Model { get; }

        public VehiclesController()
        {
            Model = new VehicleServices();
        }

        public VehiclesController(IVehicleServices someModel)
        {
            Model = someModel;
        }

        [HttpPost]
        [AuthorizeRoles(UserRoles.ADMINISTRATOR)]
        public IHttpActionResult AddNewVehicleFromData(
            [FromBody]VehicleDTO vehicleDataToAdd)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    int databaseId = Model.AddNewVehicleFromData(vehicleDataToAdd);
                    return CreatedAtRoute("VTSystemAPI", new { id = databaseId },
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
        [AuthorizeRoles(UserRoles.ADMINISTRATOR)]
        [Route("{vinToModify}")]
        public IHttpActionResult ModifyVehicleWithVIN(string vinToModify,
            [FromBody]VehicleDTO vehicleDataToSet)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.ModifyVehicleWithVIN(vinToModify, vehicleDataToSet);
                    return Ok(ResponseMessages.SuccessfulModification);
                });
        }

        [HttpDelete]
        [AuthorizeRoles(UserRoles.ADMINISTRATOR, UserRoles.YARD_OPERATOR)]
        [Route("{vinToRemove}")]
        public IHttpActionResult RemoveVehicleWithVIN(string vinToRemove)
        {
            return BadRequest(ResponseMessages.VehicleRemovalIsUnsupported);
        }

        [HttpPost]
        [Route("{vinToModify}/Movements", Name = "AddMovementToVehicle")]
        public IHttpActionResult AddMovementToVehicleWith(string vinToModify,
            MovementDTOIn movementData)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    string activeUsername = User.Identity.Name;
                    int databaseId = Model.AddNewMovementFromData(activeUsername,
                        vinToModify, movementData);
                    return CreatedAtRoute("AddMovementToVehicle",
                        new { id = databaseId }, movementData);
                });
        }

        [HttpGet]
        [Route("{vinToLookup}/History")]
        public IHttpActionResult GetFullHistoryOfVehicleWithVIN(string vinToLookup)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    HistoryDTO requestedHistory = Model.GetHistoryForVehicleWithVIN(vinToLookup);
                    return Ok(requestedHistory);
                });
        }
    }
}
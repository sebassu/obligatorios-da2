using System;
using System.Linq;
using API.Services;
using System.Web.Http;
using System.Security.Claims;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace Web.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Vehicles")]
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
            UserRoles roleToProcess = GetRoleOfActiveUser();
            IEnumerable<VehicleDTO> vehicles = Model.GetRegisteredVehiclesFor(roleToProcess);
            return Ok(vehicles);
        }

        private UserRoles GetRoleOfActiveUser()
        {
            var userIdentity = (ClaimsIdentity)User.Identity;
            var claims = userIdentity.Claims;
            var claimOfActiveUser = claims.Where(c => c.Type == ClaimTypes.Role).Single();
            return (UserRoles)Enum.Parse(typeof(UserRoles), claimOfActiveUser.Value);
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
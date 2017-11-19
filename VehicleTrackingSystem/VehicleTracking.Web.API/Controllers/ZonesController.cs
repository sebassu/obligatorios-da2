using API.Services;
using System.Web.Http;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace Web.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Zones")]
    public class ZonesController : BaseController
    {
        internal IZoneServices Model { get; }

        public ZonesController()
        {
            Model = new ZoneServices();
        }

        public ZonesController(IZoneServices someModel)
        {
            Model = someModel;
        }

        [HttpPost]
        [AuthorizeRoles(UserRoles.ADMINISTRATOR)]
        public IHttpActionResult AddNewZoneFromData(
            [FromBody]ZoneDTO userDataToAdd)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    int additionId = Model.AddNewZoneFromData(userDataToAdd);
                    return CreatedAtRoute("VTSystemAPI",
                        new { id = additionId }, userDataToAdd);
                });
        }

        [HttpGet]
        [AuthorizeRoles(UserRoles.ADMINISTRATOR, UserRoles.YARD_OPERATOR)]
        public IHttpActionResult GetRegisteredZones()
        {
            return ExecuteActionAndReturnOutcome(AttemptToGetRegisteredZones);
        }

        private IHttpActionResult AttemptToGetRegisteredZones()
        {
            IEnumerable<ZoneDTO> zones = Model.GetRegisteredZones();
            return Ok(zones);
        }

        [HttpGet]
        [Route("{nameToLookup}")]
        [AuthorizeRoles(UserRoles.ADMINISTRATOR, UserRoles.YARD_OPERATOR)]
        public IHttpActionResult GetZoneByName(string nameToLookup)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    ZoneDTO requestedZone = Model.GetZoneWithName(nameToLookup);
                    return Ok(requestedZone);
                });
        }

        [HttpPut]
        [Route("{nameToModify}")]
        [AuthorizeRoles(UserRoles.ADMINISTRATOR)]
        public IHttpActionResult ModifyZoneWithName(string nameToModify,
            [FromBody]ZoneDTO userDataToSet)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.ModifyZoneWithName(nameToModify, userDataToSet);
                    return Ok(ResponseMessages.SuccessfulModification);
                });
        }

        [HttpDelete]
        [Route("{nameToRemove}")]
        [AuthorizeRoles(UserRoles.ADMINISTRATOR)]

        public IHttpActionResult RemoveZoneWithName(string nameToRemove)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.RemoveZoneWithName(nameToRemove);
                    return Ok(ResponseMessages.SuccessfulRemoval);
                });
        }
    }
}
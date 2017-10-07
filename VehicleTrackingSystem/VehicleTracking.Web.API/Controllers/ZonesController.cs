using API.Services;
using API.Services.Business_Logic;
using Domain;
using System.Collections.Generic;
using System.Web.Http;

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
        public IHttpActionResult GetRegisteredZones()
        {
            return ExecuteActionAndReturnOutcome(AttemptToGetRegisteredZones);
        }

        private IHttpActionResult AttemptToGetRegisteredZones()
        {
            IEnumerable<ZoneDTO> users = Model.GetRegisteredZones();
            if (Utilities.IsNotNull(users))
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{nameToLookup}")]
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
                    return Ok();
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
                    return Ok();
                });
        }
    }
}
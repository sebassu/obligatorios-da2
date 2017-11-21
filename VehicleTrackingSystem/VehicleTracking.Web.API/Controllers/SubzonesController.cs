using API.Services;
using System.Web.Http;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace Web.API.Controllers
{
    [Authorize]
    public class SubzonesController : BaseController
    {
        internal ISubzoneServices Model { get; }

        public SubzonesController()
        {
            Model = new SubzoneServices();
        }

        public SubzonesController(ISubzoneServices someModel)
        {
            Model = someModel;
        }

        [HttpPost]
        [AuthorizeRoles(UserRoles.ADMINISTRATOR)]
        [Route("api/Zones/{containerName}/Subzones", Name = "RegisterSubzoneToZone")]
        public IHttpActionResult AddNewSubzoneFromData(string containerName,
            [FromBody]SubzoneDTO subzoneDataToAdd)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    int additionId = Model.AddNewSubzoneFromData(containerName,
                        subzoneDataToAdd);
                    subzoneDataToAdd.Id = additionId;
                    subzoneDataToAdd.ContainerName = containerName;
                    return CreatedAtRoute("RegisterSubzoneToZone",
                        new { id = additionId }, subzoneDataToAdd);
                });
        }

        [HttpGet]
        [Route("api/Subzones")]
        [AuthorizeRoles(UserRoles.ADMINISTRATOR, UserRoles.YARD_OPERATOR)]
        public IHttpActionResult GetRegisteredSubzones()
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    IEnumerable<SubzoneDTO> subzones = Model.GetRegisteredSubzones();
                    return Ok(subzones);
                });
        }

        [HttpGet]
        [Route("api/Subzones/{idToLookup}")]
        [AuthorizeRoles(UserRoles.ADMINISTRATOR, UserRoles.YARD_OPERATOR)]
        public IHttpActionResult GetSubzoneWithId(int idToLookup)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    SubzoneDTO requestedSubzone = Model.GetSubzoneWithId(idToLookup);
                    return Ok(requestedSubzone);
                });
        }

        [HttpPut]
        [AuthorizeRoles(UserRoles.ADMINISTRATOR)]
        [Route("api/Subzones/{idToModify}")]
        public IHttpActionResult ModifySubzoneWithId(int idToModify,
            [FromBody]SubzoneDTO userDataToSet)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.ModifySubzoneWithId(idToModify, userDataToSet);
                    return Ok(ResponseMessages.SuccessfulModification);
                });
        }

        [HttpDelete]
        [AuthorizeRoles(UserRoles.ADMINISTRATOR)]
        [Route("api/Subzones/{idToRemove}")]
        public IHttpActionResult RemoveSubzoneWithId(int idToRemove)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.RemoveSubzoneWithId(idToRemove);
                    return Ok(ResponseMessages.SuccessfulRemoval);
                });
        }
    }
}
using API.Services;
using API.Services.Business_Logic;
using Domain;
using System.Collections.Generic;
using System.Web.Http;

namespace Web.API.Controllers
{
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
        [Route("api/Zones/{nameOfContainer}")]
        public IHttpActionResult AddNewSubzoneFromData(string containerName,
            [FromBody]SubzoneDTO subzoneDataToAdd)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    int additionId = Model.AddNewSubzoneFromData(containerName,
                        subzoneDataToAdd);
                    return CreatedAtRoute("VTSystemAPI",
                        new { id = additionId }, subzoneDataToAdd);
                });
        }

        [HttpGet]
        [Route("api/Subzones")]
        public IHttpActionResult GetRegisteredSubzones()
        {
            return ExecuteActionAndReturnOutcome(AttemptToGetRegisteredSubzones);
        }

        private IHttpActionResult AttemptToGetRegisteredSubzones()
        {
            IEnumerable<SubzoneDTO> users = Model.GetRegisteredSubzones();
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
        [Route("api/Subzones/{idToLookup}")]
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
        [Route("api/Subzones/{idToModify}")]
        public IHttpActionResult ModifySubzoneWithId(int idToModify,
            [FromBody]SubzoneDTO userDataToSet)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.ModifySubzoneWithId(idToModify, userDataToSet);
                    return Ok();
                });
        }

        [HttpDelete]
        [Route("api/Subzones/{idToRemove}")]
        public IHttpActionResult RemoveSubzoneWithId(int idToRemove)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.RemoveSubzoneWithId(idToRemove);
                    return Ok();
                });
        }
    }
}
using API.Services;
using System.Web.Http;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace Web.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Lots")]
    [AuthorizeRoles(UserRoles.ADMINISTRATOR, UserRoles.PORT_OPERATOR)]
    public class LotsController : BaseController
    {
        internal ILotServices Model { get; }

        public LotsController()
        {
            Model = new LotServices();
        }

        public LotsController(ILotServices someModel)
        {
            Model = someModel;
        }

        [HttpPost]
        public IHttpActionResult AddNewLotFromData(
           [FromBody]LotDTO lotDataToAdd)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    string activeUsername = User.Identity.Name;
                    var additionId = Model.AddNewLotFromData(activeUsername,
                        lotDataToAdd);
                    lotDataToAdd.CreatorUsername = activeUsername;
                    return CreatedAtRoute("VTSystemAPI",
                        new { id = additionId }, lotDataToAdd);
                });
        }

        [HttpGet]
        public IHttpActionResult GetRegisteredLots()
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    IEnumerable<LotDTO> lots = Model.GetRegisteredLots();
                    return Ok(lots);
                });
        }

        [HttpGet]
        [Route("{nameToFind}")]
        public IHttpActionResult GetLotByName(string nameToFind)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    LotDTO requestedLot = Model.GetLotByName(nameToFind);
                    return Ok(requestedLot);
                });
        }

        [HttpPut]
        [Route("{nameToModify}")]
        public IHttpActionResult ModifyLotWithName(string nameToModify,
            [FromBody]LotDTO lotDataToSet)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.ModifyLotWithName(nameToModify, lotDataToSet);
                    return Ok(ResponseMessages.SuccessfulModification);
                });
        }

        [HttpDelete]
        [Route("{nameToRemove}")]
        public IHttpActionResult RemoveLotWithName(string nameToRemove)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.RemoveLotWithName(nameToRemove);
                    return Ok(ResponseMessages.SuccessfulRemoval);
                });
        }
    }
}
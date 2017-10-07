using Domain;
using API.Services;
using System.Web.Http;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Web.API.Controllers
{
    [RoutePrefix("api/Lots")]
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
                    int additionId = Model.AddNewLotFromData(lotDataToAdd);
                    return CreatedAtRoute("VTSystemAPI",
                        new { id = additionId }, lotDataToAdd);
                });
        }

        [HttpGet]
        public IHttpActionResult GetRegisteredLots()
        {
            return ExecuteActionAndReturnOutcome(AttemptToGetRegisteredLots);
        }

        private IHttpActionResult AttemptToGetRegisteredLots()
        {
            IEnumerable<LotDTO> lots = Model.GetRegisteredLots();
            if (Utilities.IsNotNull(lots))
            {
                return Ok(lots);
            }
            else
            {
                return NotFound();
            }
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
                    return Ok();
                });
        }

        [HttpDelete]
        [Route("{nameToModify}")]
        public IHttpActionResult RemoveLotWithName(string nameToRemove)
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

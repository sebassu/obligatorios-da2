using Domain;
using System;
using System.Web.Http;
using API.Services;
using System.Collections.Generic;

namespace Web.API.Controllers
{
    [RoutePrefix("api/Transports")]
    [AuthorizeRoles(UserRoles.ADMINISTRATOR, UserRoles.TRANSPORTER)]
    public class TransportsController : BaseController
    {
        internal ITransportServices Model { get; }

        public TransportsController()
        {
            Model = new TransportServices();
        }

        public TransportsController(ITransportServices someModel)
        {
            Model = someModel;
        }

        [HttpPost]
        public IHttpActionResult StartNewTransportFromData(
            [FromBody]TransportDTO transportDataToAdd)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    var activeUsername = User.Identity.Name;
                    int additionId = Model.StartNewTransportFromData(activeUsername,
                        transportDataToAdd);
                    transportDataToAdd.Id = additionId;
                    transportDataToAdd.TransporterUsername = activeUsername;
                    return CreatedAtRoute("VTSystemAPI",
                        new { id = additionId }, transportDataToAdd);
                });
        }

        [HttpGet]
        public IHttpActionResult GetRegisteredTransports()
        {
            return ExecuteActionAndReturnOutcome(AttemptToGetRegisteredTransports);
        }

        private IHttpActionResult AttemptToGetRegisteredTransports()
        {
            IEnumerable<TransportDTO> transports =
                Model.GetRegisteredTransports();
            if (Utilities.IsNotNull(transports))
            {
                return Ok(transports);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{transportIdToFinalize}")]
        public IHttpActionResult ModifyUserWithUsername(int transportIdToFinalize,
            [FromBody]DateTime finalizationDateTime)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    var activeUsername = User.Identity.Name;
                    Model.FinalizeTransport(activeUsername, transportIdToFinalize,
                        finalizationDateTime);
                    return Ok("Transporte finalizado.");
                });
        }
    }
}
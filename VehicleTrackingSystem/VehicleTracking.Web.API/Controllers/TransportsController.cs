using System;
using API.Services;
using System.Web.Http;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

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
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    IEnumerable<TransportDTO> transports = Model.GetRegisteredTransports();
                    return Ok(transports);
                });
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
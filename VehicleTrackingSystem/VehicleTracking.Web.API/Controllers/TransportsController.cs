using Domain;
using System;
using System.Web.Http;
using API.Services;

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

        [HttpPut]
        [Route("{transportIdToFinalize}")]
        public IHttpActionResult ModifyUserWithUsername(int transportIdToFinalize,
            [FromUri]DateTime finalizationDateTime)
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
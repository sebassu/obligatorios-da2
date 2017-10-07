using System.Web.Http;
using API.Services.Business_Logic;
using API.Services;
using Domain;
using System.Collections.Generic;

namespace Web.API.Controllers
{
    public class InspectionsController : BaseController
    {
        internal IInspectionServices Model { get; }

        public InspectionsController()
        {
            Model = new InspectionServices();
        }

        public InspectionsController(IInspectionServices someModel)
        {
            Model = someModel;
        }

        [HttpPost]
        [Route("api/Vehicles/{vehicleVIN}/PortInspection")]
        public IHttpActionResult AddNewPortInspectionFromData(string vehicleVIN,
            [FromBody]InspectionDTO inspectionDataToAdd)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    int additionId = Model.AddNewPortInspectionFromData(vehicleVIN,
                        inspectionDataToAdd);
                    return CreatedAtRoute("VTSystemAPI",
                        new { id = additionId }, inspectionDataToAdd);
                });
        }

        [HttpPost]
        [Route("api/Vehicles/{vehicleVIN}/YardInspection")]
        public IHttpActionResult AddNewYardInspectionFromData(string vehicleVIN,
            [FromBody]InspectionDTO inspectionDataToAdd)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    int additionId = Model.AddNewYardInspectionFromData(vehicleVIN,
                        inspectionDataToAdd);
                    return CreatedAtRoute("VTSystemAPI",
                        new { id = additionId }, inspectionDataToAdd);
                });
        }

        [HttpGet]
        [Route("api/Inspections")]
        public IHttpActionResult GetRegisteredInspections()
        {
            return ExecuteActionAndReturnOutcome(AttemptToGetRegisteredInspections);
        }

        private IHttpActionResult AttemptToGetRegisteredInspections()
        {
            IEnumerable<InspectionDTO> users = Model.GetRegisteredInspections();
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
        [Route("api/Inspections/{idToLookup}")]
        public IHttpActionResult GetUserByUsername(int idToLookup)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    InspectionDTO requestedInspection = Model.GetInspectionWithId(idToLookup);
                    return Ok(requestedInspection);
                });
        }
    }
}
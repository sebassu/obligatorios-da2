using System;
using API.Services;
using System.Web.Http;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace Web.API.Controllers
{
    [Authorize]
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
        [AuthorizeRoles(UserRoles.ADMINISTRATOR, UserRoles.PORT_OPERATOR)]
        [Route("api/Vehicles/{vehicleVIN}/PortInspection", Name = "RegisterPortInspectionToVehicle")]
        public IHttpActionResult AddNewPortInspectionFromData(string vehicleVIN,
            [FromBody]InspectionDTO inspectionDataToAdd)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    string currentUsername = User.Identity.Name;
                    var additionId = Model.AddNewPortInspectionFromData(vehicleVIN,
                        currentUsername, inspectionDataToAdd);
                    inspectionDataToAdd.VehicleVIN = vehicleVIN;
                    inspectionDataToAdd.ResponsibleUsername = currentUsername;
                    return CreatedAtRoute("RegisterPortInspectionToVehicle",
                        new { id = additionId }, inspectionDataToAdd);
                });
        }

        [HttpPost]
        [AuthorizeRoles(UserRoles.ADMINISTRATOR, UserRoles.YARD_OPERATOR)]
        [Route("api/Vehicles/{vehicleVIN}/YardInspection", Name = "RegisterYardInspectionToVehicle")]
        public IHttpActionResult AddNewYardInspectionFromData(string vehicleVIN,
            [FromBody]InspectionDTO inspectionDataToAdd)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    string currentUsername = User.Identity.Name;
                    var additionId = Model.AddNewYardInspectionFromData(vehicleVIN,
                        currentUsername, inspectionDataToAdd);
                    inspectionDataToAdd.VehicleVIN = vehicleVIN;
                    inspectionDataToAdd.ResponsibleUsername = currentUsername;
                    return CreatedAtRoute("RegisterYardInspectionToVehicle",
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
        public IHttpActionResult GetInspectionWithId(Guid idToLookup)
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
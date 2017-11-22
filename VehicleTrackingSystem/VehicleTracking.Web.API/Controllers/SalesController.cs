using API.Services;
using System.Web.Http;
using VehicleTracking_Data_Entities;

namespace Web.API.Controllers
{
    [AuthorizeRoles(UserRoles.ADMINISTRATOR, UserRoles.SALESMAN)]
    public class SalesController : BaseController
    {
        internal ISaleServices Model { get; }

        public SalesController()
        {
            Model = new SaleServices();
        }

        public SalesController(ISaleServices someModel)
        {
            Model = someModel;
        }

        [HttpGet]
        [Route("api/Sales")]
        public IHttpActionResult GetRegisteredSales()
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    var ports = Model.GetRegisteredSales();
                    return Ok(ports);
                });
        }

        [HttpPost]
        [Route("api/Vehicles/{vinToModify}/Sale", Name = "SaleOfVehicle")]
        public IHttpActionResult RegisterSaleOfVehicleWith(string vinToModify,
            [FromBody]SaleDTO saleData)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    int databaseId = Model.AddNewSaleFromData(vinToModify,
                        saleData);
                    saleData.VehicleVIN = vinToModify;
                    return CreatedAtRoute("SaleOfVehicle",
                        new { id = databaseId }, saleData);
                });
        }
    }
}
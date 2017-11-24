using API.Services;
using System.Web.Http;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Tests")]
namespace Web.API.Controllers
{
    [RoutePrefix("api/Users")]
    [AuthorizeRoles(UserRoles.ADMINISTRATOR)]
    public class UsersController : BaseController
    {
        internal IUserServices Model { get; }

        public UsersController()
        {
            Model = new UserServices();
        }

        public UsersController(IUserServices someModel)
        {
            Model = someModel;
        }

        [HttpPost]
        public IHttpActionResult AddNewUserFromData(
            [FromBody]UserDTO userDataToAdd)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    int additionId = Model.AddNewUserFromData(userDataToAdd);
                    return CreatedAtRoute("VTSystemAPI",
                        new { id = additionId }, userDataToAdd);
                });
        }

        [HttpGet]
        public IHttpActionResult GetRegisteredUsers()
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    IEnumerable<UserDTO> users = Model.GetRegisteredUsers();
                    return Ok(users);
                });
        }

        [HttpGet]
        [Route("{usernameToLookup}")]
        public IHttpActionResult GetUserByUsername(string usernameToLookup)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    UserDTO requestedUser = Model.GetUserWithUsername(usernameToLookup);
                    return Ok(requestedUser);
                });
        }

        [HttpPut]
        [Route("{usernameToModify}")]
        public IHttpActionResult ModifyUserWithUsername(string usernameToModify,
            [FromBody]UserDTO userDataToSet)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.ModifyUserWithUsername(usernameToModify, userDataToSet);
                    return Ok(ResponseMessages.SuccessfulModification);
                });
        }

        [HttpDelete]
        [Route("{usernameToRemove}")]
        public IHttpActionResult RemoveUserWithUsername(string usernameToRemove)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.RemoveUserWithUsername(usernameToRemove);
                    return Ok(ResponseMessages.SuccessfulRemoval);
                });
        }
    }
}
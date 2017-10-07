using Domain;
using API.Services;
using System.Web.Http;
using System.Collections.Generic;
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
            return ExecuteActionAndReturnOutcome(AttemptToGetRegisteredUsers);
        }

        private IHttpActionResult AttemptToGetRegisteredUsers()
        {
            IEnumerable<UserDTO> users = Model.GetRegisteredUsers();
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
                    return Ok();
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
                    return Ok();
                });
        }
    }
}
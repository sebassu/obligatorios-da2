using Domain;
using API.Services;
using System.Web.Http;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Tests")]
namespace Web.API.Controllers
{
    public class UsersController : ApiController
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

        // POST: api/Users
        public IHttpActionResult AddNewUserFromData(
            [FromBody]UserDTO userDataToAdd)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.AddNewUserFromData(userDataToAdd);
                    return CreatedAtRoute("DefaultApi",
                        new { id = userDataToAdd.Username }, userDataToAdd);
                });
        }

        // GET: api/Users
        public IHttpActionResult GetRegisteredUsers()
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

        // GET: api/Users/mSantos
        public IHttpActionResult GetUserByUsername(string usernameToLookup)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    UserDTO requestedUser = Model.GetUserByUsername(usernameToLookup);
                    return Ok(requestedUser);
                });
        }

        // PUT: api/Users/mSantos
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

        // DELETE: api/Users/mSantos
        public IHttpActionResult RemoveUserWithUsername(string usernameToRemove)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    Model.RemoveUserWithUsername(usernameToRemove);
                    return Ok();
                });
        }

        private IHttpActionResult ExecuteActionAndReturnOutcome(
            Func<IHttpActionResult> actionToExecute)
        {
            try
            {
                return actionToExecute.Invoke();
            }
            catch (VTSystemException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
using Domain;
using API.Services;
using System.Web.Http;
using System.Collections.Generic;
using System;

namespace Web.API.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserServices model;

        public UsersController(IUserServices someModel)
        {
            model = someModel;
        }

        // POST: api/Users
        public IHttpActionResult AddNewUserFromDTO(
            [FromBody]UserDTO userToAdd)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    model.AddNewUserFromData(userToAdd);
                    return CreatedAtRoute("DefaultApi",
                        new { id = userToAdd.Username }, userToAdd);
                });
        }

        // GET: api/Users
        public IHttpActionResult GetRegisteredUsers()
        {
            IEnumerable<UserDTO> users = model.GetRegisteredUsers();
            if (Utilities.IsNotNull(users))
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Users/5
        public IHttpActionResult GetUserById(string usernameToLookup)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    UserDTO requestedUser = model.GetUserByUsername(usernameToLookup);
                    return Ok(requestedUser);
                });
        }

        // PUT: api/Users/mSantos
        public IHttpActionResult UpdateUserWithId(string usernameToModify,
            [FromBody]UserDTO userDataToSet)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    model.ModifyUserWithUsername(usernameToModify, userDataToSet);
                    return Ok();
                });
        }

        // DELETE: api/Users/5
        public IHttpActionResult RemoveUserWithId(string usernameToRemove)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    model.RemoveUserWithUsername(usernameToRemove);
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
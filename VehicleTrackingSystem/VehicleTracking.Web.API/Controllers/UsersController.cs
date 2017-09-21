using Domain;
using API.Services;
using System.Web.Http;
using System.Collections.Generic;
using System;

namespace Web.API.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUsersServices model;

        public UsersController(IUsersServices someModel)
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
                    int addedUsersId = model.Add(userToAdd);
                    return CreatedAtRoute("DefaultApi",
                        new { id = addedUsersId }, userToAdd);
                });
        }

        // GET: api/Users
        public IHttpActionResult GetRegisteredUsers()
        {
            IReadOnlyCollection<UserDTO> users = model.GetRegisteredUsers();
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
        public IHttpActionResult GetUserById(int id)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    UserDTO requestedUser = model.GetUserByUd(id);
                    return Ok(requestedUser);
                });
        }

        // PUT: api/Users/5
        public IHttpActionResult UpdateUserWithId(int id,
            [FromBody]UserDTO userDataToSet)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    model.UpdateUserWithId(id, userDataToSet);
                    return Ok();
                });
        }

        // DELETE: api/Users/5
        public IHttpActionResult RemoveUserWithId(int id)
        {
            return ExecuteActionAndReturnOutcome(
                delegate
                {
                    model.Remove(id);
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
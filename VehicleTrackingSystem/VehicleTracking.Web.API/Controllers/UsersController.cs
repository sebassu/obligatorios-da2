using Domain;
using API.Services;
using System.Web.Http;
using System.Collections.Generic;

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
            try
            {
                int addedUsersId = model.Add(userToAdd);
                return CreatedAtRoute("DefaultApi",
                    new { id = addedUsersId }, userToAdd);
            }
            catch (VTSystemException exception)
            {
                return BadRequest(exception.Message);
            }
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
            try
            {
                UserDTO requestedUser = model.GetUserByUd(id);
                return Ok(requestedUser);
            }
            catch (VTSystemException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT: api/Users/5
        public IHttpActionResult UpdateUserWithId(int id,
            [FromBody]UserDTO userDataToSet)
        {
            try
            {
                model.UpdateUserWithId(id, userDataToSet);
                return Ok();
            }
            catch (VTSystemException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // DELETE: api/Users/5
        public IHttpActionResult RemoveUserWithId(int id)
        {
            try
            {
                model.Remove(id);
                return Ok();
            }
            catch (VTSystemException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
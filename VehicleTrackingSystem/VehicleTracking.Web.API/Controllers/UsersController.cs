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

        // GET: api/Users
        public IHttpActionResult GetRegisteredUsers()
        {
            IReadOnlyCollection<UserDTO> users = model.GetAllUsers();
            if (Utilities.IsNotNull(users))
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Users
        public IHttpActionResult AddNewUserFromDTO([FromBody]UserDTO userToAdd)
        {
            try
            {
                int addedUsersId = model.Add(userToAdd);
                return CreatedAtRoute("DefaultApi", new { id = addedUsersId }, userToAdd);
            }
            catch (VTSystemException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
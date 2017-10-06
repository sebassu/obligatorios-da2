using Domain;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;

[assembly: InternalsVisibleTo("VehicleTracking.Data.Tests")]
namespace Persistence
{
    internal class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(VTSystemContext someContext) : base(someContext) { }

        public IEnumerable<User> Elements => GetElementsThat();

        public void AddNewUser(User userToAdd)
        {
            Add(userToAdd);
        }

        public bool ExistsUserWithUsername(string usernameToLookup)
        {
            return elements.Any(u => u.Username.Equals(usernameToLookup));
        }

        public User GetUserWithUsername(string usernameToFind)
        {
            try
            {
                return elements.Single(u => u.Username.Equals(usernameToFind));
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindField, "nombre de usuario", usernameToFind);
                throw new RepositoryException(errorMessage);
            }
        }

        public void UpdateUser(User userToModify)
        {
            Update(userToModify);
        }

        public void RemoveUserWithUsername(string usernameToRemove)
        {
            var userToRemove = GetUserWithUsername(usernameToRemove);
            AttemptToRemove(userToRemove);
        }

        public bool UsernameBelongsToLastAdministrator(string usernameToRemove)
        {
            var administrators = elements.
                Where(u => u.Role == UserRoles.ADMINISTRATOR).ToList();
            return administrators.Count == 1 &&
                administrators.Single().Username == usernameToRemove;
        }

        protected override bool ElementExistsInCollection(User value)
        {
            return Utilities.IsNotNull(value) && elements.Any(u => u.Id == value.Id);
        }
    }
}
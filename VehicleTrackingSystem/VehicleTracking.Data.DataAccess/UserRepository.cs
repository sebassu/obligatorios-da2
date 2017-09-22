using Domain;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Data.Tests")]
namespace Persistence
{
    internal class UserRepository : IUserRepository
    {
        public IEnumerable<User> Elements
        {
            get
            {
                using (var context = new VTSystemContext())
                {
                    var elements = context.Users;
                    return elements.ToList();
                }
            }
        }

        public void AddNewUser(User userToAdd)
        {
            using (var context = new VTSystemContext())
            {
                EntityFrameworkUtilities<User>.Add(context, userToAdd);
            }
        }

        public bool ExistsUserWithUsername(string usernameToLookup)
        {
            using (var context = new VTSystemContext())
            {
                return context.Users.Any(u => u.Username == usernameToLookup);
            }
        }

        public void Remove(string usernameToRemove)
        {
            if (IdBelongsToLastAdministrator(usernameToRemove))
            {
                throw new RepositoryException(ErrorMessages.CannotRemoveAllAdministrators);
            }
            else
            {
                EntityFrameworkUtilities<User>.Remove(usernameToRemove);
            }
        }

        private bool IdBelongsToLastAdministrator(string usernameToRemove)
        {
            using (var context = new VTSystemContext())
            {
                var administrators = context.Users.Where(u => u.Role == UserRoles.ADMINISTRATOR).ToList();
                return administrators.Count == 1 && administrators.Single().Username == usernameToRemove;
            }
        }

        public User GetUserByUsername(string usernameToRemove)
        {
            User foundEntity;
            using (var context = new VTSystemContext())
            {
                var elements = context.Set<User>();
                foundEntity = elements.Find(usernameToRemove);
            }
            if (Utilities.IsNotNull(foundEntity))
            {
                return foundEntity;
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindUser, usernameToRemove);
                throw new RepositoryException(errorMessage);
            }
        }

        public void UpdateUser(User userToModify)
        {
            EntityFrameworkUtilities<User>.Update(userToModify);
        }
    }
}
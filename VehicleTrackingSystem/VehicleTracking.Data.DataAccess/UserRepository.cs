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
                ValidateParameterIsNotNull(userToAdd);
                if (ExistsUserWithUsername(userToAdd.Username, context))
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture,
                        ErrorMessages.FieldMustBeUnique, "nombre de usuario");
                    throw new RepositoryException(errorMessage);
                }
                else
                {
                    EntityFrameworkUtilities<User>.Add(context, userToAdd);
                }
            }
        }

        private void ValidateParameterIsNotNull(User userToAdd)
        {
            if (userToAdd == null)
            {
                throw new ArgumentNullException(ErrorMessages.NullObjectRecieved);
            }
        }

        public bool ExistsUserWithUsername(string usernameToLookup)
        {
            using (var context = new VTSystemContext())
            {
                return ExistsUserWithUsername(usernameToLookup, context);
            }
        }

        private static bool ExistsUserWithUsername(string usernameToLookup,
            VTSystemContext context)
        {
            return context.Users.Any(u => u.Username == usernameToLookup);
        }

        public User GetUserWithUsername(string usernameToFind)
        {
            using (var context = new VTSystemContext())
            {
                return AttemptToGetUserWithUsername(usernameToFind, context);
            }
        }

        private static User AttemptToGetUserWithUsername(string usernameToFind,
            VTSystemContext context)
        {
            try
            {
                var elements = context.Set<User>();
                return elements.Single(u => u.Username.Equals(usernameToFind));
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindUser, usernameToFind);
                throw new RepositoryException(errorMessage);
            }
        }

        public void UpdateUser(User userToModify)
        {
            EntityFrameworkUtilities<User>.Update(userToModify);
        }

        public void RemoveUserWithUsername(string usernameToRemove)
        {
            using (var context = new VTSystemContext())
            {
                if (UsernameBelongsToLastAdministrator(usernameToRemove, context))
                {
                    throw new RepositoryException(ErrorMessages.CannotRemoveAllAdministrators);
                }
                else
                {
                    var userToRemove = AttemptToGetUserWithUsername(usernameToRemove, context);
                    EntityFrameworkUtilities<User>.AttemptToRemove(userToRemove, context);
                }
            }
        }

        private bool UsernameBelongsToLastAdministrator(string usernameToRemove,
            VTSystemContext context)
        {
            var administrators = context.Users.Where(u => u.Role == UserRoles.ADMINISTRATOR).ToList();
            return administrators.Count == 1 && administrators.Single().Username == usernameToRemove;
        }
    }
}
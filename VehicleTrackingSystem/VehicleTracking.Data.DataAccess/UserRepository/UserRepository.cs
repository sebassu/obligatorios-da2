using System;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using VehicleTracking_Data_Entities;

[assembly: InternalsVisibleTo("VehicleTracking.Data.Tests")]
namespace VehicleTracking_Data_DataAccess
{
    internal class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(VTSystemContext someContext) : base(someContext) { }

        public IEnumerable<User> Elements => GetElementsWith("", u => !u.WasRemoved);

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
            userToRemove.WasRemoved = true;
            UpdateUser(userToRemove);
        }

        public bool UsernameBelongsToLastAdministrator(string usernameToRemove)
        {
            var administrators = elements.
                Where(u => u.Role == UserRoles.ADMINISTRATOR && !u.WasRemoved).ToList();
            return administrators.Count == 1 &&
                administrators.Single().Username == usernameToRemove;
        }

        internal override bool ElementExistsInCollection(User value)
        {
            return Utilities.IsNotNull(value) && elements.Any(u
                => u.Id == value.Id);
        }
    }
}
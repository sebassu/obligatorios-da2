using Domain;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace Persistence
{
    public class UserRepository
    {
        public static IReadOnlyCollection<User> Elements
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

        public static User AddNewUser(UserRoles role, string firstName, string lastName,
            string username, string password, string phoneNumber)
        {
            using (var context = new VTSystemContext())
            {
                bool usernameIsNotRegistered = !ExistsUserWithUsername(username);
                if (usernameIsNotRegistered)
                {
                    User userToAdd = User.CreateNewUser(role, firstName, lastName,
                        username, password, phoneNumber);
                    try
                    {
                        context.Users.Add(userToAdd);
                        context.SaveChanges();
                    }
                    catch (DataException exception)
                    {
                        throw new RepositoryException("Error en base de datos. Detalles: "
                            + exception.ToString());
                    }
                    return userToAdd;
                }
                else
                {
                    throw new RepositoryException(ErrorMessages.UsernameMustBeUnique);
                }
            }
        }

        private static bool ExistsUserWithUsername(string usernameToLookup)
        {
            using (var context = new VTSystemContext())
            {
                return context.Users.Any(u => u.Username == usernameToLookup);
            }
        }
    }
}

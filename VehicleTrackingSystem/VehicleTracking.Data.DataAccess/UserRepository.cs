using Domain;
using System.Data;
using System.Linq;
using System.Globalization;
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
                    EntityFrameworkUtilities<User>.Add(context, userToAdd);
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

        public static void Remove(User elementToRemove)
        {
            if (IsTheOnlyAdministratorLeft(elementToRemove))
            {
                throw new RepositoryException(ErrorMessages.CannotRemoveAllAdministrators);
            }
            else
            {
                EntityFrameworkUtilities<User>.Remove(elementToRemove);
            }
        }

        private static bool IsTheOnlyAdministratorLeft(User elementToRemove)
        {
            using (var context = new VTSystemContext())
            {
                var administrators = context.Users.Where(u => u.Role == UserRoles.ADMINISTRATOR).ToList();
                return administrators.Count == 1 && administrators.Single().Equals(elementToRemove);
            }
        }

        public static void ModifyUser(User userToModify, UserRoles roleToSet, string firstNameToSet,
            string lastNameToSet, string usernameToSet, string passwordToSet, string phoneNumberToSet)
        {
            try
            {
                AttemptToSetUserAttributes(userToModify, roleToSet, firstNameToSet, lastNameToSet,
                    usernameToSet, passwordToSet, phoneNumberToSet);
            }
            catch (DataException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.ElementDoesNotExist, "Usuario");
                throw new RepositoryException(errorMessage);
            }
        }

        private static void AttemptToSetUserAttributes(User userToModify, UserRoles roleToSet, string firstNameToSet,
            string lastNameToSet, string usernameToSet, string passwordToSet, string phoneNumberToSet)
        {
            using (var context = new VTSystemContext())
            {
                EntityFrameworkUtilities<User>.AttachIfIsValid(context, userToModify);
                if (ChangeCausesRepeatedUsernames(userToModify, usernameToSet))
                {
                    throw new RepositoryException(ErrorMessages.UsernameMustBeUnique);
                }
                else
                {
                    SetUserAttributes(userToModify, roleToSet, firstNameToSet, lastNameToSet,
                        usernameToSet, passwordToSet, phoneNumberToSet);
                    context.SaveChanges();
                }
            }
        }

        private static bool ChangeCausesRepeatedUsernames(User userToModify, string usernameToSet)
        {
            bool usernameChanges = userToModify.Username != usernameToSet;
            return usernameChanges && ExistsUserWithUsername(usernameToSet);
        }

        private static void SetUserAttributes(User userToModify, UserRoles roleToSet, string firstNameToSet, string lastNameToSet,
            string usernameToSet, string passwordToSet, string phoneNumberToSet)
        {
            userToModify.Role = roleToSet;
            userToModify.FirstName = firstNameToSet;
            userToModify.LastName = lastNameToSet;
            userToModify.Username = usernameToSet;
            userToModify.Password = passwordToSet;
            userToModify.PhoneNumber = phoneNumberToSet;
        }
    }
}
using API.Services;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using Microsoft.Owin.Security.OAuth;
using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;

#pragma warning disable CS1998
namespace Web.API
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(
            OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(
            OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                MatchUserNameAndPasswordToExistingUser(context);
            }
            catch (VehicleTrackingException exception)
            {
                context.SetError("invalid_grant", exception.Message);
            }
        }

        private void MatchUserNameAndPasswordToExistingUser(OAuthGrantResourceOwnerCredentialsContext
            context)
        {
            User userToBeLoggedIn = AttemptToGetMatchingUserFromDatabase(context.UserName,
                context.Password);
            try
            {
                string usersRole = userToBeLoggedIn.Role.ToString("d");
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, usersRole));
                AddUserRoleToResponse(context, userToBeLoggedIn, identity);
            }
            catch (VehicleTrackingException exception)
            {
                context.SetError("invalid_grant", exception.Message);
            }
        }

        private static void AddUserRoleToResponse(OAuthGrantResourceOwnerCredentialsContext context,
            User userToBeLoggedIn, ClaimsIdentity identity)
        {
            var additionalProperties = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "role", userToBeLoggedIn.Role.ToString()  }
                });
            var response = new AuthenticationTicket(identity, additionalProperties);
            context.Validated(response);
        }

        private User AttemptToGetMatchingUserFromDatabase(string usernameToLookup,
            string passwordToLookup)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
                IUserRepository users = unitOfWork.Users;
                User foundUser = users.GetUserWithUsername(usernameToLookup);
                return LogIfPasswordMatches(passwordToLookup, unitOfWork, foundUser);
            }
        }

        private static User LogIfPasswordMatches(string passwordToLookup,
            IUnitOfWork unitOfWork, User foundUser)
        {
            if (passwordToLookup.Equals(foundUser.Password))
            {
                unitOfWork.LoggingStrategy.RegisterUserLogin(foundUser);
                unitOfWork.SaveChanges();
                return foundUser;
            }
            else
            {
                throw new ServiceException(ResponseMessages.WrongPassword);
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
            {
                CheckIfIsRolePropertyAndAddToResponse(context, property);
            }
            return Task.FromResult<object>(null);
        }

        private static void CheckIfIsRolePropertyAndAddToResponse(OAuthTokenEndpointContext context,
            KeyValuePair<string, string> property)
        {
            if (!property.Key.StartsWith("."))
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
        }
    }
}
#pragma warning restore CS1998
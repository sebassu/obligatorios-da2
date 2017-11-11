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
            User userToBeLoggedIn = AttemptToGetUserWithUsernameFromDatabase(context.UserName);
            if (context.Password.Equals(userToBeLoggedIn.Password))
            {
                string usersRole = userToBeLoggedIn.Role.ToString("d");
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, usersRole));
                var additionalProperties = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "role", userToBeLoggedIn.Role.ToString()  }
                });
                var response = new AuthenticationTicket(identity, additionalProperties);
                context.Validated(response);
            }
            else
            {
                context.SetError("invalid_grant", "La contraseña ingresada es incorrecta.");
            }
        }

        private User AttemptToGetUserWithUsernameFromDatabase(string usernameToLookup)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork())
            {
                IUserRepository users = unitOfWork.Users;
                return users.GetUserWithUsername(usernameToLookup);
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
            {
                if (!property.Key.StartsWith("."))
                    context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
    }
}
#pragma warning restore CS1998
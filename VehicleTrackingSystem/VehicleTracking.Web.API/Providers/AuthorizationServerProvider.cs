using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

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
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin",
                new[] { "*" });
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
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, userToBeLoggedIn.Role.ToString("d")));
                context.Validated(identity);
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
    }
}
#pragma warning restore CS1998
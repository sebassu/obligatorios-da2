using Owin;
using System;
using Microsoft.Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;
using System.Web.Http.Cors;
using VehicleTrackingSystem;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(Web.API.Startup))]
namespace Web.API
{
    public class Startup
    {
        private const string defaultAPIURL = "localhost:63177";

        public void Configuration(IAppBuilder application)
        {
            application.UseCors(CorsOptions.AllowAll);
            ConfigureOAuthentication(application);
        }

        public void ConfigureOAuthentication(IAppBuilder application)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
            };
            var authOptions = new OAuthBearerAuthenticationOptions()
            {
                AuthenticationMode = AuthenticationMode.Active
            };
            application.UseOAuthAuthorizationServer(OAuthServerOptions);
            application.UseOAuthBearerAuthentication(authOptions);
        }
    }
}
using Owin;
using System;
using Microsoft.Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;
using VehicleTrackingSystem;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(Web.API.Startup))]
namespace Web.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder application)
        {
            application.UseCors(CorsOptions.AllowAll);
            ConfigureOAuthentication(application);
            HttpConfiguration configuration = new HttpConfiguration();
            WebApiConfig.Register(configuration);
            application.UseWebApi(configuration);
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
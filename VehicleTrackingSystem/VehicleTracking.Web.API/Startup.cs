using Owin;
using System;
using Microsoft.Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;
using VehicleTrackingSystem;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(AngularJSAuthentication.API.Startup))]
namespace AngularJSAuthentication.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder application)
        {
            ConfigureOAuthentication(application);
            HttpConfiguration configuration = new HttpConfiguration();
            WebApiConfig.Register(configuration);
            application.UseCors(CorsOptions.AllowAll);
            application.UseWebApi(configuration);
        }

        public void ConfigureOAuthentication(IAppBuilder application)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
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
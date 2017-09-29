using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

namespace VehicleTrackingSystem
{
    [ExcludeFromCodeCoverage]
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "VTSystemAPI",
                routeTemplate: "api/{controller}/{identifier}",
                defaults: new { identifier = RouteParameter.Optional }
            );
        }
    }
}

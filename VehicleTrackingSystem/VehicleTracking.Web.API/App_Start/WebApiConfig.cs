using System.Linq;
using System.Web.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

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

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
        }
    }
}
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace VehicleTrackingSystem
{
    [ExcludeFromCodeCoverage]
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            var corsConfiguration = new EnableCorsAttribute("*", "*", "*");
            configuration.EnableCors(corsConfiguration);

            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name: "VTSystemAPI",
                routeTemplate: "api/{controller}/{identifier}",
                defaults: new { identifier = RouteParameter.Optional }
            );

            var jsonFormatter = configuration.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
        }
    }
}
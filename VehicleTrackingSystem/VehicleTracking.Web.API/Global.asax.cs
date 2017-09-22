using System.Web.Http;
using System.Diagnostics.CodeAnalysis;

namespace VehicleTrackingSystem
{
    [ExcludeFromCodeCoverage]
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}

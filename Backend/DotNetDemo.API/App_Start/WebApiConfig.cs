using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using DotNetDemo.API.Filters;
using System.Web.Http.Cors;

namespace DotNetDemo.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
			config.MapHttpAttributeRoutes();
			config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );
        }
    }
}

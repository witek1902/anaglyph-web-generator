using System.Web.Mvc;
using System.Web.Routing;

namespace AnaglyphGenerator
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "AnaglyphGenerator.Controllers" }
            );

            routes.MapRoute(
                name: "",
                url: "",
                defaults: new { controller = "", action=""}
            );
        }
    }
}

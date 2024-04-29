using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Assessment_1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Route for the CustomersInGermany action
            routes.MapRoute(
                name: "CustomersInGermany",
                url: "code/customersInGermany",
                defaults: new { controller = "Code", action = "CustomersInGermany" }
            );

            // Route for the CustomerDetailsForOrderId action
            routes.MapRoute(
                name: "CustomerDetailsForOrderId",
                url: "code/customerDetailsForOrderId",
                defaults: new { controller = "Code", action = "CustomerDetailsForOrderId" }
            );

            // Default route (if no matching route is found)
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

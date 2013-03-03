using System.Collections.Generic;
using System.Linq;
using Nancy.Routing;

namespace FfCmS.Features
{
    public static class PrettyRoutePrinting
    {
        public static string RoutesToHtml(IEnumerable<Route> routes)
        {
            var routesss =
                routes.Select(route => route.Description.Method + " - " + route.Description.Path).ToList();

            return string.Join("<br/>", routesss);
        }

        public static List<RouteDescription> RoutesToDescriptions(IEnumerable<Route> routes)
        {
            return routes.Select(item => item.Description).ToList();
        } 
    }
}
using System.Linq;

namespace FfCmS.Features.Modules
{
    public class UiModule : Nancy.NancyModule
    {
        public UiModule()
        {
            Get["/"] = _ => "Hello world.";

            Options["/"] = _ =>
            {
                var routesss =
                    Routes.Select(route => route.Description.Method + " - " + route.Description.Path).ToList();

                return string.Join("<br/>", routesss);
            };
        }
    }
}
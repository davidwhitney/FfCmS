using System.Linq;
using FfCmS.Features.Persistence;
using Nancy;

namespace FfCmS.Features.Modules.Api
{
    public class ApiRootModule : NancyModule
    {
        public ApiRootModule(Storage storage)
            : base("api")
        {
            Get["/"] = _ =>
                {
                    var contentModule = new ContentModule(null);
                    var r =
                        contentModule.Routes.Select(route => route.Description.Method + " - " + route.Description.Path).ToList();
                    return string.Join("<br/>", r);
                };
        }
    }
}
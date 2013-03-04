using System.Linq;
using Nancy;

namespace FfCmS.Features.Modules
{
    public class ApiRootModule : NancyModule
    {
        public ApiRootModule()
            : base("api")
        {
            Get["/"] = _ => new ContentModule(null).Routes.Select(item => item.Description).ToList();
            Options["/"] = _ => new ContentModule(null).Routes.Select(item => item.Description).ToList();
        }
    }
}
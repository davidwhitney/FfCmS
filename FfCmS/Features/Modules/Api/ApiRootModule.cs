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
            Get["/"] = _ => new ContentModule(null).Routes.Select(item => item.Description).ToList();
            Options["/"] = _ => new ContentModule(null).Routes.Select(item => item.Description).ToList();
        }

    }
}
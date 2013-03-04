using System.Linq;
using Nancy;

namespace FfCmS.Modules
{
    public class ApiRootModule : NancyModule
    {
        public ApiRootModule()
            : base("api")
        {
            Get["/"] = _ => new ContentStoresModule(null).Routes.Select(item => item.Description).ToList();
            Options["/"] = _ => new ContentStoresModule(null).Routes.Select(item => item.Description).ToList();
        }
    }
}
using Nancy;

namespace FfCms.Server.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["index.cshtml"];
        }
    }
}
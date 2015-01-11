using Nancy;

namespace FfCmS.Server.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["index.cshtml"];
        }
    }
}
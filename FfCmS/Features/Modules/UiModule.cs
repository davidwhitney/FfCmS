using System.Linq;

namespace FfCmS.Features.Modules
{
    public class UiModule : Nancy.NancyModule
    {
        public UiModule()
        {
            Get["/"] = _ => "Hello world.";
            Options["/"] = _ => PrettyRoutePrinting.RoutesToHtml(Routes);
        }
    }
}
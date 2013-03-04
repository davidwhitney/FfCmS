namespace FfCmS.Modules
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["index.cshtml"];
        }
    }
}
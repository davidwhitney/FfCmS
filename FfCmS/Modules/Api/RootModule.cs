namespace FfCmS.Modules.Api
{
    public class RootModule : Nancy.NancyModule
    {
        public RootModule() 
            : base("api")
        {
            Get["/"] = _ => "GET /api/";
        }
    }
}
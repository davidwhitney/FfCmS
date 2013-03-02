namespace FfCmS.Modules.Api
{
    public class StoresModule : Nancy.NancyModule
    {
        public StoresModule() 
            : base("api/stores")
        {
            Get["/"] = _ => "GET api/stores";
            Get["{storeId}"] = _ => "GET api/stores/{storeId}";
        }
    }
}
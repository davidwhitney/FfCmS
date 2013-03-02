using FfCmS.Persistence;
using Nancy;

namespace FfCmS.Modules.Api
{
    public class StoresModule : Nancy.NancyModule
    {
        public StoresModule(Storage storage) 
            : base("api/stores")
        {
            Get["/"] = _ =>
            {
                var items = storage.ContentStore.List();
                return Response.AsJson(items);
            };

            Get["{storeId}"] = _ => "GET api/stores/{storeId}";
        }
    }
}
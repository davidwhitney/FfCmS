using FfCmS.Features.Persistence;
using Nancy;

namespace FfCmS.Features.Modules.Api
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
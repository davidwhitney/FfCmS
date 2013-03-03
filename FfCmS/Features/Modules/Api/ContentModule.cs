using FfCmS.Features.Persistence;
using Nancy;

namespace FfCmS.Features.Modules.Api
{
    public class ContentModule : NancyModule
    {
        public ContentModule(Storage storage)
            : base("api/stores")
        {
            Options["/"] = _ => Response.AsJson(PrettyRoutePrinting.RoutesToDescriptions(Routes));

            Get["/"] = _ =>
            {
                var items = storage.ContentStore.List();
                return Response.AsJson(items);
            };

            Get["/{storeId}"] = _ => "GET api/stores/{storeId}";
            Get["/{storeId}/content"] = _ => "GET {storeId}/content";
            Post["/{storeId}/content"] = _ => "POST {storeId}/content";
            Get["/{storeId}/content/{itemId}"] = _ => "GET {storeId}/content/{itemId}";
        }
    }
}
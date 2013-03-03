using FfCmS.Features.Persistence;
using Nancy;

namespace FfCmS.Features.Modules.Api
{
    public class ContentModule : NancyModule
    {
        public ContentModule(Storage storage)
            : base("api/stores")
        {
            Get["/"] = _ => storage.ContentStore.List();
            Get["/{storeId}"] = _ => storage.ContentStore.Retrieve(_.StoreId);
            Get["/{storeId}/content"] = _ => storage.ContentStore.Retrieve((string)_.StoreId).List();

            Post["/{storeId}/content"] = _ =>
                {
                    return "POST {storeId}/content";
                };

            Get["/{storeId}/content/{itemId}"] = _ =>
                {
                    return "GET {storeId}/content/{itemId}";
                };
        }
    }
}
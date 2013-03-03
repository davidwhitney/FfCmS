using System.Linq;
using FfCmS.Features.Persistence;
using Nancy;

namespace FfCmS.Features.Modules.Api
{
    public class ContentModule : NancyModule
    {
        public ContentModule(Storage storage)
            : base("api/stores")
        {
            Options["/"] = _ => Routes.Select(item => item.Description).ToList();

            Get["/"] = _ =>
                {
                    return storage.ContentStore.List();
                };

            Get["/{storeId}"] = _ =>
                {
                    return "GET api/stores/{storeId}";
                };

            Get["/{storeId}/content"] = _ =>
                {
                    return "GET {storeId}/content";
                };

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
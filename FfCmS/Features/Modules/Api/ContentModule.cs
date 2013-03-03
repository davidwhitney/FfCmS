using System;
using FfCmS.Features.Persistence;
using FfCmS.Model;
using Nancy;

namespace FfCmS.Features.Modules.Api
{
    public class ContentModule : NancyModule
    {
        public ContentModule(Storage storage)
            : base("api/stores")
        {
            Get["/"] = _ => storage.ContentStore.List();
            Get["/{storeId}"] = _ => storage.ContentStore.Retrieve(_.storeId);
            Get["/{storeId}/content"] = _ => storage.ContentStore.Retrieve((string) _.storeId).List();

            Post["/{storeId}/content"] = _ =>
                {
                    var guid = Guid.NewGuid().ToString();
                    var newThing = new ContentItem
                        {
                            AuthorName = "Author",
                            Body = "Body",
                            CreatorId = 1,
                            Title = "title-" + guid
                        };
                    newThing.Tags.Add("tag");

                    var store = storage.ContentStore.Retrieve((string) _.storeId);
                    return store.SaveOrUpdate(newThing);
                };

            Get["/{storeId}/content/{itemId}"] =
                _ => storage.ContentStore.Retrieve((string) _.storeId).Retrieve(_.itemId);
        }
    }
}
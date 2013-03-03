using System;
using FfCmS.Features.Persistence;
using FfCmS.Model;
using Nancy;
using Nancy.ModelBinding;

namespace FfCmS.Features.Modules.Api
{
    public class ContentModule : NancyModule
    {
        private readonly Storage _storage;

        public ContentModule(Storage storage)
            : base("api/stores")
        {
            _storage = storage;

            Get["/"] = _ => _storage.ContentStore.List();
            Get["/{storeId}"] = _ => _storage.ContentStore.Retrieve(_.storeId);
            Get["/{storeId}/content"] = _ => _storage.ContentStore.Retrieve((string)_.storeId).List();

            Post["/{storeId}/content"] = _ =>
                {
                    var posted = this.Bind<ContentItem>("id");
                    var store = _storage.ContentStore.Retrieve((string)_.storeId);
                    return store.SaveOrUpdate(posted);
                };

            Get["/{storeId}/content/{itemId}"] =
                _ => _storage.ContentStore.Retrieve((string)_.storeId).Retrieve(_.itemId);
        }
    }
}
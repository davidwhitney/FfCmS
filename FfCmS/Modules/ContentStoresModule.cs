using System;
using FfCmS.Persistence;
using Nancy;

namespace FfCmS.Modules
{
    public class ContentStoresModule : NancyModule
    {
        private readonly Storage _storage;

        public ContentStoresModule(Storage storage)
            : base("api/stores")
        {
            _storage = storage;
            Get["/"] = _ => _storage.ContentStore.List();
            Post["/"] = _ =>
                {
                    var id = Guid.NewGuid().ToString();
                    _storage.ContentStore.SaveOrUpdate(new ContentStoreForCreation(id));
                    return Response.AsRedirect(id);
                };
            Get["/{storeId}"] = _ => _storage.ContentStore.Retrieve(_.storeId) ?? HttpStatusCode.NotFound; ;
        }
    }
}
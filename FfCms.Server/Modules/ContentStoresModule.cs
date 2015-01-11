using FfCms.Persistence;
using Nancy;

namespace FfCms.Server.Modules
{
    public class ContentStoresModule : NancyModule
    {
        private readonly Storage _storage;

        public ContentStoresModule(Storage storage)
            : base("api/stores")
        {
            _storage = storage;
            Get["/"] = _ => _storage.ContentStore.List();
            Get["/{storeId}"] = _ => _storage.ContentStore.Retrieve(_.storeId) ?? HttpStatusCode.NotFound;
            ;
        }
    }
}
using FfCmS.Server.Model;
using FfCmS.Server.Persistence;
using Nancy;
using Nancy.ModelBinding;

namespace FfCmS.Server.Modules
{
    public class ContentStoreModule : NancyModule
    {
        private readonly Storage _storage;

        public ContentStoreModule(Storage storage)
            : base("api/stores/{storeId}/content")
        {
            _storage = storage;

            Get["/"] = _ =>
            {
                var store = _storage.ContentStore.Retrieve((string) _.storeId);
                if (store == null)
                {
                    return HttpStatusCode.NotFound;
                }

                return store.List(50, 0);
            };
            Post["/"] = _ =>
            {
                var posted = this.Bind<ContentItem>("id");
                var store = _storage.ContentStore.Retrieve((string) _.storeId);
                if (store == null)
                {
                    return HttpStatusCode.NotFound;
                }

                return store.SaveOrUpdate(posted);
            };
        }
    }
}
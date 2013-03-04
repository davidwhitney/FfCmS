using FfCmS.Model;
using FfCmS.Persistence;
using Nancy;
using Nancy.ModelBinding;

namespace FfCmS.Modules
{
    public class ContentStoreModule : NancyModule
    {
        private readonly Storage _storage;

        public ContentStoreModule(Storage storage)
            : base("api/stores/{storeId}/content")
        {
            _storage = storage;

            Get["/"] = _ => _storage.ContentStore.Retrieve((string)_.storeId).List(50, 0);
            Post["/"] = _ =>
                {
                    var posted = this.Bind<ContentItem>("id");
                    var store = _storage.ContentStore.Retrieve((string)_.storeId);
                    return store.SaveOrUpdate(posted);
                };

        }
    }
}
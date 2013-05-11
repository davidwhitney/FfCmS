using FfCmS.Model;
using FfCmS.Persistence;
using Nancy;
using Nancy.ModelBinding;

namespace FfCmS.Modules
{
    public class ContentStoreModule : NancyModule
    {
        private readonly Storage _storage;
        private readonly IContentStoreQueries _queries;

        public ContentStoreModule(Storage storage, IContentStoreQueries queries)
            : base("api/stores/{storeId}/content")
        {
            _storage = storage;
            _queries = queries;

            Get["/"] = _ =>
                {
                    var store = _storage.ContentStore.Retrieve((string)_.storeId);
                    if (store == null)
                    {
                        return HttpStatusCode.NotFound;
                    }

                    return _queries.ListContentItems(store);
                };
            Post["/"] = _ =>
                {
                    var item = this.Bind<ContentItem>("id");
                    var store = _storage.ContentStore.Retrieve((string)_.storeId); 
                    if (store == null)
                    {
                        return HttpStatusCode.NotFound;
                    }

                    return _queries.SaveOrUpdate(store, item);
                };

        }
    }
}
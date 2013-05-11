using FfCmS.Persistence;
using Nancy;

namespace FfCmS.Modules
{
    public class ContentItemsModule : NancyModule
    {
        private readonly Storage _storage;
        private readonly IContentStoreQueries _queries;

        public ContentItemsModule(Storage storage, IContentStoreQueries queries)
            : base("api/stores/{storeId}/content/{itemId}")
        {
            _storage = storage;
            _queries = queries;
            Get["/"] = _ =>
                {
                    var store = _storage.ContentStore.Retrieve((string) _.storeId);
                    if (store == null)
                    {
                        return HttpStatusCode.NotFound;
                    }

                    var item = _queries.Retrieve(store, _.itemId);
                    return item ?? HttpStatusCode.NotFound;
                };
        }
    }
}
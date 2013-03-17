using FfCmS.Core.Persistence;
using FfCmS.Persistence;
using Nancy;

namespace FfCmS.Modules
{
    public class ContentItemsModule : NancyModule
    {
        private readonly Storage _storage;

        public ContentItemsModule(Storage storage)
            : base("api/stores/{storeId}/content/{itemId}")
        {
            _storage = storage;
            Get["/"] = _ =>
                {
                    var store = _storage.ContentStore.Retrieve((string) _.storeId);
                    if (store == null)
                    {
                        return HttpStatusCode.NotFound;
                    }

                    var item = store.Retrieve(_.itemId);
                    return item ?? HttpStatusCode.NotFound;
                };
        }
    }
}
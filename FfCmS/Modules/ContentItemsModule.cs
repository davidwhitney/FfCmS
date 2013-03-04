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
            Get["/"] = _ =>  _storage.ContentStore.Retrieve((string) _.storeId).Retrieve(_.itemId);
        }
    }
}
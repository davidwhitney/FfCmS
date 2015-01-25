using System;
using FfCms.ContentModel;
using FfCms.StorageAdapters;

namespace FfCms
{
    public class ContentRepository : IAccessContent
    {
        public string StoreKey { get; private set; }

        private readonly IContentStorageAdapter _contentStorageAdapter;

        public ContentRepository(string storeKey, IContentStorageAdapter contentStorageAdapter, IContentIdentityGenerator identityGenerator)
        {
            _contentStorageAdapter = contentStorageAdapter;
            StoreKey = storeKey;
        }

        public Page<string> List(int take = 50, int skip = 0)
        {
            throw new NotImplementedException();
        }

        public ContentItem SaveOrUpdate(ContentItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Id))
            {
                // generate id with id generator

            }


            throw new NotImplementedException("Lets work out what we're doing with the storage adapters first...");
        }

        public ContentItem Retrieve(string itemId)
        {
            if (!_contentStorageAdapter.ContainsItem(StoreKey, itemId))
            {
                throw new Exception("Content item not found.");
            }

            return _contentStorageAdapter.GetItem(StoreKey, itemId);
        }
    }
}
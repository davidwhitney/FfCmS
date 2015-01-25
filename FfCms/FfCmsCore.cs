using System;
using System.Collections.Generic;
using System.Linq;
using FfCms.ContentModel;

namespace FfCms
{
    /// <summary>
    /// WIP - Not really sure what the purpose of this is if it just wraps the storage adapters.
    /// Caching and configuration?
    /// DSL / Fluent iface?
    /// </summary>
    public class FfCmsCore
    {
        private readonly IContentStorageAdapter _contentStorageAdapter;

        public FfCmsCore(IContentStorageAdapter contentStorageAdapter)
        {
            _contentStorageAdapter = contentStorageAdapter;
        }

        public IEnumerable<IContentStoreReference> ListStores()
        {
            return _contentStorageAdapter.List() ?? new List<IContentStoreReference>();
        }

        public IAccessStoreData Store(string storeKey)
        {
            var allStores = _contentStorageAdapter.List();
            if (allStores.All(x => x.Id != storeKey))  // TODO: Hey Resharper, is that really any better than !.Any()?
            {
                throw new Exception(string.Format("Store does not exist with key '{0}'", storeKey));
            }

            return new StoreDataRepository(storeKey, _contentStorageAdapter, new ContentIdentityGenerator());
        }
    }
}
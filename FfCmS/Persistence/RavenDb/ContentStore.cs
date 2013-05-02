using System;
using System.Linq;
using FfCmS.Model;
using Raven.Client;
using Raven.Client.Linq;

namespace FfCmS.Persistence.RavenDb
{
    public class ContentStore : IContentStore
    {
        private readonly IDocumentSession _session;

        public string Id { get; set; }
        public string Description { get; set; }
        public string DefaultCulture { get; set; }
        public StoreType StoreType { get; set; }

        public ContentStore(IDocumentSession session)
        {
            _session = session;
        }

        public Page<string> List(int take = 50, int skip = 0)
        {
            var results = _session.Query<ContentItem>()
                                    .Select(contentItem => contentItem)
                                    .OrderBy(c => c.Created)
                                    .Skip(skip)
                                    .Take(take);

            var ids = results.Select(x => x.Id).ToList();

            return new Page<string>(ids);
        }

        public ContentItem SaveOrUpdate(ContentItem item)
        {
            item.ContentStoreId = Id;
            _session.Store(item);
            return item;
        }
        
        public ContentItem Retrieve(string id)
        {
            return _session.Load<ContentItem>("ContentStores/" + Id + "/" + id);
        }
    }
}
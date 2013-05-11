using System;
using System.Linq;
using FfCmS.Model;
using Raven.Client;
using Raven.Client.Linq;

namespace FfCmS.Persistence.RavenDb
{
    public class ContentStoreQueries : IContentStoreQueries
    {
        private readonly IDocumentSession _session;

        public ContentStoreQueries(IDocumentSession session)
        {
            _session = session;
        }

        public Page<string> ListContentItems(IContentStore store, int take = 50, int skip = 0)
        {
            var results = _session.Query<ContentItem>()
                                    .Select(contentItem => contentItem)
                                    .OrderBy(c => c.Created)
                                    .Skip(skip)
                                    .Take(take);

            var ids = results.Select(x => x.Id).ToList();

            return new Page<string>(ids);
        }

        public ContentItem SaveOrUpdate(IContentStore store, ContentItem item)
        {
            item.ContentStoreId = store.Id;
            _session.Store(item);
            _session.SaveChanges();
            return item;
        }

        public ContentItem Retrieve(IContentStore store, string id)
        {
            return _session.Load<ContentItem>("ContentStores/" + store.Id + "/" + id);
        }
    }
}
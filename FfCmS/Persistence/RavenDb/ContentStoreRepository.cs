using System;
using System.Linq;
using FfCmS.Model;
using Raven.Client;

namespace FfCmS.Persistence.RavenDb
{
    public class ContentStoreRepository : IRepository<IContentStore>
    {
        private readonly IDocumentSession _session;

        public ContentStoreRepository(IDocumentSession session)
        {
            _session = session;
        }

        public Page<IContentStore> List()
        {
            var results = _session.Query<ContentStore>().Take(100).ToList();

            var page = new Page<IContentStore>();
            page.AddRange(results);
            return page;
        }

        public IContentStore SaveOrUpdate(IContentStore item)
        {
            _session.Store(item);
            _session.SaveChanges();
            return item;
        }

        public IContentStore Retrieve(string id)
        {
            return List().FirstOrDefault(x => x.Id == id);
        }
    }
}
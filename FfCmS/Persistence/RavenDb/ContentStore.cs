using System;
using FfCms.Server.Model;

namespace FfCms.Server.Persistence.RavenDb
{
    public class ContentStore : IContentStore
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string DefaultCulture { get; set; }
        public StoreType StoreType { get; set; }

        public Page<string> List(int take = 50, int skip = 0)
        {
            throw new NotImplementedException();
        }

        public ContentItem SaveOrUpdate(ContentItem item)
        {
            throw new NotImplementedException();
        }

        public ContentItem Retrieve(string id)
        {
            throw new NotImplementedException();
        }
    }
}
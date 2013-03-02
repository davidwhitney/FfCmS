using System;
using FfCmS.Model;

namespace FfCmS.Persistence
{
    public class FileSystemContentStoreRepository : IRepository<ContentStore>
    {
        public Page<ContentStore> List()
        {
            return new Page<ContentStore>
                {
                    new ContentStore(),
                    new ContentStore(),
                    new ContentStore(),
                    new ContentStore(),
                };
        }

        public ContentStore SaveOrUpdate(ContentStore item)
        {
            throw new NotImplementedException();
        }

        public ContentStore Retrieve(string id)
        {
            throw new NotImplementedException();
        }
    }
}
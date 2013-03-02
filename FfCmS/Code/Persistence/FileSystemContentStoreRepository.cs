using System;
using FfCmS.Code.Model;

namespace FfCmS.Code.Persistence
{
    public class FileSystemContentStoreRepository : IRepository<ContentStore>
    {
        public Page<ContentStore> List()
        {
            throw new NotImplementedException();
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
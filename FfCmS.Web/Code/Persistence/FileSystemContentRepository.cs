using System;
using FfCmS.Code.Model;

namespace FfCmS.Code.Persistence
{
    public class FileSystemContentRepository : IRepository<ContentItem>
    {
        public Page<ContentItem> List()
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
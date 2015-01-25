using System.Collections.Generic;
using FfCms.ContentModel;

namespace FfCms.StorageAdapters.FileSystem
{
    public class FileSystemAdapter : IContentStorageAdapter
    {
        public IEnumerable<IContentStoreReference> List()
        {
            throw new System.NotImplementedException();
        }

        public ContentItem GetItem(string containerId, string itemId)
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsItem(string storageKey, string itemId)
        {
            throw new System.NotImplementedException();
        }

        public string IdentityFor(ContentItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}
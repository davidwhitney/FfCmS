using System.Collections.Generic;
using FfCms.ContentModel;

namespace FfCms
{
    public interface IContentStorageAdapter
    {
        IEnumerable<IContentStoreReference> List();
        ContentItem GetItem(string containerId, string itemId);
        bool ContainsItem(string storageKey, string itemId);
        string IdentityFor(ContentItem item);
    }
}
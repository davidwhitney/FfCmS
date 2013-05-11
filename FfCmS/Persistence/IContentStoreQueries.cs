using FfCmS.Model;

namespace FfCmS.Persistence
{
    public interface IContentStoreQueries
    {
        Page<string> ListContentItems(IContentStore store, int take = 50, int skip = 0);
        ContentItem SaveOrUpdate(IContentStore store, ContentItem item);
        ContentItem Retrieve(IContentStore store, string id);
    }
}
using FfCms.ContentModel;

namespace FfCms
{
    /// <summary>
    /// So much dupe from old prototype. CLEAN!
    /// </summary>
    public interface IAccessStoreData
    {
        string StoreKey { get; }
        Page<string> List(int take = 50, int skip = 0);
        ContentItem SaveOrUpdate(ContentItem item);
        ContentItem Retrieve(string id);
    }
}
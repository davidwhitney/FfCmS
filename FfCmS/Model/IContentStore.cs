namespace FfCmS.Server.Model
{
    public interface IContentStore
    {
        string Id { get; set; }
        string Description { get; set; }
        string DefaultCulture { get; set; }
        StoreType StoreType { get; set; }
        Page<string> List(int take = 50, int skip = 0);
        ContentItem SaveOrUpdate(ContentItem item);
        ContentItem Retrieve(string id);
    }
}
namespace FfCms.ContentModel
{
    public interface IContentStoreReference
    {
        string Id { get; set; }
        string Description { get; set; }
        string DefaultCulture { get; set; }
        StoreType StoreType { get; set; }
    }
}
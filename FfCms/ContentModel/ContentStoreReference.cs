namespace FfCms.ContentModel
{
    public class ContentStoreReference : IContentStoreReference
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string DefaultCulture { get; set; }
        public StoreType StoreType { get; set; }
    }
}
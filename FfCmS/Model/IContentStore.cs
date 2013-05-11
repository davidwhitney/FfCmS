namespace FfCmS.Model
{
    public interface IContentStore
    {
        string Id { get; set; }
        string Description { get; set; }
        string DefaultCulture { get; set; }
        StoreType StoreType { get; set; }
    }
}
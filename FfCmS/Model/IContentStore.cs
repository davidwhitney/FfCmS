using FfCmS.Features.Persistence;

namespace FfCmS.Model
{
    public interface IContentStore : IRepository<ContentItem>
    {
        string Id { get; set; }
        string Description { get; set; }
        string DefaultCulture { get; set; }
        StoreType StoreType { get; set; }
    }
}
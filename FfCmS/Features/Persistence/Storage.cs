using FfCmS.Model;

namespace FfCmS.Features.Persistence
{
    public class Storage
    {
        public IRepository<ContentStore> ContentStore { get; set; }
        public IRepository<ContentItem> ContentItemStore { get; set; }

        public Storage(IRepository<ContentStore> contentStore, IRepository<ContentItem> contentItemStore)
        {
            ContentStore = contentStore;
            ContentItemStore = contentItemStore;
        }
    }
}
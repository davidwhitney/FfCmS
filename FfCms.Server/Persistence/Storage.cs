using FfCms.Server.Model;

namespace FfCms.Server.Persistence
{
    public class Storage
    {
        public Storage(IRepository<IContentStore> contentStore)
        {
            ContentStore = contentStore;
        }

        public IRepository<IContentStore> ContentStore { get; set; }
    }
}
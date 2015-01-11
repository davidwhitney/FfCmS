using FfCmS.Server.Model;

namespace FfCmS.Server.Persistence
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
using FfCmS.Model;

namespace FfCmS.Persistence
{
    public class Storage
    {
        public IRepository<IContentStore> ContentStore { get; set; }

        public Storage(IRepository<IContentStore> contentStore)
        {
            ContentStore = contentStore;
        }
    }
}
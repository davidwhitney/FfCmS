using FfCmS.Features.Persistence.FileSystem;
using FfCmS.Model;

namespace FfCmS.Features.Persistence
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
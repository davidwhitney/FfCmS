using FfCms.ContentModel;
using NUnit.Framework;

namespace FfCms.Test.Unit.StorageAdapters.FileSystem
{
    [TestFixture]
    public class FileSystemContentStorageAdapterTests
    {
        [Test]
        public void IdentityFor_NewContentItem_GeneratesFileSystemSafeId()
        {
            // seems like the store should drive the id generation, then get normalised by the adapter for it's storage mechanism.
            var store = new ContentStoreReference {StoreType = StoreType.Blog};

            
        }
    }

    // id generation schemes for file storage? part of the adapter or store?
    // Lets pretend they're part of the store for now --- we can always move em later.
}
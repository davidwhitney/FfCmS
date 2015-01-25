using FfCms.StorageAdapters.FileSystem;
using NUnit.Framework;

namespace FfCms.Test.Unit
{
    /// <summary>
    /// Just junk to play around with the API while this is all still embryonic
    /// </summary>
    [TestFixture]
    [Ignore]
    public class ScratchPad
    {
        [Test]
        public void Something()
        {
            // Example client code.

            var ffCms = new FfCmsCore(new FileSystemAdapter());

            var posts = ffCms.Store("BlogPosts").List();
            var stores = ffCms.Store("MarkdownContent").Retrieve("HomePage");

        }
    }
}

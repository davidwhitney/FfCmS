using System.IO.Abstractions;
using FfCmS.Model;
using Newtonsoft.Json;

namespace FfCmS.Features.Persistence.FileSystem
{
    public class FileSystemContentStore : IContentStore
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string DefaultCulture { get; set; }
        public StoreType StoreType { get; set; }

        private readonly string _directory;
        private readonly IFileSystem _fileSystem;

        public FileSystemContentStore(string directory, IFileSystem fileSystem)
        {
            _directory = directory;
            _fileSystem = fileSystem;
        }

        public Page<ContentItem> List()
        {
            var items = new Page<ContentItem>();
            var fileNames = _fileSystem.Directory.GetFiles(_directory);
            
            foreach (var fileName in fileNames)
            {
                var fileContents = _fileSystem.File.ReadAllText(fileName);
                var item = JsonConvert.DeserializeObject<ContentItem>(fileContents);
                items.Add(item);
            }

            return items;
        }

        public ContentItem SaveOrUpdate(ContentItem item)
        {
            throw new System.NotImplementedException();
        }

        public ContentItem Retrieve(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
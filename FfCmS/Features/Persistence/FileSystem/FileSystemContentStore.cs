using System.IO;
using System.IO.Abstractions;
using System.Linq;
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

        public Page<string> List()
        {
            var fileNames = _fileSystem.Directory.GetFiles(_directory);
            var items = new Page<string>();
            items.AddRange(fileNames.Select(fileName => fileName.Replace(_directory + "\\", "")));
            return items;
        }

        public ContentItem SaveOrUpdate(ContentItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Id))
            {
                item.Id = item.Title;
            }

            var text = JsonConvert.SerializeObject(item);
            var fileName = FileNameForContentItemId(item.Id);
            _fileSystem.File.WriteAllText(fileName, text);

            return item;
        }
        
        public ContentItem Retrieve(string id)
        {
            var fileName = FileNameForContentItemId(id);
            var fileContents = _fileSystem.File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<ContentItem>(fileContents);
        }

        private string FileNameForContentItemId(string id)
        {
            return Path.Combine(_directory, id + ".json");
        }
    }
}
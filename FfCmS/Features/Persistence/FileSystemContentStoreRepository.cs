using System;
using System.IO;
using System.IO.Abstractions;
using FfCmS.Model;

namespace FfCmS.Features.Persistence
{
    public class FileSystemContentStoreRepository : IRepository<ContentStore>
    {
        private readonly IFileSystem _fileSystem;
        private readonly string _appDataLocation;

        public FileSystemContentStoreRepository(IFileSystem fileSystem, string appDataLocation)
        {
            _fileSystem = fileSystem;
            _appDataLocation = appDataLocation;
        }

        public Page<ContentStore> List()
        {
            var path = Path.Combine(_appDataLocation, "FileSystemContentStores");
            var contentStores = _fileSystem.Directory.GetDirectories(path);

            var listOfStores = new Page<ContentStore>();
            foreach (var directory in contentStores)
            {
                var id = directory.Replace(path + "\\", "");
                listOfStores.Add(new ContentStore
                    {
                        Id = id,
                        Description = id,
                        DefaultCulture = "en-GB",
                        StoreType = StoreType.General
                    });
            }
            return listOfStores;
        }

        public ContentStore SaveOrUpdate(ContentStore item)
        {
            throw new NotImplementedException();
        }

        public ContentStore Retrieve(string id)
        {
            throw new NotImplementedException();
        }
    }
}
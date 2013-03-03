using System;
using System.IO.Abstractions;
using FfCmS.Model;

namespace FfCmS.Features.Persistence
{
    public class FileSystemContentStoreRepository : IRepository<ContentStore>
    {
        private readonly IFileSystem _fileSystem;

        public FileSystemContentStoreRepository(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public Page<ContentStore> List()
        {
            var whereIam = GetType().Assembly.Location;
            _fileSystem.Directory.GetDirectories(whereIam);

            return new Page<ContentStore>
                {
                    new ContentStore(),
                    new ContentStore(),
                    new ContentStore(),
                    new ContentStore(),
                };
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
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;

namespace FfCms.Persistence.FileSystem
{
    public class ContentStoreRepository : IRepository<IContentStore>
    {
        private readonly string _appDataLocation;
        private readonly IFileSystem _fileSystem;

        public ContentStoreRepository(IFileSystem fileSystem, string appDataLocation)
        {
            _fileSystem = fileSystem;
            _appDataLocation = appDataLocation;
        }

        private string FileSystemContentStoresPath
        {
            get { return Path.Combine(_appDataLocation, "FileSystemContentStores"); }
        }

        private IEnumerable<string> ContentStores
        {
            get { return _fileSystem.Directory.GetDirectories(FileSystemContentStoresPath); }
        }

        public Page<IContentStore> List()
        {
            return new Page<IContentStore>(ContentStores.Select(BuildStoreIndex).ToList());
        }

        public IContentStore SaveOrUpdate(IContentStore item)
        {
            throw new NotImplementedException();
        }

        public IContentStore Retrieve(string id)
        {
            return List().FirstOrDefault(x => x.Id == id);
        }

        private IContentStore BuildStoreIndex(string directory)
        {
            var id = directory.Replace(FileSystemContentStoresPath + "\\", "");
            return new ContentStore(directory, _fileSystem)
            {
                Id = id,
                Description = id,
                DefaultCulture = "en-GB",
                StoreType = StoreType.General
            };
        }
    }
}
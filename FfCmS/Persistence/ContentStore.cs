using System;
using FfCmS.Model;

namespace FfCmS.Persistence
{
    public class ContentStore : IContentStore
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string DefaultCulture { get; set; }
        public StoreType StoreType { get; set; }

        public ContentStore(string id)
        {
            Id = id;
            StoreType = StoreType.General;
            DefaultCulture = "en-GB";
            Description = string.Empty;
        }
    }
}
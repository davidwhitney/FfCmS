﻿using FfCms.ContentModel;

namespace FfCms
{
    public interface IContentStore : IContentStoreReference
    {
        Page<string> List(int take = 50, int skip = 0);
        ContentItem SaveOrUpdate(ContentItem item);
        ContentItem Retrieve(string id);
    }
}
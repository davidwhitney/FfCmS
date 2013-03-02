﻿namespace FfCmS.Modules.Api
{
    public class ContentModule : Nancy.NancyModule
    {
        public ContentModule()
            : base("api/stores")
        {
            Get["{storeId}/content"] = _ => "GET {storeId}/content";
            Post["{storeId}/content"] = _ => "POST {storeId}/content";
            Get["{storeId}/content/{itemId}"] = _ => "GET {storeId}/content/{itemId}";
        }
    }
}
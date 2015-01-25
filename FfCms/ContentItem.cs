using System;
using System.Collections.Generic;

namespace FfCms
{
    public class ContentItem
    {
        public ContentItem()
        {
            Tags = new List<string>();
            Created = DateTime.Now;
        }

        public string Id { get; set; }
        public int CreatorId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string AuthorName { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Created { get; set; }
    }
}
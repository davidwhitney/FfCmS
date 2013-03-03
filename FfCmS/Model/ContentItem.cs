using System.Collections.Generic;

namespace FfCmS.Model
{
    public class ContentItem
    {
        public string Id { get; set; }
        public int CreatorId { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public string AuthorName { get; set; }

        public List<string> Tags { get; set; }

        public ContentItem()
        {
            Tags = new List<string>();
        }
    }
}
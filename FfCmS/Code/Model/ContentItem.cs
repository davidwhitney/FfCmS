using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FfCmS.Code.Model
{
    public class ContentItem
    {
        public string Id { get; set; }
        public int CreatorId { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public string AuthorName { get; set; }

        public List<string> Tags { get; set; }
    }
}
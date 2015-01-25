using FfCms.ContentModel;

namespace FfCms
{
    public interface IContentIdentityGenerator
    {
        string IdFor(ContentItem contentItem, StoreType storeType);
    }

    public class ContentIdentityGenerator : IContentIdentityGenerator
    {
        public string IdFor(ContentItem contentItem, StoreType storeType)
        {
            var dateStub = contentItem.Created.ToString("yyyyMMddHHmmss");
            dateStub += "-" + contentItem.Title.Replace(" ", "_").Truncate(25);
            return dateStub;
        }
    }
}
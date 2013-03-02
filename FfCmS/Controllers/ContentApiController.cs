using System.Web.Http;
using AttributeRouting.Web.Mvc;
using FfCmS.Code.Model;
using FfCmS.Code.Persistence;

namespace FfCmS.Controllers
{
    public class ContentApiController : ApiController
    {
        private readonly IPersistence _persistence;

        public ContentApiController(IPersistence persistence)
        {
            _persistence = persistence;
        }

        [GET("/api/stores")]
        public void ListStores()
        {
        }

        [GET("/api/stores/{storeId}")]
        public void RetrieveStore()
        {
        }

        [GET("/api/stores/{storeId}/content")]
        public void ListContentItems(string storeId)
        {
        }

        [POST("/api/stores/{storeId}/content")]
        public void CreateContent(string storeId, ContentItem item)
        {
        }

        [GET("/api/stores/{storeId}/content/{itemId}")]
        public void RetrieveContentItem(string storeId, string itemid)
        {
        }
    }
}

using System;
using FfCmS.Code.Model;
using FfCmS.Code.Persistence;

namespace FfCmS.Controllers
{
    public class ContentApiController : ApiController
    {
        public static Func<Storage> InitStorage { get; set; }

        private readonly Storage _storage;

        public ContentApiController()
        {
            _storage = InitStorage();
        }

        [HttpGet]
        [GET("api/stores/{storeId}/content")]
        public void ListContentItems(string storeId)
        {
        }

        [HttpPost]
        [POST("api/stores/{storeId}/content")]
        public void CreateContent(string storeId, ContentItem item)
        {
        }

        [HttpGet]
        [GET("api/stores/{storeId}/content/{itemId}")]
        public void RetrieveContentItem(string storeId, string itemid)
        {
        }
    }
}

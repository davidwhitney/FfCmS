using System;
using System.Web.Http;
using AttributeRouting.Web.Mvc;
using FfCmS.Code.Model;
using FfCmS.Code.Persistence;

namespace FfCmS.Controllers
{
    public class StoresApiController : ApiController
    {
        public static Func<Storage> InitStorage { get; set; }
        private readonly Storage _storage;

        public StoresApiController()
        {
            _storage = InitStorage();
        }

        [HttpGet]
        [GET("api/stores")]
        public Page<ContentStore> Index()
        {
            return _storage.ContentStore.List();
        }

        [HttpGet]
        [GET("api/stores/{storeId}")]
        public void RetrieveStore()
        {
        }
    }
}
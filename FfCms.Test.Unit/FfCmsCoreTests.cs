using System;
using System.Collections.Generic;
using System.Linq;
using FfCms.ContentModel;
using FfCms.StorageAdapters;
using Moq;
using NUnit.Framework;

namespace FfCms.Test.Unit
{
    [TestFixture]
    public class FfCmsCoreTests
    {
        private FfCmsCore _cms;
        private Mock<IContentStorageAdapter> _contentStoreRepository;
        private List<IContentStoreReference> _underlyingListOfStores;
        private const string KeyThatExists = "key-that-exists";

        [SetUp]
        public void SetUp()
        {
            _underlyingListOfStores = new List<IContentStoreReference>();
            _contentStoreRepository = new Mock<IContentStorageAdapter>();
            _contentStoreRepository.Setup(x => x.List()).Returns(_underlyingListOfStores);
            
            _cms = new FfCmsCore(_contentStoreRepository.Object);
        }

        [Test]
        public void ListStores_NoStoresAvailable_ReturnsEmptyList()
        {
            var stores = _cms.ListStores();

            Assert.That(stores, Is.Not.Null);
        }

        [Test]
        public void ListStores_StoresAvailableFromAdapter_ReturnsStoreReference()
        {
            _underlyingListOfStores.Add(new ContentStoreReference());

            var stores = _cms.ListStores();

            Assert.That(stores.Count(), Is.EqualTo(1));
        }

        [TestCase("random-key-that-doesnt-exist")]
        [TestCase("some-other-fake-key")]
        public void Store_WhenStoreKeyDoesNotExist_Throws(string keyThatDoesntExist)
        {
            var ex = Assert.Throws<Exception>(() => _cms.Store(keyThatDoesntExist));

            Assert.That(ex.Message, Is.EqualTo("Store does not exist with key '" + keyThatDoesntExist + "'"));
        }

        [Test]
        public void Store_WhenStoreKeyExists_ReturnsThingThatCanAccessStoreData()
        {
            _underlyingListOfStores.Add(new ContentStoreReference { Id = KeyThatExists });

            var accessStoreData = _cms.Store(KeyThatExists);

            Assert.That(accessStoreData, Is.Not.Null);
        }

        [Test]
        public void Store_WhenStoreKeyExists_ReturnsStoreAccessorScopedToKeyRequested()
        {
            _underlyingListOfStores.Add(new ContentStoreReference { Id = KeyThatExists });

            var accessStoreData = _cms.Store(KeyThatExists);

            Assert.That(accessStoreData.StoreKey, Is.EqualTo(KeyThatExists));
        }
    }
}

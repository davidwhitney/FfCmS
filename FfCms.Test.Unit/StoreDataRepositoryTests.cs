using System;
using FfCms.ContentModel;
using Moq;
using NUnit.Framework;

namespace FfCms.Test.Unit
{
    [TestFixture]   
    public class StoreDataRepositoryTests
    {
        private StoreDataRepository _dataRepo;
        private Mock<IContentStorageAdapter> _fakeStorageAdapter;
        
        private const string IdThatExists = "id-that-exists";
        private const string ValidContainerId = "some-key";

        [SetUp]
        public void SetUp()
        {
            _fakeStorageAdapter = new Mock<IContentStorageAdapter>();
            _dataRepo = new StoreDataRepository(ValidContainerId, _fakeStorageAdapter.Object);
        }

        [Test]
        public void Retrieve_ContentThatDoesNotExist_Throws()
        {
            var ex = Assert.Throws<Exception>(() => _dataRepo.Retrieve("id-of-content-that-doesnt-exists"));

            Assert.That(ex.Message, Is.EqualTo("Content item not found."));
        }

        [Test]
        public void Retrieve_ContentThatDoesExist_ReturnsContentItem()
        {
            var item = new ContentItem();

            _fakeStorageAdapter.Setup(x => x.ContainsItem(ValidContainerId, IdThatExists)).Returns(true);
            _fakeStorageAdapter.Setup(x => x.GetItem(ValidContainerId, IdThatExists)).Returns(item);

            var content = _dataRepo.Retrieve(IdThatExists);

            Assert.That(content, Is.Not.Null);
        }

        [Test]
        public void SaveOrUpdate_NewItem_ModifiesSavedItemAssigningAppropriateId()
        {
            var item = new ContentItem();

            _dataRepo.SaveOrUpdate(item);

            Assert.That(item.Id, Is.Not.Null);
        }
    }
}
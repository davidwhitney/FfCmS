using System;
using FfCms.ContentModel;
using NUnit.Framework;

namespace FfCms.Test.Unit
{
    [TestFixture]
    public class ContentIdentityGeneratorTests
    {
        private ContentIdentityGenerator _gen;
        private ContentItem _contentItem;

        [SetUp]
        public void SetUp()
        {
            _gen = new ContentIdentityGenerator();
            _contentItem = new ContentItem
            {
                Title = "Shorttitle",
                Created = new DateTime(2005, 1, 2, 10, 11, 12, DateTimeKind.Utc)
            };
        }

        [Test]
        public void GenerateId_Blog_ReturnsBlogIdFormat()
        {
            var id = _gen.IdFor(_contentItem, StoreType.Blog);
            
            Assert.That(id, Is.EqualTo("20050102101112-Shorttitle"));
        }

        [Test]
        public void GenerateId_BlogWithMultiWordTitle_TitleIsUnderscored() // BAD DAVID! TWO FAILING TESTS!
        {
            _contentItem.Title = "Two words";

            var id = _gen.IdFor(_contentItem, StoreType.Blog);

            Assert.That(id, Is.EqualTo("20050102101112-Two_words"));
        }

        [Test]
        public void GenerateId_BlogWithLongTitle_TruncatesAt25Chars()
        {
            _contentItem.Title = "The quick brown fox jumps over the lazy dog";

            var id = _gen.IdFor(_contentItem, StoreType.Blog);

            Assert.That(id, Is.EqualTo("20050102101112-The_quick_brown_fox_jumps"));
        }
    }
}
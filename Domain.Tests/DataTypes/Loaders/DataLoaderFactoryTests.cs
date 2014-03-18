using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Domain.DataTypes.Loaders;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.DataTypes.Loaders
{
    [TestFixture]
    public class DataLoaderFactoryTests
    {
        private DataLoaderFactory _factory;
        private Mock<IBitmapImageWrapper> _mockBitmapImageWrapper;
        
        [SetUp]
        public void SetUp()
        {
            _mockBitmapImageWrapper = new Mock<IBitmapImageWrapper>();

            _factory = new DataLoaderFactory(
                _mockBitmapImageWrapper.Object);

        }

        [Test]
        public void TestCreateShouldCreateImageLoader()
        {
            var result = _factory.Create(typeof (BitmapImage), string.Empty);
            Assert.That(result, Is.TypeOf<ImageLoader>());
        }

        [Test]
        public void TestCreateShouldReturnNullForNonLoadableDataTypes()
        {
            var result = _factory.Create(typeof(Boolean), string.Empty);
            Assert.That(result, Is.Null);
        }
    }
}

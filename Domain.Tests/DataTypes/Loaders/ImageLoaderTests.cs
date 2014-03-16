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
    public class ImageLoaderTests
    {
        private ImageLoader _loader;
        private Mock<IBitmapImageWrapper> _mockBitmapImageWrapper;
        private string _baseUri;
        private BitmapImage _image;

        [SetUp]
        public void SetUp()
        {
            _baseUri = @"C:\DataFolder";
            _image = new BitmapImage();

            _mockBitmapImageWrapper = new Mock<IBitmapImageWrapper>();
            
            _loader = new ImageLoader(
                _mockBitmapImageWrapper.Object,
                _baseUri);
        }

        [Test]
        public void TestLoaderShouldLoadImageFromUrl()
        {
            var uri = new Uri("http://www.test.com/image.jpg");
            _mockBitmapImageWrapper.Setup(p => p.Load(uri))
                .Returns(_image);
            var result = _loader.Load(uri.ToString());
            Assert.That(result, Is.EqualTo(_image));
        }

        [Test]
        public void TestLoaderShouldLoadImageFromAbsoluteFilePath()
        {
            var uri = new Uri(@"C:\DataFolder\ImageFolder\Image.jpg");
            _mockBitmapImageWrapper.Setup(p => p.Load(uri))
                .Returns(_image);
            var result = _loader.Load(uri.ToString());
            Assert.That(result, Is.EqualTo(_image));
        }

        [Test]
        public void TestLoaderShouldLoadImageFromRelativeFilePath()
        {
            var uri = new Uri(@"C:\DataFolder\ImageFolder\Image.jpg");
            _mockBitmapImageWrapper.Setup(p => p.Load(uri))
                .Returns(_image);
            var result = _loader.Load(@"ImageFolder\Image.jpg");
            Assert.That(result, Is.EqualTo(_image));
        }
    }
}

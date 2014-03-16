using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using DataExplorer.Domain.DataTypes.Detectors;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.DataTypes.Detectors
{
    [TestFixture]
    public class DataTypeDetectorTests
    {
        private DataTypeDetector _detector;

        [SetUp]
        public void SetUp()
        {
            _detector = new DataTypeDetector();
        }

        [Test]
        public void TestDetectShouldReturnBoolean()
        {
            var values = new List<string>() { string.Empty, "true", "false" };
            var result = _detector.Detect(values);
            Assert.That(result, Is.EqualTo(typeof(Boolean)));
        }

        [Test]
        public void TestDetectShouldReturnDateTime()
        {
            var values = new List<string>() { string.Empty, "1/1/0001", "12/31/9999" };
            var result = _detector.Detect(values);
            Assert.That(result, Is.EqualTo(typeof(DateTime)));
        }

        [Test]
        public void TestDetectShouldReturnInteger()
        {
            var values = new List<string>() { string.Empty, "-1", "0", "1" };
            var result = _detector.Detect(values);
            Assert.That(result, Is.EqualTo(typeof(Int32)));
        }

        [Test]
        public void TestDetectShouldReturnFloat()
        {
            var values = new List<string>() { string.Empty, "-1.0", "0.0", "1.0" };
            var result = _detector.Detect(values);
            Assert.That(result, Is.EqualTo(typeof(Double)));
        }

        [Test]
        public void TestDetectShouldReturnImage()
        {
            var values = new List<string>
            {
                "http://www.test.com/image.jpg",
                @"C:\Folder\Image.png",
                @"\Folder\Image.bmp"
            };
            var result = _detector.Detect(values);
            Assert.That(result, Is.EqualTo(typeof(BitmapImage)));
        }

        [Test]
        public void TestDetectShouldReturnString()
        {
            var values = new List<string>() { string.Empty, "true", "0", "1.0" };
            var result = _detector.Detect(values);
            Assert.That(result, Is.EqualTo(typeof(String)));
        }
    }
}

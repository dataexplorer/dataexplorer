using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Importers;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Importers
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
        public void TestDetectorShouldReturnBoolean()
        {
            var values = new List<string>() { string.Empty, "true", "false" };
            var result = _detector.Detect(values);
            Assert.That(result, Is.EqualTo(typeof(Boolean)));
        }

        [Test]
        public void TestDetectorShouldReturnDateTime()
        {
            var values = new List<string>() { string.Empty, "1/1/0001", "12/31/9999" };
            var result = _detector.Detect(values);
            Assert.That(result, Is.EqualTo(typeof(DateTime)));
        }

        [Test]
        public void TestDetectorShouldReturnInteger()
        {
            var values = new List<string>() { string.Empty, "-1", "0", "1" };
            var result = _detector.Detect(values);
            Assert.That(result, Is.EqualTo(typeof(Int32)));
        }

        [Test]
        public void TestDetectorShouldReturnFloat()
        {
            var values = new List<string>() { string.Empty, "-1.0", "0.0", "1.0" };
            var result = _detector.Detect(values);
            Assert.That(result, Is.EqualTo(typeof(Double)));
        }

        [Test]
        public void TestDetectorShouldReturnString()
        {
            var values = new List<string>() { string.Empty, "true", "0", "1.0" };
            var result = _detector.Detect(values);
            Assert.That(result, Is.EqualTo(typeof(String)));
        }
    }
}
